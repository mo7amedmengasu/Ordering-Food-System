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
        private static string ConnectionString = "Data Source=RENADLAPTOP;Initial Catalog=windb;Integrated Security=True;";
        OrderDetailsRepository orderDetailsRepository= new OrderDetailsRepository(ConnectionString);

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
                OrderDetails oderDetail = new OrderDetails();
                oderDetail.OrderID = 2;
                oderDetail.ItemID = 1;
                oderDetail.Quantity = 2;
                oderDetail.Subtotal = 20.0M;
                var table = new DataTable();
                table.Columns.Add("OrderID", typeof(int));
                table.Columns.Add("ItemID", typeof(int));
                table.Columns.Add("Quantity", typeof(int));
                table.Columns.Add("Subtotal", typeof(decimal));
                table.Rows.Add(oderDetail.OrderID, oderDetail.ItemID, oderDetail.Quantity, oderDetail.Subtotal);
                orderDetailsRepository.AddOrderDetail(oderDetail);
                dataGridView1.DataSource = table;
                




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ex.StackTrace);
                

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
