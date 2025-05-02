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
    public partial class MangeUserForm: Form
    {
        private static string ConnectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        UserRepository userRepository = new UserRepository(ConnectionString);
        public MangeUserForm()
        {
            InitializeComponent();
            readusers();
        }

        private void MangeUserForm_Load(object sender, EventArgs e)
        {

        }
        private void readusers()
        {
            List<Users> users = userRepository.GetAllCustomers();

            var table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("Role", typeof(string));
            table.Columns.Add("Password", typeof(string));

            foreach (var user in users)
            {
                table.Rows.Add(user.UserID, user.FirstName, user.LastName, user.Email, user.UserAddress, user.UserRole, user.UserPassword);
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
            int userid = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            Users user = userRepository.GetUserById(userid);
            if (user != null) {
                AddEditUserForm addEditUserForm = new AddEditUserForm();
                addEditUserForm.EditUser(user);
                if (addEditUserForm.ShowDialog() == DialogResult.OK)
                {
                    readusers();
                }
            }
            else
            {
                MessageBox.Show("User Not Found");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int userid = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            userRepository.DeleteUser(userid);
            readusers();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                int userid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                userRepository.DeleteUser(userid);
                readusers();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
