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
    public partial class TrialForm : Form
    {
        private static string ConnectionString= "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        private OrderRepository orderRepository = new OrderRepository(ConnectionString);
        public TrialForm()
        {
            InitializeComponent();
            CreateOrder();
        }

        private void TrialForm_Load(object sender, EventArgs e)
        {

        }
        private void CreateOrder()
        {
            Order order = new Order();
            order.Status = "Pending";
            order.RestaurantID = 1;
            order.CustomerID = 1;
            

            orderRepository.AddOrder(order);

            if(order.OrderID != 0)
            {
                MessageBox.Show("Order created successfully with ID: " + order.OrderID);
            }
            else
            {
                MessageBox.Show("Failed to create order.");
            }

        }
    }
}
