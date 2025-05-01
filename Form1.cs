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
using Db_Project.Repositories;


namespace Db_Project
{
    public partial class Form1 : Form
    {
        string ConnectionString = "Data Source=RENADLAPTOP;Initial Catalog=windb;Integrated Security=True;";


        public Form1()
        {
            InitializeComponent();
           
            read_users();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void read_users()
        {
            try
            {
                UserRepository userRepository = new UserRepository(ConnectionString);
                Users user1 = new Users();
                user1.FirstName = "Renad";
                user1.LastName = "Ibrahim";
                user1.Email = "renadibrahimm@gmail.com";
                user1.UserAddress = "eryhgfagsfdhad";
                user1.UserRole = "admin";
                user1.UserPassword = "123password123.";
                userRepository.AddUser(user1);
                List<Users> users = userRepository.GetAllUsers();

                var table = new DataTable();
                table.Columns.Add("ID");
                table.Columns.Add("First Name");
                table.Columns.Add("Last Name");
                table.Columns.Add("Email");
                table.Columns.Add("Address");
                table.Columns.Add("Role");
                table.Columns.Add("Password");

                foreach (var user in users)
                {
                    var row = table.NewRow();
                    row["ID"] = user.UserID;
                    row["First Name"] = user.FirstName;
                    row["Last Name"] = user.LastName;
                    row["Email"] = user.Email;
                    row["Address"] = user.UserAddress;
                    row["Role"] = user.UserRole;
                    row["Password"] = user.UserPassword;
                    table.Rows.Add(row);
                }
                dataGridView1.DataSource = table;

            

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ex.StackTrace);
                

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
