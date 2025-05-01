using Db_Project.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Db_Project.Forms
{
    public partial class MenuItemsForm : Form

    {
        
        private int restaurantId;
        private Users loggedInUser;
  
        

        //private List<DataRow> cartItems = new List<DataRow>();

        string ConnectionString = "Data Source=RENADLAPTOP;Initial Catalog=windb;Integrated Security=True;";
        public MenuItemsForm(int restaurantId, Users user)
        {
            this.restaurantId = restaurantId;
            this.loggedInUser = user ?? throw new ArgumentNullException(nameof(user));
            InitializeComponent();
            LoadMenuItems();

            //menuGrid.CellValidating += menuGrid_CellValidating;
        }

        private void MenuItemsForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadMenuItems()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT ItemID, Name, Availability, Price, Description FROM MenuItem WHERE RestaurantID = @RestaurantId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RestaurantId", restaurantId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (!menuGrid.Columns.Contains("Quantity"))
                {
                    DataGridViewTextBoxColumn qtyColumn = new DataGridViewTextBoxColumn();
                    qtyColumn.Name = "Quantity";
                    qtyColumn.HeaderText = "Quantity";
                    qtyColumn.ValueType = typeof(int);
                    menuGrid.Columns.Add(qtyColumn);
                    menuGrid.Columns["Quantity"].ReadOnly = false;
                }
                foreach (DataGridViewColumn col in menuGrid.Columns)
                {
                    if (col.Name != "Quantity")
                        col.ReadOnly = true;
                }


                menuGrid.ReadOnly = false;

                menuGrid.DataSource = table;
                menuGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                menuGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                menuGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

               

                if (!menuGrid.Columns.Contains("AddToCart"))
                {
                    DataGridViewButtonColumn addButton = new DataGridViewButtonColumn();
                    addButton.HeaderText = "Action";
                    addButton.Text = "Add to Cart";
                    addButton.Name = "AddToCart";
                    addButton.UseColumnTextForButtonValue = true;
                    menuGrid.Columns.Add(addButton);
                }

                // Add click event handler for Add to Cart button
                menuGrid.CellContentClick += MenuGrid_CellContentClick;
                menuGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private List<(int ItemID, string Name, decimal Price, int Quantity)> cartItems = new List<(int, string, decimal, int)>();
        private void MenuGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == menuGrid.Columns["AddToCart"].Index && e.RowIndex >= 0)
            {
                var selectedRow = menuGrid.Rows[e.RowIndex];

                
                if (selectedRow.Cells["Quantity"].Value == null ||
                    !int.TryParse(selectedRow.Cells["Quantity"].Value.ToString(), out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.");
                    return;
                }

                int itemId = Convert.ToInt32(selectedRow.Cells["ItemID"].Value);
                string itemName = selectedRow.Cells["Name"].Value.ToString();
                decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);

                cartItems.Add((itemId, itemName, price, quantity));

                UpdateCartDisplay();

                MessageBox.Show($"{quantity} x {itemName} added to cart.");
            }
        }

        private void UpdateCartDisplay()
        {
            cartListView.Items.Clear();
            decimal total = 0;

            foreach (var item in cartItems)
            {
                decimal subtotal = item.Price * item.Quantity;

                var listItem = new ListViewItem(item.Name);
                listItem.SubItems.Add(item.Quantity.ToString());
                listItem.SubItems.Add(subtotal.ToString("C"));

                cartListView.Items.Add(listItem);
                total += subtotal;
            }

            lblTotalAmount.Text = $"Total: {total:C}";
        }

        

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cartItems == null || cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty.");
                return;
            }

            int orderId = SaveOrderToDatabase(); 

            if (orderId > 0)
            {
                decimal total = CalculateOrderTotal(orderId);
                MessageBox.Show($"Order placed! Total: {total:C}");
                cartItems.Clear();
                UpdateCartDisplay();
            }
            else
            {
                MessageBox.Show("Failed to place the order.");
            }
        }

        private decimal CalculateOrderTotal(int orderId)
        {
            decimal total = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT SUM(Price * Quantity) FROM OrderDetails WHERE OrderID = @orderId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@orderId", orderId);

                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    total = Convert.ToDecimal(result);
                }
            }

            return total;
        }

        private int SaveOrderToDatabase()
        {
            int newOrderId = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 1. Insert into Orders
                    string insertOrderQuery = "INSERT INTO [Order] (UserId, RestaurantId, OrderDate) OUTPUT INSERTED.OrderId VALUES (@userId, @restaurantId, @orderDate)";
                    SqlCommand orderCmd = new SqlCommand(insertOrderQuery, connection, transaction);
                    orderCmd.Parameters.AddWithValue("@userId", loggedInUser.UserID); // assuming loggedInUser is defined
                    orderCmd.Parameters.AddWithValue("@restaurantId", restaurantId);
                    orderCmd.Parameters.AddWithValue("@orderDate", DateTime.Now);

                    newOrderId = (int)orderCmd.ExecuteScalar();

                    // 2. Insert into OrderDetails
                    foreach (var item in cartItems)
                    {
                        string insertDetailsQuery = "INSERT INTO OrderDetails (OrderID, ItemID, Quantity, Price) VALUES (@orderId, @itemId, @quantity, @price)";
                        SqlCommand detailsCmd = new SqlCommand(insertDetailsQuery, connection, transaction);
                        detailsCmd.Parameters.AddWithValue("@orderId", newOrderId);
                        detailsCmd.Parameters.AddWithValue("@itemId", item.ItemID);
                        detailsCmd.Parameters.AddWithValue("@quantity", item.Quantity);
                        detailsCmd.Parameters.AddWithValue("@price", item.Price); // save unit price

                        detailsCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Failed to save order: " + ex.Message);
                    newOrderId = -1;
                }
            }

            return newOrderId;
        }






        /*private void menuGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (menuGrid.Columns[e.ColumnIndex].Name == "Quantity")
            {
                string input = e.FormattedValue?.ToString();
                if (!int.TryParse(input, out int qty) || qty <= 0)
                {
                    e.Cancel = true;
                    menuGrid.Rows[e.RowIndex].ErrorText = "Quantity must be a positive number.";
                }
                else
                {
                    menuGrid.Rows[e.RowIndex].ErrorText = "";
                }
            }
        }*/






    }
}
