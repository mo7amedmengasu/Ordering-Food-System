using System;
using System.Windows.Forms;
using Db_Project.models;
using Db_Project.Repositories;
using Db_Project.Forms;

namespace Db_Project.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserRepository _userRepository;
        string ConnectionString = "Data Source=RENADLAPTOP;Initial Catalog=windb;Integrated Security=True;";


        public LoginForm()
        {
            InitializeComponent();
            _userRepository = new UserRepository(ConnectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text; // Get plain text password

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Users validatedUser = _userRepository.ValidateUser(email, password); 

                if (validatedUser != null)
                {
                    MessageBox.Show($"Login successful! Welcome {validatedUser.FirstName}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CurrentUser.LoggedInUser = validatedUser;

                    if (validatedUser.UserRole.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Admin Dashboard would open here."); 
                    }
                    else 
                    {

                        //MessageBox.Show("Customer Dashboard would open here."); 
                       //UserProfileForm profileForm = new UserProfileForm();
                       //profileForm.Show();

                        RestaurantsAvailable restaurantForm = new RestaurantsAvailable(CurrentUser.LoggedInUser);
                        restaurantForm.Show();

                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnGoToSignup_Click(object sender, EventArgs e)
        {
            SignupForm signupForm = new SignupForm();
            signupForm.Show();
            this.Close(); 
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }


    public static class CurrentUser
    {
        public static Users LoggedInUser { get; set; }
    }
}