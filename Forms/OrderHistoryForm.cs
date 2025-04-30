using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Db_Project.Forms
{
    public partial class OrderHistoryForm : Form
    {
        private readonly string ConnectionString = "Data Source=LAPTOP-6DMMQEEO;Initial Catalog=WinDB;Integrated Security=True;";
        private readonly int _customerId;

        public OrderHistoryForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;

           
            InitializeControls();
            LoadOrders();
        }

       

        private void InitializeControls()
        {
            this.Text = "Order History";
            this.Size = new System.Drawing.Size(800, 600);

            dataGridView1 = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(740, 200),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            ViewDetails = new Button
            {
                Text = "View Order Details",
                Location = new System.Drawing.Point(20, 230),
                Size = new System.Drawing.Size(200, 30)
            };
            ViewDetails.Click += BtnViewDetails_Click;

           

            this.Controls.Add(dataGridView1);
            this.Controls.Add(ViewDetails);
           
        }

        private void LoadOrders()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
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
            // TODO: This line of code loads data into the 'winDBDataSet.Order' table. You can move, or remove it, as needed.
            this.orderTableAdapter.Fill(this.winDBDataSet.Order);

        }
    }
}
