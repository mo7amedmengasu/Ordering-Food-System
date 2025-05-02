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
            ManageMenuForm manageMenuForm = new ManageMenuForm();
            manageMenuForm.Show();
        }

        private void btnManageRestaurants_Click(object sender, EventArgs e)
        {
            ManageRestaurantsForm manageRestaurantsForm = new ManageRestaurantsForm();
            manageRestaurantsForm.Show();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            /*ManageUsersForm manageUsersForm = new ManageUsersForm();
            manageUsersForm.Show();*/
        }
    }
}
