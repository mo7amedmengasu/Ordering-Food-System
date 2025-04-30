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
    public partial class OrderHistoryForm: Form
    {
        private readonly OrderRepository _orderRepository;
        private readonly string _connectionString = "Data Source=LAPTOP-6DMMQEEO;Initial Catalog=WinDB;Integrated Security=True;";
        private readonly int _customerId;
        public OrderHistoryForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            _orderRepository = new OrderRepository(_connectionString);
            LoadOrders();

        }

        private void LoadOrders()
        {
            
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT OrderID, OrderDate, TotalAmount FROM Orders WHERE CustomerID = @CustomerID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@CustomerID", _customerId);

                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
        }

       

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int orderId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OrderID"].Value);
                OrderDetailsViewForm detailsForm = new OrderDetailsViewForm(orderId);
                detailsForm.Show();
            }
        }



        private void OrderHistoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
