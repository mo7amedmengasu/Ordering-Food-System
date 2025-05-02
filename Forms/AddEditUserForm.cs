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
    public partial class AddEditUserForm: Form
    {
        private static string ConnectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        private UserRepository userRepository = new UserRepository(ConnectionString);
        public AddEditUserForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        bool isEditMode = false;
        private void AddEditUserForm_Load(object sender, EventArgs e)
        {

        }


        public void EditUser(Users user)
        {
            this.useridarea.Text = user.UserID.ToString();
            this.firstrnamearea.Text = user.FirstName;
            this.lastnamearea.Text = user.LastName;
            this.emailarea.Text = user.Email;
            this.addressarea.Text = user.UserAddress;
            this.rolearea.Text = user.UserRole;
            this.passwordarea.Text = user.UserPassword;

            this.isEditMode = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            if (this.firstrnamearea.Text.Length == 0)
            {
                MessageBox.Show("please Enter a First Name");
                return;
            }
            if (this.lastnamearea.Text.Length == 0)
            {
                MessageBox.Show("please Enter a Last Name");
                return;
            }
            if (this.emailarea.Text.Length == 0 && this.emailarea.Text.Contains("@"))
            {
                MessageBox.Show("please Enter an Email");
                return;
            }
            if (this.addressarea.Text.Length == 0)
            {
                MessageBox.Show("please Enter an Address");
                return;
            }
            if (this.rolearea.Text.Length == 0)
            {
                MessageBox.Show("please Enter a Role");
                return;
            }
            if (this.passwordarea.Text.Length == 0)
            {
                MessageBox.Show("please Enter a Password");
                return;
            }
            user.FirstName = this.firstrnamearea.Text;
            user.LastName = this.lastnamearea.Text;
            user.Email = this.emailarea.Text;
            user.UserAddress = this.addressarea.Text;
            user.UserRole = this.rolearea.Text;
            user.UserPassword = this.passwordarea.Text;
            if (isEditMode)
            {
                user.UserID = int.Parse(this.useridarea.Text);
                userRepository.UpdateUser(user);
                DialogResult = DialogResult.OK;
            }
            else
            {
                userRepository.AddUser(user);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
