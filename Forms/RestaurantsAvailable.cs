
//done!

using Db_Project.models;
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
    public partial class RestaurantsAvailable : Form
    {
        private static string ConnectionString = "Data Source=RENADLAPTOP;Initial Catalog=windb;Integrated Security=True;";
        private Users loggedInUser;
        private RestaurantRepository restaurantRepository = new RestaurantRepository(ConnectionString);

        public RestaurantsAvailable(Users user)
        {
            this.loggedInUser = user ?? throw new ArgumentNullException(nameof(user));
            InitializeComponent();
            LoadRestaurants();
            restaurantGrid.CellClick += restaurantGrid_CellClick;
        }

        private void RestaurantsAvailable_Load(object sender, EventArgs e)
        {

        }


        //repositoried
        private void LoadRestaurants()
        {
            List<Restaurant> restaurants = restaurantRepository.GetAllRestaurants();
            restaurantGrid.DataSource = restaurants;

            restaurantGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }



        //done
        private void restaurantGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = restaurantGrid.Rows[e.RowIndex];

                    // Use the correct column index or name
                    object idValue = selectedRow.Cells["RestaurantID"].Value;

                    if (idValue != null && int.TryParse(idValue.ToString(), out int restaurantId))
                    {
                        // Open the menu form with this ID
                        MenuItemsForm menuForm = new MenuItemsForm(restaurantId,loggedInUser);
                        menuForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Restaurant ID is missing or invalid.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
