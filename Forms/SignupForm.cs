using System;
using System.Windows.Forms;
using Db_Project.models;        
using Db_Project.Repositories;  
using Db_Project.Forms;

namespace Db_Project.Forms
{
    public partial class SignupForm : Form
    {
        private readonly UserRepository _userRepository;
        private readonly UserPhoneRepository _userPhoneRepository;
        string ConnectionString = "Data Source=LAPTOP-6DMMQEEO;Initial Catalog=WinDB;Integrated Security=True;";

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
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields and select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newUser = new Users 
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                UserAddress = txtAddress.Text.Trim(),
                UserRole = cmbRole.SelectedItem.ToString(),
                UserPassword = txtPassword.Text
            };

            try
            {

                int newUserId = _userRepository.AddUser(newUser);

                if (newUserId > 0) 

                    if (newUserId > 0) 
                    {
                        var newUserPhone = new UserPhone
                        {
                            UserID = newUserId,
                            Phone = txtPhone.Text.Trim()
                        };

                        try
                        {
                            _userPhoneRepository.AddUserPhone(newUserPhone); // Call void method

                            MessageBox.Show("Signup successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoginForm loginForm = new LoginForm();
                            loginForm.Show();
                            this.Close();
                        }
                        catch (Exception phoneEx) // Catch exceptions specifically from adding phone
                        {
                            Console.WriteLine($"ERROR adding phone after user creation (UserID: {newUserId}): {phoneEx.ToString()}");
                            MessageBox.Show("Signup partially failed: User created, but could not add phone number due to an error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Signup failed. The email might already be registered, or a database error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            } 
            catch (Exception ex) 
            {
                Console.WriteLine("SIGNUP ERROR: " + ex.ToString());
                MessageBox.Show($"An unexpected error occurred during signup. Please try again later.", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


