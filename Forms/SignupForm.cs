using System;
using System.Windows.Forms;
using Db_Project.models;        
using Db_Project.Repositories;  
using Db_Project.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Db_Project.Forms
{
    public partial class SignupForm : Form
    {
        private readonly UserRepository _userRepository;
        private readonly UserPhoneRepository _userPhoneRepository;
        string ConnectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";

        public SignupForm()
        {
            InitializeComponent(); 

            _userRepository = new UserRepository(ConnectionString);
            _userPhoneRepository = new UserPhoneRepository(ConnectionString);

           
            try 
            {
                if (cmbRole != null && cmbRole.Items != null) 
                {
                    cmbRole.Items.Add("Customer");
                    cmbRole.Items.Add("Admin"); 
                    if (cmbRole.Items.Count > 0)
                    {
                        cmbRole.SelectedIndex = 0; // Default to Customer
                    }
                }
                else
                {
                    MessageBox.Show("Error initializing Role selection.", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting up roles: {ex.Message}", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private UserPhoneRepository Get_userPhoneRepository()
        {
            return _userPhoneRepository;
        }

    private void BtnSignup_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();
            string password = txtPassword.Text; 
            string phone = txtPhone.Text.Trim();
            string selectedRole = cmbRole.SelectedItem?.ToString(); 

            //Checks for nonempty fields
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

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return; 
            }
            //email regex
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Please enter a valid Email address format (e.g., name@domain.com).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return; 
            }

           
            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Address cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return; 
            }

            // password checks
            if (string.IsNullOrEmpty(password)) 
            {
                MessageBox.Show("Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return; 
            }
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // phone number checks
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Phone cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return; 
            }
            if (!phone.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must contain only digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                txtPhone.SelectAll(); 
                return; 
            }
            if (phone.Length < 11)
            {
                MessageBox.Show("Phone number must be at least 11 digits long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return; 
            }

          
            if (selectedRole == null)
            {
                MessageBox.Show("Please select a Role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return; 
            }


            //if it pass all validations
            var newUser = new Users
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserAddress = address,
                UserRole = selectedRole,
                UserPassword = password 
            };

            try
            {
                int newUserId = _userRepository.AddUser(newUser);

                if (newUserId > 0)
                {
                    var newUserPhone = new UserPhone
                    {
                        UserID = newUserId,
                        Phone = phone 
                    };

                    try 
                    {
                        _userPhoneRepository.AddUserPhone(newUserPhone);

                        MessageBox.Show("Signup successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                        this.Close();
                    }
                    catch (Exception phoneEx)
                    {
                        Console.WriteLine($"ERROR adding phone after user creation (UserID: {newUserId}): {phoneEx.ToString()}");
                        MessageBox.Show("Signup partially failed: User created, but could not add phone number due to an error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    MessageBox.Show("Signup failed. The email might already be registered, or a database error occurred.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("SIGNUP ERROR: " + ex.ToString());
                MessageBox.Show($"An unexpected error occurred during signup. Please check logs or try again later.", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void BtnGoToLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close(); 
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {

        }
    }
}


