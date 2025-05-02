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
    public partial class OrderDetialsForm: Form
    {
        private static string ConnectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        private OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository(ConnectionString);
        UserOrdersForm userOrdersForm;
        int orederid;
        AllOrdersForm allOrdersForm;
        public OrderDetialsForm(int orderid , UserOrdersForm userOrdersform)
        {
            InitializeComponent();
            this.orederid = orderid;
            this.userOrdersForm = userOrdersform ?? throw new ArgumentNullException(nameof(userOrdersform));
            readorderdetails();
        }
        public OrderDetialsForm(int orderid, AllOrdersForm allOrdersForm)
        {
            InitializeComponent();
            this.orederid = orderid;
            this.allOrdersForm = allOrdersForm ?? throw new ArgumentNullException(nameof(allOrdersForm));
            readorderdetails();
        }

        private void OrderDetialsForm_Load(object sender, EventArgs e)
        {

        }
        void readorderdetails()
        {
            List<OrderDetails> orderDetails = orderDetailsRepository.GetDetailsByOrder(orederid);
            var table = new DataTable();
            table.Columns.Add("OrderID", typeof(int));
            table.Columns.Add("FoodID", typeof(int));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Price", typeof(decimal));
            foreach (var order in orderDetails)
            {
                table.Rows.Add(order.OrderID, order.ItemID, order.Quantity, order.Subtotal);
            }
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.allOrdersForm != null)
            {
                this.allOrdersForm.Show();
            }
            else if (this.userOrdersForm != null)
            {
                this.userOrdersForm.Show();
            }
            this.Close();
        }
    }
}
