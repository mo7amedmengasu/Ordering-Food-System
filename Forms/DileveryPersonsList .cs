using Db_Project.models;
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

namespace Db_Project.Forms
{
    public partial class DileveryPersonsList: Form
    {
        private static readonly string connectionString = "Data Source=.;Initial Catalog=windb;Integrated Security=True;";
        private DeliveryPersonRepository DeliveryPersonRepository = new DeliveryPersonRepository(connectionString);
        AssignOrderFrom assignOrderFrom;
        public DileveryPersonsList(AssignOrderFrom assignOrderFrom)
        {
            InitializeComponent();
            Readdelevirypersons();
            this.assignOrderFrom = assignOrderFrom;
        }

        private void DileveryPersonsList_Load(object sender, EventArgs e)
        {

        }
        void Readdelevirypersons()
        {
            List<DeliveryPerson> deliveryPersons = DeliveryPersonRepository.GetAllDeliveryPersons();
            var table = new DataTable();
            table.Columns.Add("Delivery Person ID");
            table.Columns.Add("Name");
            table.Columns.Add("Phone");
            table.Columns.Add("Vehicle Type");
            foreach (var deliveryPerson in deliveryPersons)
            {
                table.Rows.Add(deliveryPerson.DeliveryPersonID, deliveryPerson.Name, deliveryPerson.Phone, deliveryPerson.VehicleType);
            }
            dataGridView1.DataSource = table;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            assignOrderFrom.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                DeliveryPerson deliveryPerson = DeliveryPersonRepository.GetDeliveryPersonById(id);
                if (deliveryPerson != null)
                {
                    assignOrderFrom.deliveryPerson = deliveryPerson;
                    assignOrderFrom.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Could not find the selected delivery person.");
                }
            }
            else
            {
                MessageBox.Show("Please select a delivery person first.");
            }
        }
    }
}
