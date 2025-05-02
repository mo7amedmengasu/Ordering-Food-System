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

namespace Db_Project.Forms
{
    public partial class Show_Pending_Oeders: Form
    {
        private static readonly string connectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        private OrderRepository orderRepository = new OrderRepository(connectionString);
        private DeliveryRepository deliveryRepository = new DeliveryRepository(connectionString);
        private OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository(connectionString);
        private AdminNavigationn navigationn;
        private Order order;
        public DeliveryPerson deliveryPerson = new DeliveryPerson();
        public Delivery delivery = new Delivery();
            
        public Show_Pending_Oeders(AdminNavigationn navigationn)
        {
            deliveryPerson.Phone = "Not Assigned";
            deliveryPerson.Name = "Not Assigned";
            deliveryPerson.VehicleType = "Not Assigned";
            deliveryPerson.DeliveryPersonID = 0;

            delivery.DeliveryFee = 0;
            delivery.DeliveryID = 0;
            delivery.DeliveryPersonID = 0;
            delivery.OrderID = 0;
            delivery.Status = "Not Assigned";
            delivery.DeliveryAddress = "Not Assigned";
            // Fix for CS1955: Non-invocable member 'TimeSpan' cannot be used like a method.
            // The issue is that TimeSpan is a struct, and you need to use one of its factory methods like TimeSpan.FromMinutes, TimeSpan.FromSeconds, or the constructor.
            delivery.EstimatedTime = new TimeSpan(0, 0, 0); // This sets the TimeSpan to 00:00:00 (hours, minutes, seconds).
           

            InitializeComponent();
            readallpendingorders();
            this.navigationn = navigationn;
        }

        private void Show_Pending_Oeders_Load(object sender, EventArgs e)
        {

        }
        public void readallpendingorders()
        {
            List<Order> orders = orderRepository.GetAllPendingOrders();


            var table = new DataTable();
            table.Columns.Add("Order ID");
            table.Columns.Add("Status");
            table.Columns.Add("Order Date");
            table.Columns.Add("Total Amount");
            table.Columns.Add("Restaurant ID");
            table.Columns.Add("Customer ID");
            table.Columns.Add("Delivery Person Name");
            table.Columns.Add("Delivery Person Phone");
            table.Columns.Add("Delivery Person Vehicle Type");
            table.Columns.Add("Delivery Fee");


            foreach (var order in orders)
            {
                decimal totalAmount = orderDetailsRepository.GetOrderTotal(order.OrderID);
                table.Rows.Add(order.OrderID, order.Status, order.OrderDate, totalAmount, order.RestaurantID, order.CustomerID, deliveryPerson.Name,deliveryPerson.Phone, deliveryPerson.VehicleType,delivery.DeliveryFee);
            }
            dataGridView1.DataSource = table;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            navigationn.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int orderId = dataGridView1.SelectedRows[0].Cells["Order ID"].Value != null ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Order ID"].Value) : 0;
            if (orderId != 0)
            {
                Order order = orderRepository.GetOrderById(orderId);
                if (order != null)
                {
                    AssignOrderFrom assignOrderFrom = new AssignOrderFrom(this, order);
                    assignOrderFrom.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please select an order to assign.");
                }
            }
            else
            {
                MessageBox.Show("Please select an order to assign.");
            }

        }
    }
}
