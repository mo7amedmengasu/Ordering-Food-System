using Db_Project.models;
using Db_Project.Repositories;
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
        private static string ConnectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        private MenuItemRepository menuItemRepository = new MenuItemRepository(ConnectionString);
        private OrderRepository orderRepository = new OrderRepository(ConnectionString);
        private OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository(ConnectionString);






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

            List<MenuItem1> menuItems = menuItemRepository.GetMenuItemsByRestaurant(restaurantId);
            menuGrid.DataSource = menuItems;

            // Set all columns except Quantity to read-only
            foreach (DataGridViewColumn col in menuGrid.Columns)
            {
                col.ReadOnly = true;
            }

            // Add Quantity column if not already present
            if (!menuGrid.Columns.Contains("Quantity"))
            {
                DataGridViewTextBoxColumn qtyColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "Quantity",
                    ValueType = typeof(int)
                };
                menuGrid.Columns.Add(qtyColumn);
            }

            menuGrid.Columns["Quantity"].ReadOnly = false;

            // Add AddToCart button if not already present
            if (!menuGrid.Columns.Contains("AddToCart"))
            {
                DataGridViewButtonColumn addButton = new DataGridViewButtonColumn
                {
                    HeaderText = "Action",
                    Text = "Add to Cart",
                    Name = "AddToCart",
                    UseColumnTextForButtonValue = true
                };
                menuGrid.Columns.Add(addButton);
            }

            // Ensure the AddToCart button works
            menuGrid.CellContentClick -= MenuGrid_CellContentClick; // Avoid double subscription
            menuGrid.CellContentClick += MenuGrid_CellContentClick;

            menuGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            menuGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            menuGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            menuGrid.ReadOnly = false;
        }





        Dictionary<int, int> itemQuantities = new Dictionary<int, int>();
        List<int>existingItems = new List<int>();
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

                //cartItems.Add((itemId, itemName, price, quantity));
                if(!existingItems.Contains(itemId))
                {
                    existingItems.Add(itemId);
                    itemQuantities[itemId] = quantity;

                }
                else
                {
                    itemQuantities[itemId] += quantity;

                }
                   

                UpdateCartDisplay();

                MessageBox.Show($"{quantity} x {itemName} added to cart.");
            }
        }

        private void UpdateCartDisplay()
        {
            cartListView.Items.Clear();
            decimal total = 0;

            foreach (int idx in existingItems)
            {
                MenuItem1 item = menuItemRepository.GetMenuItemById(idx);
                decimal subtotal = item.Price * itemQuantities[idx];

                var listItem = new ListViewItem(item.Name);
                listItem.SubItems.Add(itemQuantities[idx].ToString());
                listItem.SubItems.Add(subtotal.ToString("C"));

                cartListView.Items.Add(listItem);
                total += subtotal;
            }

            lblTotalAmount.Text = $"Total: {total:C}";


        }



        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (existingItems == null || existingItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty.");
                return;
            }


            int orderId = SaveOrderToDatabase();
            if (orderId > 0)
            {
                decimal total = orderDetailsRepository.GetOrderTotal(orderId);
                lblTotalAmount.Text = $"Total: {total:C}";
                MessageBox.Show($"Order placed! Total: {total:C}");

               
                PaymentForm paymentForm = new PaymentForm(orderId, loggedInUser.UserID);
                paymentForm.ShowDialog();

                // Reset cart
                UpdateCartDisplay();
                existingItems.Clear();
                itemQuantities.Clear();
                cartListView.Items.Clear();
                lblTotalAmount.Text = "Total: $0.00";
            }
            else
            {
                MessageBox.Show("Failed to place the order.");
            }

        }






        /*private decimal CalculateOrderTotal(int orderId)
        {
            decimal total = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT SUM(Subtotal) FROM OrderDetails WHERE OrderID = @orderId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@orderId", orderId);

                try
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        total = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error calculating total: " + ex.Message);
                }

            }

            return total;
        }*/

        private int SaveOrderToDatabase()
        {


            try
            {
                Order order = new Order();
                // Set other order properties
                order.RestaurantID = restaurantId;
                order.CustomerID = loggedInUser.UserID;
                order.Status = "Pending";
                order.OrderDate = DateTime.Now;

                // Add the order and retrieve the auto-generated OrderID
                int newOrderId=orderRepository.AddOrder(order);
                MessageBox.Show("Order created successfully with ID: " + order.OrderID);
                


                
                /*foreach (int item in existingItems)
                {
                    itemQuantities[item]++;
                    
                }*/

                foreach(var idx in existingItems)
                {
                    OrderDetails orderDetail = new OrderDetails
                    {
                        OrderID = order.OrderID,
                        ItemID = idx,
                        Quantity = itemQuantities[idx],
                        Subtotal = menuItemRepository.GetMenuItemById(idx).Price * itemQuantities[idx]
                    };
                    orderDetailsRepository.AddOrderDetail(orderDetail);
                }



                return order.OrderID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving order: " + ex.ToString());
                return -1;
            }

        }

        private void lblTotalAmount_Click(object sender, EventArgs e)
        {

        }
    }
    }



    /*using (SqlConnection connection = new SqlConnection(ConnectionString))
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
        }*/



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








