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
        private const string ConnectionString = "Server=.;Database=windb;Integrated Security=True;";

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

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
