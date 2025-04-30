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

        public OrderDetailsViewForm(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Get order basic info
                string orderQuery = "SELECT OrderID, OrderDate, Status, TotalAmount, DeliveryAddress, EstimatedTime FROM [Order] WHERE OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(orderQuery, conn);
                cmd.Parameters.AddWithValue("@OrderID", _orderId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtOrderId.Text = reader["OrderID"].ToString();
                    txtDate.Text = Convert.ToDateTime(reader["OrderDate"]).ToString("g");
                    txtStatus.Text = reader["Status"].ToString();
                    txtTotalAmount.Text = reader["TotalAmount"].ToString();
                    txtDeliveryAddress.Text = reader["DeliveryAddress"].ToString();
                    txtEstimatedTime.Text = reader["EstimatedTime"].ToString();
                }
                reader.Close();

                // Load items in the order (join OrderDetails + MenuItem)
                string detailsQuery = @"
                SELECT m.Name AS ItemName, od.Quantity, od.Price
                FROM OrderDetails od
                INNER JOIN MenuItem m ON od.MenuItemID = m.MenuItemID
                WHERE od.OrderID = @OrderID";

                SqlDataAdapter adapter = new SqlDataAdapter(detailsQuery, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@OrderID", _orderId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvOrderItems.DataSource = dt;
            }
        }

        private void OrderDetailsViewForm_Load(object sender, EventArgs e)
        {
            // You can load order details here later
        }

    }

}
