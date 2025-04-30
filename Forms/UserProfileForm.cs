using System;
using System.Collections.Generic; 
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
        private readonly UserPhoneRepository _userPhoneRepository;

        private Users _currentUserData;
        private UserPhone _currentDisplayPhone;

        string ConnectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";

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

            try
            {
                _currentUserData = _userRepository.GetUserById(currentUserId);
                List<UserPhone> userPhones = _userPhoneRepository.GetPhonesByUser(currentUserId);
                _currentDisplayPhone = userPhones.FirstOrDefault();

                if (_currentUserData != null)
                {
                    txtFirstName?.SetText(_currentUserData.FirstName ?? "");
                    txtLastName?.SetText(_currentUserData.LastName ?? "");
                    txtEmail?.SetText(_currentUserData.Email ?? "");
                    txtAddress?.SetText(_currentUserData.UserAddress ?? "");
                    if (txtEmail != null) txtEmail.ReadOnly = true;

                    if (_currentDisplayPhone != null)
                    {
                        txtPhone?.SetText(_currentDisplayPhone.Phone ?? "");
                    }
                    else
                    {
                        txtPhone?.SetText("");
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

            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string enteredPhone = txtPhone.Text.Trim(); 


            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("First Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }
            if (!firstName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("First Name must contain only letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Last Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }
            if (!lastName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Last Name must contain only letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Address cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }

            bool enteredPhoneIsEmpty = string.IsNullOrWhiteSpace(enteredPhone);
            if (!enteredPhoneIsEmpty) 
            {
                if (!enteredPhone.All(char.IsDigit))
                {
                    MessageBox.Show("Phone number must contain only digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    txtPhone.SelectAll();
                    return;
                }
                if (enteredPhone.Length < 11) 
                {
                    MessageBox.Show("Phone number must be at least 11 digits long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }
            }


            _currentUserData.FirstName = firstName;
            _currentUserData.LastName = lastName;
            _currentUserData.UserAddress = address;

            bool phoneCurrentlyExists = _currentDisplayPhone != null;

            try 
            {
                _userRepository.UpdateUserProfile(_currentUserData);
                Console.WriteLine($"User profile update attempted for UserID {_currentUserData.UserID}");

                if (phoneCurrentlyExists)
                {
                    if (enteredPhoneIsEmpty)
                    {
                        _userPhoneRepository.DeleteUserPhone(_currentUserData.UserID, _currentDisplayPhone.Phone);
                        _currentDisplayPhone = null;
                        Console.WriteLine($"Phone delete attempted for UserID {_currentUserData.UserID}");
                    }
                    else if (_currentDisplayPhone.Phone != enteredPhone)
                    {
                        UserPhone phoneToUpdate = new UserPhone { UserID = _currentUserData.UserID, Phone = enteredPhone };
                        _userPhoneRepository.UpdatePhone(phoneToUpdate); 
                        _currentDisplayPhone = phoneToUpdate; 
                        Console.WriteLine($"Phone update attempted for UserID {_currentUserData.UserID}");
                    }
                }
                else 
                {
                    if (!enteredPhoneIsEmpty)
                    {
                        UserPhone phoneToAdd = new UserPhone { UserID = _currentUserData.UserID, Phone = enteredPhone };
                        _userPhoneRepository.AddUserPhone(phoneToAdd); 
                        _currentDisplayPhone = phoneToAdd;
                        Console.WriteLine($"Phone add attempted for UserID {_currentUserData.UserID}");
                    }
                }

                MessageBox.Show("Profile changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error saving profile changes: {ex.ToString()}");
                MessageBox.Show(ex.ToString());
                UserProfileForm_Load(this, EventArgs.Empty);
            }
        }

        private void UserProfileForm_Load_1(object sender, EventArgs e)
        {

        }
    }
    public static class ControlExtensions
    {
        public static void SetText(this Control control, string text)
        {
            if (control != null) control.Text = text;
        }
    }
}