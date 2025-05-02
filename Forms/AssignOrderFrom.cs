using Db_Project.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db_Project.Repositories;
using Db_Project.models;

namespace Db_Project.Forms
{
    public partial class AssignOrderFrom: Form
    {
        private static readonly string connectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        private DeliveryPersonRepository DeliveryPersonRepository = new DeliveryPersonRepository(connectionString);
        private DeliveryRepository deliveryRepository = new DeliveryRepository(connectionString);
        private OrderRepository orderRepository = new OrderRepository(connectionString);
        public DeliveryPerson deliveryPerson;
        public Show_Pending_Oeders show_Pending;
        public Order order;
        public AssignOrderFrom(Show_Pending_Oeders show_Pending , Order order)
        {
            InitializeComponent();
            this.show_Pending = show_Pending;
            this.order = order;
        }



        private void AssignOrderFrom_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DileveryPersonsList list = new DileveryPersonsList(this);
            list.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = deliveryPerson.Name;
            TimeSpan time = TimeSpan.Parse(textBox2.Text);
            int orderId = order.OrderID;
            int deliveryPersonId = deliveryPerson.DeliveryPersonID;
            decimal driveryFee = this.textBox3.Text != "" ? Convert.ToDecimal(this.textBox3.Text) : 0;
            string address = "Elzawya";
            string status = "Assigned";
            string delstatus = "ok";
            orderRepository.UpdateOrderStatus(orderId, status);
            Delivery delivery = new Delivery
            {
                OrderID = orderId,
                DeliveryPersonID = deliveryPersonId,
                DeliveryFee = driveryFee,
                DeliveryAddress = address,
                Status = delstatus,
                EstimatedTime = time
            };

            //Delivery newDelivery = new Delivery
            //{
            //    OrderID = order.OrderID,
            //    DeliveryPersonID = selectedPerson.DeliveryPersonID,
            //    Status = "Out for Delivery",
            //    EstimatedTime = estimatedTime,
            //    DeliveryFee = deliveryFee,
            //    DeliveryAddress = deliveryAddress
            //};
             deliveryRepository.AddDelivery(delivery);

            MessageBox.Show("Order Assigned Successfully");
            show_Pending.deliveryPerson = deliveryPerson;
            show_Pending.delivery = delivery;
            show_Pending.readallpendingorders();
            show_Pending.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            show_Pending.Show();
            this.Close();
        }
    }
}
