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
    public partial class AdminNavigationn : Form
    {
        public AdminNavigationn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnManageMenu_Click(object sender, EventArgs e)
        {
            ManageMenuForm manageMenuForm = new ManageMenuForm(this);
            manageMenuForm.Show();
            this.Hide();
        }

        private void btnManageRestaurants_Click(object sender, EventArgs e)
        {
            ManageRestaurantsForm manageRestaurantsForm = new ManageRestaurantsForm(this);
            manageRestaurantsForm.Show();
            this.Hide();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ManageUserForm manageUsersForm = new ManageUserForm(this);
            manageUsersForm.Show();
            this.Hide();
        }

        private void AdminNavigationn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllOrdersForm  allOrdersForm = new AllOrdersForm(this);
            allOrdersForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Show_Pending_Oeders show_Pending_Oeders = new Show_Pending_Oeders(this);
            show_Pending_Oeders.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowAssignedOrders showAssignedOrders = new ShowAssignedOrders(this);
            showAssignedOrders.Show();
            this.Hide();
        }
    }
}
