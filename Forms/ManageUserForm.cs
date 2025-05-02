using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db_Project.models;

namespace Db_Project.Forms
{
    public partial class ManageUserForm: Form
    {
        private static string connectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        UserRepository userRepository = new UserRepository(connectionString);
        private AdminNavigationn adminNavigationn;
        public ManageUserForm(AdminNavigationn adminNavigationn)
        {
            this.adminNavigationn = adminNavigationn;
            InitializeComponent();
            readusers();
        }

        private void ManageUserForm_Load(object sender, EventArgs e)
        {

        }
        void readusers()
        {
            List<Users> users = userRepository.GetAllCustomers();

            if (users == null || users.Count == 0)
            {
                MessageBox.Show("No users found.");
                return;
            }
            var table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("Role", typeof(string));
      

            foreach (var user in users)
            {
                table.Rows.Add(user.UserID, user.FirstName, user.LastName, user.Email, user.UserAddress, user.UserRole);
            }
            dataGridView1.DataSource = table;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditUserForm addEditUserForm = new AddEditUserForm();
            if (addEditUserForm.ShowDialog() == DialogResult.OK)
            {
                readusers();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                Users user = userRepository.GetUserById(userId);
                if (user != null)
                {
                    AddEditUserForm addEditUserForm = new AddEditUserForm();
                    addEditUserForm.EditUser(user);
                    if (addEditUserForm.ShowDialog() == DialogResult.OK)
                    {
                        readusers();
                    }
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
            else
            {
                MessageBox.Show("Please select a user to edit.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                Users user = userRepository.GetUserById(userId);
                if (user != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        userRepository.DeleteUser(userId);
                        readusers();
                    }
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.adminNavigationn.Show();
            this.Close();
        }
    }
}
