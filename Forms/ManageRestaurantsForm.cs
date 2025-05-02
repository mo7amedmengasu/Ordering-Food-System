using Db_Project.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db_Project.models;

namespace Db_Project.Forms
{
    public partial class ManageRestaurantsForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private static string ConnectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        private RestaurantRepository restaurantRepository = new RestaurantRepository(ConnectionString);
        private RestaurantAddressRepository restaurantAddressRepository = new RestaurantAddressRepository(ConnectionString);
        private RestaurantPhoneRepository restaurantPhoneRepository = new RestaurantPhoneRepository(ConnectionString);
        private const int EM_SETCUEBANNER = 0x1501;
        private AdminNavigationn adminNavigationn;
        public ManageRestaurantsForm(AdminNavigationn adminNavigationn)
        {
            InitializeComponent();
            LoadRestaurants();
            SendMessage(txtName.Handle, EM_SETCUEBANNER, 0, "Enter restaurant name");
            SendMessage(txtAddress.Handle, EM_SETCUEBANNER, 0, "Enter restaurant address");
            SendMessage(txtPhone.Handle, EM_SETCUEBANNER, 0, "Enter the restaurant's phone number");
            SendMessage(txtRating.Handle, EM_SETCUEBANNER, 0, "Enter the restaurant's rating");
            this.adminNavigationn = adminNavigationn;
        }

