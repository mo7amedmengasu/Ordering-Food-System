using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Db_Project.Forms
{
    using Db_Project.models;
    using Db_Project.Repositories;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class PaymentForm : Form
    {
        int orderId;
        private static string ConnectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        PaymentRepository paymentRepository = new PaymentRepository(ConnectionString);
        OrderRepository orderRepository = new OrderRepository(ConnectionString);
        OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository(ConnectionString);
        int customerId;
        public PaymentForm(int orderId , int customerId)
        {
            InitializeComponent();
            this.orderId = orderId;
            this.customerId = customerId;
            LoadPaymentStatus();
        }

        private void LoadPaymentStatus()
        {
            var payments = paymentRepository.GetPaymentsByOrder(orderId);
            if (payments.Count > 0)
            {
                var latest = payments.First();
                lblPaymentStatus.Text = latest.Status;
                txtAmount.Text = latest.Amount.ToString("F2");
                comboPaymentMethod.SelectedItem = latest.PaymentMethod;
                btnPayNow.Enabled = latest.Status == "Pending";
            }
            else
            {
                lblPaymentStatus.Text = "No payment yet";
                var totalAmount = orderDetailsRepository
                    .GetDetailsByOrder(orderId)
                    .Sum(x => x.Subtotal);
                txtAmount.Text = totalAmount.ToString("F2");
                btnPayNow.Enabled = true;
            }
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            var selectedMethod = comboPaymentMethod.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedMethod))
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            decimal amount = decimal.Parse(txtAmount.Text);

            Payment payment = new Payment
            {
                OrderID = orderId,
                CustomerID = customerId,
                Amount = amount,
                PaymentMethod = selectedMethod,
                Status = "Paid",
                PaymentDate = DateTime.Now
            };

            paymentRepository.AddPayment(payment);
            MessageBox.Show("Payment successful!");

            LoadPaymentStatus();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {


        }
    }

}
