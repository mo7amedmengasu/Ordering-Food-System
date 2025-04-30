using Db_Project.models;
using Db_Project.Repositories;
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

namespace Db_Project.Forms
{
    public partial class OrderDetailsViewForm : Form
    {
        private readonly int _orderId;
        private readonly string _connectionString = "Data Source=LAPTOP-6DMMQEEO;Initial Catalog=WinDB;Integrated Security=True;";
        private readonly OrderDetailsRepository _orderDetailsRepo;
        private readonly OrderRepository _orderRepo;
        public OrderDetailsViewForm(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            _orderRepo = new OrderRepository(_connectionString);
            _orderDetailsRepo = new OrderDetailsRepository(_connectionString);
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            // Get order summary
            Order order = _orderRepo.GetOrderById(_orderId);
            if (order != null)
            {
                txtOrderId.Text = order.OrderID.ToString();
                txtDate.Text = order.OrderDate.ToString("g");
                txtStatus.Text = order.Status;
                txtTotalAmount.Text = order.TotalAmount.ToString("C");
            }

            // Get order items
            List<OrderDetails> items = _orderDetailsRepo.GetDetailsByOrder(_orderId);
            dgvOrderItems.DataSource = items;
        
        }

        private void OrderDetailsViewForm_Load(object sender, EventArgs e)
        {
            // You can load order details here later
        }

        private void dgvOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
