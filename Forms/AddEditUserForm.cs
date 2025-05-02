using Db_Project.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Db_Project.Forms
{
    public partial class AddEditUserForm: Form
    {

        private static string ConnectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        UserRepository userRepository = new UserRepository(ConnectionString);
        public AddEditUserForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
        bool isEditMode = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                this.label1.Text = "Add User";
            }
            else
            {
                this.label1.Text = "Edit User";
            }

            if (this.firstnamearea.Text.Length == 0)
            {
                MessageBox.Show("please Enter a First Name");
                return;
            }
            if (this.lastnamearea.Text.Length == 0)
            {
                MessageBox.Show("please Enter a Last Name");
                return;
            }
            if (this.emailarea.Text.Length == 0)
            {
                MessageBox.Show("please Enter the Email");
                return;
            }
            if (this.addressarea.Text.Length == 0)
            {
                MessageBox.Show("please Enter the Address");
                return;
            }
            if (this.passwordarea.Text.Length == 0)
            {
                MessageBox.Show("please Enter the Password");
                return;
            }

            Users users = new Users();
            users.FirstName = this.firstnamearea.Text;
            users.LastName = this.lastnamearea.Text;
            if(this.emailarea.Text.Contains("@"))
            {
                users.Email = this.emailarea.Text;
            }
            else
            {
                MessageBox.Show("Invalid Email Format");
            }  
            users.UserAddress = this.addressarea.Text;
            users.UserRole = this.rolearea.Text;
            users.UserPassword = this.passwordarea.Text;
            this.useridarea.Enabled = false;

            if (isEditMode)
            {
                users.UserID = Convert.ToInt32(this.useridarea.Text);
                userRepository.UpdateUser(users);
                MessageBox.Show("User Updated Successfully");
            }
            else
            {
                userRepository.AddUser(users);
                MessageBox.Show("User Added Successfully");
            }
            this.DialogResult = DialogResult.OK;

        }
        
        public void EditUser(Users users)
        {
            this.label1.Text = "Edit User";

            if (users != null)
            {
                this.useridarea.Text = users.UserID.ToString();
                this.firstnamearea.Text = users.FirstName;
                this.lastnamearea.Text = users.LastName;
                if(this.emailarea.Text.Contains("@"))
                {
                    this.emailarea.Text = users.Email;
                }
                else
                {
                    MessageBox.Show("Invalid Email Format");
                }
                this.emailarea.Text = users.Email;
                this.addressarea.Text = users.UserAddress;
                this.passwordarea.Text = users.UserPassword;
                this.rolearea.Text = users.UserRole;
                isEditMode = true;
            }
            else
            {
                MessageBox.Show("User Not Found");
            }
            this.useridarea.Enabled = false;
           

            this.rolearea.Enabled = false;



        }

        private void AddEditUserForm_Load(object sender, EventArgs e)
        {

        }

    }
}
