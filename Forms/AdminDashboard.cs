using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Db_Project.Forms
{
    public partial class AdminDashboard : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        private const int EM_SETCUEBANNER = 0x1501;
        string ConnectionString = "Data Source=RENADLAPTOP;Initial Catalog=windb;Integrated Security=True;";
        public AdminDashboard()
        {
            InitializeComponent();
            LoadRestaurantsForAdmin();
            LoadActiveOrders();
            SendMessage(txtRestaurantName.Handle, EM_SETCUEBANNER, 0, "Enter restaurant name");
            SendMessage(txtAddress.Handle, EM_SETCUEBANNER, 0, "Enter restaurant address");
            SendMessage(txtPhone.Handle, EM_SETCUEBANNER, 0, "Enter the restaurant's phone number");
            SendMessage(txtRating.Handle, EM_SETCUEBANNER, 0, "Enter the restaurant's rating");
            adminRestaurantGrid.SelectionChanged += adminRestaurantGrid_SelectionChanged;



        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void LoadRestaurantsForAdmin()
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "Select * from Restaurant";
                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);
                adminRestaurantGrid.DataSource = table;
            }
        }

        private void LoadActiveOrders()
        {
            using(SqlConnection connection= new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "Select * from [Order]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                adminOrdersGrid.DataSource = table;
            }
        }

       
        

        private void btnAddRestaurant_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                

                try
                {
                    
                    string insertRestaurant = "INSERT INTO Restaurant (Name) OUTPUT INSERTED.RestaurantID VALUES (@Name)";
                    SqlCommand cmdRestaurant = new SqlCommand(insertRestaurant, connection);
                    cmdRestaurant.Parameters.AddWithValue("@Name", txtRestaurantName.Text);
                    cmdRestaurant.ExecuteNonQuery();
                    MessageBox.Show("Restaurant added successfully!");
                    LoadRestaurantsForAdmin();
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDeleteRestaurant_Click(object sender, EventArgs e)
        {

            if (adminRestaurantGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a restaurant to delete.");


            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this restaurant?", "Confirm Deletion", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = adminRestaurantGrid.SelectedRows[0];
                    int restaurantId = Convert.ToInt32(selectedRow.Cells["RestaurantId"].Value);
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        string query = "delete from Restaurant where RestaurantID = @RestaurantId ";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@RestaurantId", restaurantId);
                        command.ExecuteNonQuery();

                    }
                    LoadRestaurantsForAdmin();
                }
            }

        }

        private void btnUpdateRestaurant_Click(object sender, EventArgs e)
        {
            if (adminRestaurantGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a restaurant to update.");
                return;
            }

            // Confirm the update
            DialogResult result = MessageBox.Show("Are you sure you want to apply these changes?", "Confirm Update", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            DataGridViewRow selectedRow = adminRestaurantGrid.SelectedRows[0];
            int restaurantId = Convert.ToInt32(selectedRow.Cells["RestaurantId"].Value);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    bool changesMade = false;

                    // Update restaurant name if it's not empty
                    if (!string.IsNullOrWhiteSpace(txtRestaurantName.Text))
                    {
                        string updateName = "UPDATE Restaurant SET Name = @Name WHERE RestaurantId = @RestaurantId";
                        SqlCommand cmdUpdateName = new SqlCommand(updateName, connection, transaction);
                        cmdUpdateName.Parameters.AddWithValue("@Name", txtRestaurantName.Text);
                        cmdUpdateName.Parameters.AddWithValue("@RestaurantId", restaurantId);
                        cmdUpdateName.ExecuteNonQuery();
                        changesMade = true;

                        
                    }
                    if (!string.IsNullOrWhiteSpace(txtRating.Text) && decimal.TryParse(txtRating.Text, out decimal rating))
                    {
                        string updateRating = "UPDATE Restaurant SET Rating = @Rating WHERE RestaurantId = @RestaurantId";
                        SqlCommand cmdUpdateRating = new SqlCommand(updateRating, connection, transaction);
                        cmdUpdateRating.Parameters.AddWithValue("@Rating", rating);
                        cmdUpdateRating.Parameters.AddWithValue("@RestaurantId", restaurantId);
                        cmdUpdateRating.ExecuteNonQuery();
                        changesMade = true;
                    }

                    // If no changes were made, notify the user
                    if (!changesMade)
                    {
                        MessageBox.Show("No changes were made.");
                        return;
                    }

                    // Commit transaction
                    transaction.Commit();

                    MessageBox.Show("Changes saved successfully.");
                    LoadRestaurantsForAdmin(); // Refresh the restaurant list
                }
                catch (Exception ex)
                {
                    // Rollback transaction if an error occurs
                    transaction.Rollback();
                    MessageBox.Show("Update failed: " + ex.Message);
                }
            }
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {

            if (adminRestaurantGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a restaurant first");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                
                DataGridViewRow selectedRow = adminRestaurantGrid.SelectedRows[0];
                int restaurantId = Convert.ToInt32(selectedRow.Cells["RestaurantID"].Value);

                
                lstAddresses.Items.Add(txtAddress.Text);

               
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    
                    string insertAddressQuery = "INSERT INTO RestaurantAddress (RestaurantID, Address) VALUES (@restaurantId, @AddressText)";
                    SqlCommand cmd = new SqlCommand(insertAddressQuery, connection);
                    cmd.Parameters.AddWithValue("@restaurantId", restaurantId);
                    cmd.Parameters.AddWithValue("@AddressText", txtAddress.Text);

                    
                    cmd.ExecuteNonQuery();
                }

                
                txtAddress.Clear();
                MessageBox.Show("Address added successfully!");

               
                LoadRestaurantDetails(restaurantId);
            }
            else
            {
                MessageBox.Show("Please enter a valid address.");
            }
        }

        private void btnRemoveAddress_Click(object sender, EventArgs e)
        {
            if (lstAddresses.SelectedItem != null)
            {
                // Get the selected address from the ListBox
                string selectedAddress = lstAddresses.SelectedItem.ToString();

                // Get the selected restaurant ID from the DataGridView
                if (adminRestaurantGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a restaurant first.");
                    return; // Exit if no restaurant is selected
                }

                DataGridViewRow selectedRow = adminRestaurantGrid.SelectedRows[0];
                int restaurantId = Convert.ToInt32(selectedRow.Cells["RestaurantID"].Value);

                // Remove the selected address from the ListBox
                lstAddresses.Items.Remove(lstAddresses.SelectedItem);

                // Remove the address from the database
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // SQL query to remove the address from the RestaurantAddress table
                    string deleteAddressQuery = "DELETE FROM RestaurantAddress WHERE RestaurantID = @RestaurantId AND Address = @Address";
                    SqlCommand cmd = new SqlCommand(deleteAddressQuery, connection);
                    cmd.Parameters.AddWithValue("@RestaurantId", restaurantId);
                    cmd.Parameters.AddWithValue("@Address", selectedAddress);

                    // Execute the query to delete the address from the database
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Address removed successfully!");

                // Optionally, reload the updated addresses for the selected restaurant
                LoadRestaurantDetails(restaurantId);
            }
            else
            {
                MessageBox.Show("Please select an address to remove.");
            }
        }


        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            if (adminRestaurantGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a restaurant first.");
                return; // Exit the method if no row is selected
            }

            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                // Get the selected restaurant ID from the DataGridView
                DataGridViewRow selectedRow = adminRestaurantGrid.SelectedRows[0];
                int restaurantId = Convert.ToInt32(selectedRow.Cells["RestaurantID"].Value);

                // Add phone number to the ListBox temporarily (for display purposes)
                lstPhones.Items.Add(txtPhone.Text);

                // Save the phone number to the database
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // SQL query to insert the new phone number into the PhoneNumber table
                    string insertPhoneQuery = "INSERT INTO RestaurantPhone (RestaurantID, Phone) VALUES (@restaurantId, @PhoneNumber)";
                    SqlCommand cmd = new SqlCommand(insertPhoneQuery, connection);
                    cmd.Parameters.AddWithValue("@restaurantId", restaurantId);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);

                    // Execute the query to insert the phone number
                    cmd.ExecuteNonQuery();
                }

                // Clear the input field
                txtPhone.Clear();
                MessageBox.Show("Phone number added successfully!");

                // Optionally, reload the updated phone numbers for the selected restaurant
                LoadRestaurantDetails(restaurantId);
            }
            else
            {
                MessageBox.Show("Please enter a valid phone number.");
            }
        }

        private void btnRemovePhone_Click(object sender, EventArgs e)
        {
            if (lstPhones.SelectedItem != null)
            {
                string selectedPhone = lstPhones.SelectedItem.ToString();

                // Get the selected restaurant's ID from the DataGridView
                if (adminRestaurantGrid.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = adminRestaurantGrid.SelectedRows[0];
                    int restaurantId = Convert.ToInt32(selectedRow.Cells["RestaurantID"].Value);

                    // Remove the phone number from the ListBox
                    lstPhones.Items.Remove(lstPhones.SelectedItem);

                    // Remove the phone number from the database
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        string deletePhoneQuery = "DELETE FROM RestaurantPhone WHERE RestaurantID = @RestaurantID AND Phone = @PhoneNumber";
                        SqlCommand cmd = new SqlCommand(deletePhoneQuery, connection);
                        cmd.Parameters.AddWithValue("@RestaurantID", restaurantId);
                        cmd.Parameters.AddWithValue("@PhoneNumber", selectedPhone);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Phone number removed successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a restaurant first.");
                }
            }
            else
            {
                MessageBox.Show("Please select a phone number to remove.");
            }
        }

        private void LoadRestaurantDetails(int restaurantId)
        {
            lstAddresses.Items.Clear();
            lstPhones.Items.Clear();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                
                string queryAddress = "SELECT Address FROM RestaurantAddress WHERE RestaurantID = @RestaurantId";
                SqlCommand cmdAddress = new SqlCommand(queryAddress, connection);
                cmdAddress.Parameters.AddWithValue("@RestaurantId", restaurantId);
                SqlDataReader readerAddress = cmdAddress.ExecuteReader();
                while (readerAddress.Read())
                {
                    lstAddresses.Items.Add(readerAddress["Address"].ToString());  
                }
                readerAddress.Close();

               
                string queryPhone = "SELECT Phone FROM RestaurantPhone WHERE RestaurantID = @RestaurantId";
                SqlCommand cmdPhone = new SqlCommand(queryPhone, connection);
                cmdPhone.Parameters.AddWithValue("@RestaurantId", restaurantId);
                SqlDataReader readerPhone = cmdPhone.ExecuteReader();
                while (readerPhone.Read())
                {
                    lstPhones.Items.Add(readerPhone["Phone"].ToString()); 
                }
                readerPhone.Close();
            }
        }


        private void adminRestaurantGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (adminRestaurantGrid.SelectedRows.Count > 0)
            {
                // Get the selected restaurant's ID
                DataGridViewRow selectedRow = adminRestaurantGrid.SelectedRows[0];
                int restaurantId = Convert.ToInt32(selectedRow.Cells["RestaurantId"].Value);

                // Load addresses and phone numbers for the selected restaurant
                LoadRestaurantDetails(restaurantId);
            }
        }






    }
}