        private void ManageRestaurantsForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadRestaurants()
        {
            List<Restaurant> restaurants = restaurantRepository.GetAllRestaurants();
            restaurantGrid.DataSource = restaurants;

            restaurantGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void btnAddRestaurant_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string rating = txtRating.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(rating))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            Restaurant restaurant = new Restaurant
            {
                Name = name,
                Rating = Convert.ToDecimal(rating)
            };
            restaurantRepository.AddRestaurant(restaurant);
            MessageBox.Show("Restaurant added successfully.");
            ClearFields();
        }
        private void btnDeleteRestaurant_Click(object sender, EventArgs e)
        {
            if (restaurantGrid.SelectedRows.Count > 0)
            {
                int restaurantId = Convert.ToInt32(restaurantGrid.SelectedRows[0].Cells["RestaurantID"].Value);
                restaurantRepository.DeleteRestaurant(restaurantId);
                MessageBox.Show("Restaurant deleted successfully.");
                LoadRestaurants();
            }
            else
            {
                MessageBox.Show("Please select a restaurant to delete.");
            }
        }
        private void ClearFields()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }
        private void restaurantGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (restaurantGrid.SelectedRows.Count > 0)
            {
                int selectedRestaurantId = Convert.ToInt32(restaurantGrid.SelectedRows[0].Cells["RestaurantID"].Value);
                LoadRestaurantDetails(selectedRestaurantId);
            }
        }
        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            if (restaurantGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a restaurant first");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                // Get the selected restaurant ID
                DataGridViewRow selectedRow = restaurantGrid.SelectedRows[0];
                int restaurantId = Convert.ToInt32(selectedRow.Cells["RestaurantID"].Value);

                // Add the address to the ListView
                lstAddresses.Items.Add(txtAddress.Text);

                // Create the RestaurantAddress object with the address and restaurant ID
                RestaurantAddress newAddress = new RestaurantAddress
                {
                    RestaurantID = restaurantId,
                    Address = txtAddress.Text
                };

                // Insert the new address into the database
                restaurantAddressRepository.Insert(newAddress);

                // Clear the address input field and show a success message
                txtAddress.Clear();
                MessageBox.Show("Address added successfully!");

                // Reload the restaurant details to update the UI
                LoadRestaurantDetails(restaurantId);
            }
            else
            {
                MessageBox.Show("Please enter a valid address.");
            }
        }

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            if (restaurantGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a restaurant first");
                return;
            }

            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(phone) || phone.Length != 11 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Please enter a valid 11-digit phone number.");
                return;
            }

            DataGridViewRow selectedRow = restaurantGrid.SelectedRows[0];
            int restaurantId = Convert.ToInt32(selectedRow.Cells["RestaurantID"].Value);

            lstPhones.Items.Add(phone);

            RestaurantPhone newPhone = new RestaurantPhone
            {
                RestaurantID = restaurantId,
                Phone = phone
            };

            restaurantPhoneRepository.AddPhone(newPhone);

            txtPhone.Clear();
            MessageBox.Show("Phone number added successfully!");
            LoadRestaurantDetails(restaurantId);
        }

        private void LoadRestaurantDetails(int restaurantId)
        {
            lstAddresses.Items.Clear();
            lstPhones.Items.Clear();

            List<RestaurantAddress> addresses = restaurantAddressRepository.GetByRestaurantId(restaurantId);
            foreach (var addr in addresses)
            {
                if (!string.IsNullOrWhiteSpace(addr.Address))
                {
                    lstAddresses.Items.Add(addr.Address);
                }
            }

            List<RestaurantPhone> phones = restaurantPhoneRepository.GetPhonesByRestaurant(restaurantId);
            foreach (var phone in phones)
            {
                if (!string.IsNullOrWhiteSpace(phone.Phone))
                {
                    lstPhones.Items.Add(phone.Phone);
                }
            }


        }
        private void btnDeleteAddress_Click(object sender, EventArgs e)
        {
            if (lstAddresses.SelectedItem != null)
            {
                string selectedAddress = lstAddresses.SelectedItem.ToString();

                if (restaurantGrid.SelectedRows.Count > 0)
                {
                    int restaurantId = Convert.ToInt32(restaurantGrid.SelectedRows[0].Cells["RestaurantID"].Value);

                    // Remove from ListBox
                    lstAddresses.Items.Remove(selectedAddress);

                    // Delete from database
                    restaurantAddressRepository.DeleteByAddressAndId(restaurantId, selectedAddress);

                    MessageBox.Show("Address deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a restaurant first.");
                }
            }
            else
            {
                MessageBox.Show("Please select an address to delete.");
            }
        }


        private int GetRestaurantIdFromSelectedItem(ListViewItem selectedItem)
        {
            // Assuming the RestaurantID is stored in the second column (index 1)
            int restaurantId = Convert.ToInt32(selectedItem.SubItems[1].Text);
            return restaurantId;
        }

        private void btnDeletePhone_Click(object sender, EventArgs e)
        {
            if (lstPhones.SelectedItem != null)
            {
                string selectedPhone = lstPhones.SelectedItem.ToString();

                if (restaurantGrid.SelectedRows.Count > 0)
                {
                    int restaurantId = Convert.ToInt32(restaurantGrid.SelectedRows[0].Cells["RestaurantID"].Value);

                    // Remove from ListBox
                    lstPhones.Items.Remove(selectedPhone);

                    // Delete from database
                    restaurantPhoneRepository.DeleteByPhoneAndId(restaurantId, selectedPhone);

                    MessageBox.Show("Phone number deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a restaurant first.");
                }
            }
            else
            {
                MessageBox.Show("Please select a phone number to delete.");
            }
        }
        private void btnUpdateRestaurant_Click(object sender, EventArgs e)
        {
            if (restaurantGrid.SelectedRows.Count > 0)
            {
                int restaurantId = Convert.ToInt32(restaurantGrid.SelectedRows[0].Cells["RestaurantID"].Value);

                string name = string.IsNullOrWhiteSpace(txtName.Text) ? null : txtName.Text;
                decimal? rating = null;

                if (!string.IsNullOrWhiteSpace(txtRating.Text))
                {
                    if (decimal.TryParse(txtRating.Text, out decimal parsedRating))
                    {
                        rating = parsedRating;
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid rating.");
                        return;
                    }
                }

                if (name == null && rating == null)
                {
                    MessageBox.Show("Please enter a name or rating to update.");
                    return;
                }

                restaurantRepository.UpdateRestaurant(restaurantId, name, rating);
                MessageBox.Show("Restaurant updated successfully.");
                LoadRestaurants();
            }
            else
            {
                MessageBox.Show("Please select a restaurant to update.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate back to the admin navigation form
            this.Close();
            adminNavigationn.Show();
        }
    }
}
