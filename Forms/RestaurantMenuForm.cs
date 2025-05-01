using Db_Project.models;
using Db_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Db_Project.Forms
{
    public partial class RestaurantMenuForm : Form
    {
        private readonly int _restaurantId;
        private readonly MenuItemRepository _menuItemRepo;
        private MenuItem1 selectedItem = null;
        string connectionString = "Data Source=DESKTOP-A188VPF;Initial Catalog=WinDB;Integrated Security=True;";

        public RestaurantMenuForm(int restaurantId)
        {
            InitializeComponent();
            _restaurantId = restaurantId;
            _menuItemRepo = new MenuItemRepository(connectionString);
            LoadMenuItems();
        }

        private void LoadMenuItems()
        {
            flowLayoutPanel1.Controls.Clear();
            List<MenuItem1> menuItems = _menuItemRepo.GetAvailableMenuItems(_restaurantId);

            foreach (var item in menuItems)
            {
                Panel panel = new Panel
                {
                    Width = 300,
                    Height = 140,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    BackColor = Color.White
                };

                Label lbl = new Label
                {
                    Text = $"{item.Name} - ${item.Price:F2}\n{item.Description}\nAvailable: {item.Availability}",
                    AutoSize = false,
                    Size = new Size(280, 80),
                    Location = new Point(10, 10)
                };

                Button selectBtn = new Button
                {
                    Text = "Select",
                    Width = 100,
                    Location = new Point(10, 90)
                };
                selectBtn.Click += (s, e) =>
                {
                    selectedItem = item;
                    txtName.Text = item.Name;
                    txtDescription.Text = item.Description;
                    txtPrice.Text = item.Price.ToString();
                    chkAvailable.Checked = item.Availability;
                };

                panel.Controls.Add(lbl);
                panel.Controls.Add(selectBtn);
                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var item = new MenuItem1
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text),
                Availability = chkAvailable.Checked,
                RestaurantID = _restaurantId
            };

            _menuItemRepo.AddMenuItem(item);
            LoadMenuItems();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedItem == null) return;

            selectedItem.Name = txtName.Text;
            selectedItem.Description = txtDescription.Text;
            selectedItem.Price = decimal.Parse(txtPrice.Text);
            selectedItem.Availability = chkAvailable.Checked;

            _menuItemRepo.UpdateMenuItem(selectedItem);
            LoadMenuItems();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedItem == null) return;

            _menuItemRepo.DeleteMenuItem(selectedItem.ItemID);
            LoadMenuItems();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (selectedItem == null) return;

            bool newAvailability = !selectedItem.Availability;
            _menuItemRepo.UpdateAvailability(selectedItem.ItemID, newAvailability);
            LoadMenuItems();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMenuItems();
        }
    }
}
