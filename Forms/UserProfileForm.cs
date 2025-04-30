using System;
using System.Collections.Generic; // Needed for List
using System.Configuration;
using System.Linq; // Needed for .FirstOrDefault()
using System.Windows.Forms;
using Db_Project.models;
using Db_Project.Repositories;

namespace Db_Project.Forms
{
    public partial class UserProfileForm : Form
    {
        private readonly UserRepository _userRepository;
        private readonly UserPhoneRepository _userPhoneRepository; // Using your void/List methods

        private Users _currentUserData;
        // We still need to track the specific phone being displayed/edited
        private UserPhone _currentDisplayPhone; // Renamed for clarity

        string ConnectionString = "Data Source=LAPTOP-6DMMQEEO;Initial Catalog=WinDB;Integrated Security=True;";

        public UserProfileForm()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(ConnectionString))
            {
                MessageBox.Show("Database connection string is missing or invalid in App.config.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Load += (s, e) => this.Close();
                return;
            }

            _userRepository = new UserRepository(ConnectionString);
            _userPhoneRepository = new UserPhoneRepository(ConnectionString);

            this.Load += UserProfileForm_Load;
        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ConnectionString)) return;

            if (CurrentUser.LoggedInUser == null)
            {
                MessageBox.Show("Error: No user is logged in. Please log in again.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int currentUserId = CurrentUser.LoggedInUser.UserID;
           // lblUserIDValue?.SetText(currentUserId.ToString());

            try
            {
                _currentUserData = _userRepository.GetUserById(currentUserId);

                // --- Get phone list and find the one to display ---
                // Your repo returns a List<UserPhone>
                List<UserPhone> userPhones = _userPhoneRepository.GetPhonesByUser(currentUserId);
                // We need to decide which phone to show if there are multiple.
                // Let's take the first one found, or null if the list is empty.
                _currentDisplayPhone = userPhones.FirstOrDefault(); // Get first or null

                if (_currentUserData != null)
                {
                    txtFirstName?.SetText(_currentUserData.FirstName ?? "");
                    txtLastName?.SetText(_currentUserData.LastName ?? "");
                    txtEmail?.SetText(_currentUserData.Email ?? "");
                    txtAddress?.SetText(_currentUserData.UserAddress ?? "");
                    if (txtEmail != null) txtEmail.ReadOnly = true;

                    // Set phone text based on the first phone found (or empty)
                    if (_currentDisplayPhone != null)
                    {
                        txtPhone?.SetText(_currentDisplayPhone.Phone ?? "");
                    }
                    else
                    {
                        txtPhone?.SetText(""); // No phone on record
                    }
                }
                else
                {
                    MessageBox.Show("Could not load user data for the logged-in user.", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading profile data: {ex.ToString()}");
                MessageBox.Show($"An error occurred while loading profile data.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


    private void btnSaveChanges_Click(object sender, EventArgs e)
    {
        if (_currentUserData == null)
        {
            MessageBox.Show("Cannot save changes, user data not loaded correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtFirstName?.Text) ||
            string.IsNullOrWhiteSpace(txtLastName?.Text) ||
            string.IsNullOrWhiteSpace(txtAddress?.Text)) // Phone validation handled separately
        {
            MessageBox.Show("Please ensure First Name, Last Name, and Address are filled.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // --- Prepare User Update ---
        _currentUserData.FirstName = txtFirstName.Text.Trim();
        _currentUserData.LastName = txtLastName.Text.Trim();
        _currentUserData.UserAddress = txtAddress.Text.Trim();

        // --- Prepare Phone Update/Add/Delete ---
        string enteredPhone = txtPhone.Text.Trim();
        bool phoneCurrentlyExists = _currentDisplayPhone != null;
        bool enteredPhoneIsEmpty = string.IsNullOrWhiteSpace(enteredPhone);

        try // Wrap entire save operation
        {
            // --- Update User Details First ---
            // Assuming UpdateUser returns void and throws on critical DB error
            _userRepository.UpdateUser(_currentUserData);
            // If we reach here, assume user update was sent to DB ok

            // --- Handle Phone Changes ---
            if (phoneCurrentlyExists)
            {
                // A phone number was loaded initially
                if (enteredPhoneIsEmpty)
                {
                    // User deleted the phone number -> Delete from DB
                    _userPhoneRepository.DeleteUserPhone(_currentUserData.UserID, _currentDisplayPhone.Phone);
                    _currentDisplayPhone = null; // Update local state
                    Console.WriteLine($"Phone deleted for UserID {_currentUserData.UserID}");
                }
                else if (_currentDisplayPhone.Phone != enteredPhone)
                {
                    // User changed the phone number -> Update in DB
                    // Note: Your current repo doesn't have an Update method.
                    // We have to Delete the old and Add the new (less ideal)
                    // OR **add an UpdatePhone method to your repository**.

                    // --- OPTION 1: Delete then Add (if no UpdatePhone method exists) ---
                    // _userPhoneRepository.DeleteUserPhone(_currentUserData.UserID, _currentDisplayPhone.Phone);
                    // UserPhone newPhoneToAdd = new UserPhone { UserID = _currentUserData.UserID, Phone = enteredPhone };
                    // _userPhoneRepository.AddUserPhone(newPhoneToAdd);
                    // _currentDisplayPhone = newPhoneToAdd; // Update local state
                    // Console.WriteLine($"Phone updated (via Delete/Add) for UserID {_currentUserData.UserID}");

                    // --- OPTION 2: Assume UpdatePhone method IS added to Repo (Preferred) ---
                    UserPhone phoneToUpdate = new UserPhone { UserID = _currentUserData.UserID, Phone = enteredPhone };
                    _userPhoneRepository.UpdatePhone(phoneToUpdate); // Call the Update method
                    _currentDisplayPhone = phoneToUpdate; // Update local state
                    Console.WriteLine($"Phone update attempted for UserID {_currentUserData.UserID}");

                }
                // else: Phone exists and hasn't changed - do nothing

            }
            else // No phone was loaded initially (_currentDisplayPhone was null)
            {
                if (!enteredPhoneIsEmpty)
                {
                    // User entered a phone number where there was none -> Add to DB
                    UserPhone phoneToAdd = new UserPhone { UserID = _currentUserData.UserID, Phone = enteredPhone };
                    _userPhoneRepository.AddUserPhone(phoneToAdd);
                    _currentDisplayPhone = phoneToAdd; // Update local state
                    Console.WriteLine($"Phone added for UserID {_currentUserData.UserID}");
                }
                // else: No phone existed and user entered nothing - do nothing
            }

            // If we reach here without exceptions, report general success
            MessageBox.Show("Profile changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Note: We don't have bool confirmation from repo methods here.

        }
        catch (Exception ex)
        {
            // Log ex.ToString()
            Console.WriteLine($"Error saving profile changes: {ex.ToString()}");
            MessageBox.Show($"An error occurred while saving profile changes. Check logs for details.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Consider reloading data on error?
            // UserProfileForm_Load(this, EventArgs.Empty);
        }
    }

        private void UserProfileForm_Load_1(object sender, EventArgs e)
        {

        }
    }
    // Optional Helper Extension Method
    public static class ControlExtensions
    {
        public static void SetText(this Control control, string text)
        {
            if (control != null) control.Text = text;
        }
    }
}