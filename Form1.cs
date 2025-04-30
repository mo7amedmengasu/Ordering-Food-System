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
        string ConnectionString = "Data Source=LAPTOP-6DMMQEEO;Initial Catalog=WinDB;Integrated Security=True;";
        public int customerId;
        public int orderId;
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

            /*
            UserRepository userRepo = new UserRepository(ConnectionString);
            Users NEWCustomer = new Users
            {
                FirstName = "who?",
                LastName = "idk",
                Email = "yalla@example.com",
                UserAddress = "... street",
                UserRole = "Customer",
                UserPassword = "123password"
            };
            customerId = userRepo.AddUser(NEWCustomer);
            RestaurantRepository restaurantRepo = new RestaurantRepository(ConnectionString);
            Restaurant NEWRestaurant = new Restaurant
            {
                Name = "Rest",
                Rating = 4.7m
            };
            int NEWId = restaurantRepo.AddRestaurant(NEWRestaurant);
            MenuItemRepository MENUItemRepo = new MenuItemRepository(ConnectionString);

            MenuItem1 NEWMenuItem = new MenuItem1
            {
                Name = "steak ",
                Availability = true,
                Price = 12.99m,
                Description = "sushiii",
                RestaurantID = NEWId
            };

            int itemId = MENUItemRepo.AddMenuItem(NEWMenuItem);
            OrderRepository Orderrepo = new OrderRepository(ConnectionString);

            Order NewOrder = new Order
            {
                Status = "Pending",
                TotalAmount = 49.99m,
                RestaurantID = NEWId,  // make sure this exists
                CustomerID = customerId     // make sure this exists
            };

            orderId = Orderrepo.AddOrder(NewOrder);
            OrderDetailsRepository detailSRepo = new OrderDetailsRepository(ConnectionString);
            List<OrderDetails> ItemS = new List<OrderDetails>
        {
            new OrderDetails { OrderID = orderId, ItemID = 1, Quantity = 2, Subtotal = 2 * 9.99m },
            new OrderDetails { OrderID = orderId, ItemID = 3, Quantity = 1, Subtotal = 12.50m }
        };

            foreach (var item in ItemS)
            {
                detailSRepo.AddOrderDetail(item);
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
