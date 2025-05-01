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
    public partial class CartForm : Form
    {
        string ConnectionString = "Data Source=RENADLAPTOP;Initial Catalog=windb;Integrated Security=True;";
        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {

        }


    }
}
