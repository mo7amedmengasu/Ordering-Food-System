using Db_Project.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Db_Project.Forms
{
    public partial class UserDashboard: Form
    {
        public Users user = new Users();
        public UserDashboard(Users user)
        {
            this.user = user;
            InitializeComponent();
        }
  

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserProfileForm userProfileForm = new UserProfileForm(this);
            this.Hide();
            userProfileForm.Show();
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserOrdersForm userOrdersForm = new UserOrdersForm(this);
            this.Hide();
            userOrdersForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Open the menu form with this ID
            RestaurantsAvailable restaurantsAvailable = new RestaurantsAvailable(this.user, this);
            this.Hide();
            restaurantsAvailable.Show();
        }
    }
}
