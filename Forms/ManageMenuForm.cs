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
using Db_Project.models;
using Db_Project.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Db_Project.Forms
{
    public partial class ManageMenuForm: Form
    {
        private static string ConnectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        private MenuItemRepository menuItemRepository = new MenuItemRepository(ConnectionString);
        private AdminNavigationn adminNavigationn;
        public ManageMenuForm(AdminNavigationn adminNavigationn)
        {
            InitializeComponent();
            ReadItems();
            this.adminNavigationn = adminNavigationn;
        }

        private void ReadItems()
        {
            List<MenuItem1> menuItems = menuItemRepository.GetAllMenuItems();

            var table = new DataTable();
            table.Columns.Add("ItemID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Availability", typeof(bool));
            table.Columns.Add("Price", typeof(decimal));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("RestaurantID", typeof(int));
            foreach (var item in menuItems)
            {
                table.Rows.Add(item.ItemID, item.Name, item.Availability, item.Price, item.Description, item.RestaurantID);
            }
            dataGridView1.DataSource = table;
        }

        private void ManageMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm();
            if (addEditForm.ShowDialog() == DialogResult.OK)
            {
                ReadItems();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            MenuItemRepository menuItemRepository = new MenuItemRepository(ConnectionString);
            MenuItem1 menuItem = menuItemRepository.GetMenuItemById(id);

            if (menuItem != null)
            {
                AddEditForm addEditForm = new AddEditForm();
                addEditForm.editmenuItem(menuItem);
                if (addEditForm.ShowDialog() == DialogResult.OK)
                {
                    ReadItems();
                }
            }
            else
            {
                MessageBox.Show("Menu item not found.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            DialogResult dialogresult = MessageBox.Show("are you sure you want to delete this menu item?", "Delete Menu Item", MessageBoxButtons.YesNo);
            if (dialogresult == DialogResult.Yes)
            {
                menuItemRepository.DeleteMenuItem(id);
                this.DialogResult = DialogResult.Cancel;
            }
            ReadItems();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            adminNavigationn.Show();
        }
    }
}
