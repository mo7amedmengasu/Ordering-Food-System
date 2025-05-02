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

namespace Db_Project.Forms
{
    public partial class ShowAssignedOrders: Form
    {
        private static readonly string connectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        private OrderRepository orderRepository = new OrderRepository(connectionString);
        private DeliveryRepository deliveryRepository = new DeliveryRepository(connectionString);
        private OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository(connectionString);
        private DeliveryPersonRepository deliveryPersonRepository = new DeliveryPersonRepository(connectionString);
        public AdminNavigationn navigationn;
        public ShowAssignedOrders(AdminNavigationn navigationn)
        {
            InitializeComponent();
            readAssignedOrders();
            this.navigationn = navigationn;
        }

        private void ShowAssignedOrders_Load(object sender, EventArgs e)
        {

        }
        public void readAssignedOrders()
        {


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

            List<Order> orders = orderRepository.GetAllAssignedOrders();
            

            foreach (var order in orders)
            {
             
                Delivery delivery = deliveryRepository.GetDeliveryByOrder(order.OrderID);
                DeliveryPerson deliveryPerson = deliveryPersonRepository.GetDeliveryPersonById(delivery.DeliveryPersonID);
                decimal totalAmount = orderDetailsRepository.GetOrderTotal(order.OrderID);
                table.Rows.Add(order.OrderID, order.Status, order.OrderDate, totalAmount, order.RestaurantID, order.CustomerID, deliveryPerson.Name, deliveryPerson.Phone, deliveryPerson.VehicleType,delivery.DeliveryFee);
            }
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            navigationn.Show();
            this.Close();
        }
    }
}
