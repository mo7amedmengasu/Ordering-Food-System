using Db_Project.models;
using Db_Project.Repositories;
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
    public partial class AddEditForm: Form
    {
        private static string ConnectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        MenuItemRepository menuItemRepository = new MenuItemRepository(ConnectionString);
        public AddEditForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {

        }
        private bool isEditMode = false;
       
        private void button1_Click(object sender, EventArgs e)
        {
            if(this.namearea.Text.Length == 0)
            {
                MessageBox.Show("please Enter a Name");
                return;
            }
            if (this.availabilitybox.Text.Length == 0) {
                MessageBox.Show("please Choose the Availability status");
                return;
            }
            if(this.pricearea.Text.Length == 0)
            {
                MessageBox.Show("please Enter the price");
                return;
            }
            if (this.descriptionarea.Text.Length == 0) {
                MessageBox.Show("please Enter the discription");
                return;
            }
            if (this.restidarea.Text.Length == 0) {
                MessageBox.Show("please Enter Restauarant ID");
                return;
            }

            MenuItem1 menuItem = new MenuItem1
            {
                ItemID = this.isEditMode ? int.Parse(this.IdArea.Text) : 0, // Ensure ItemID is set in edit mode
                Name = this.namearea.Text,
                Price = decimal.Parse(this.pricearea.Text),
                Description = this.descriptionarea.Text,
                RestaurantID = int.Parse(this.restidarea.Text),
                Availability = this.availabilitybox.Text == "Available"
            };

            if (this.isEditMode)
            {
                menuItemRepository.UpdateMenuItem(menuItem);
                MessageBox.Show("Menu item updated successfully.");
            }
            else
            {
                menuItemRepository.AddMenuItem(menuItem);
                MessageBox.Show("Menu item added successfully.");
            }
            this.DialogResult = DialogResult.OK;

        }
        public void editmenuItem(MenuItem1 item)
        {
            this.IdArea.Text = item.ItemID.ToString();
            this.namearea.Text = item.Name;
            if(item.Availability == true)
            {
                this.availabilitybox.Text = "Available";
            }
            else
            {
                this.availabilitybox.Text = "Not Available";
            }
            this.pricearea.Text = item.Price.ToString();
            this.descriptionarea.Text = item.Description;
            this.restidarea.Text = item.RestaurantID.ToString();
            this.isEditMode = true;
            this.IdArea.Enabled = false;

        }
       
    }
}
