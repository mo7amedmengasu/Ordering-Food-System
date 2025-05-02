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
    public partial class AllOrdersForm: Form
    {
        private static string ConnectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        OrderRepository orderRepository = new OrderRepository(ConnectionString);
        OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository(ConnectionString);
        AdminNavigationn AdminNavigationn;
        public AllOrdersForm(AdminNavigationn navigationn)
        {
            InitializeComponent();
            this.AdminNavigationn = navigationn;
            readAllOrders();
        }

        private void AllOrdersForm_Load(object sender, EventArgs e)
        {

        }
        void readAllOrders()
        {
            List<Order> orders = orderRepository.GetAllOrders();
            var table = new DataTable();
            table.Columns.Add("OrderID", typeof(int));
            table.Columns.Add("RestaurantID", typeof(int));
            table.Columns.Add("OrderDate", typeof(DateTime));
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("TotalAmount", typeof(decimal));
            foreach (var order in orders)
            {
                decimal totalAmount = orderDetailsRepository.GetOrderTotal(order.OrderID);
                table.Rows.Add(order.OrderID, order.RestaurantID, order.OrderDate, order.Status, totalAmount);
            }
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ordderid = dataGridView1.SelectedRows[0].Cells["OrderID"].Value != null ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["OrderID"].Value) : 0;
            if (ordderid != 0)
            {
                OrderDetialsForm orderDetialsForm = new OrderDetialsForm(ordderid, this);
                orderDetialsForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select an order to view details.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.AdminNavigationn.Show();
            this.Close();
        }
    }
}
