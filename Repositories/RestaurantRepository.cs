using Db_Project.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Project.Repositories
{
    public class RestaurantRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public RestaurantRepository(string connectionString)
        {
            _dbHelper = new DatabaseHelper(connectionString);
        }

        // Add a new restaurant
        public int AddRestaurant(Restaurant restaurant)
        {
            string query = @"
        INSERT INTO Restaurant (Name, Rating) 
        OUTPUT INSERTED.RestaurantID
        VALUES (@Name, @Rating)";

            SqlParameter[] parameters =
            {
        new SqlParameter("@Name", restaurant.Name),
        new SqlParameter("@Rating", restaurant.Rating)
    };

            return (int)_dbHelper.ExecuteScalar(query, parameters);
        }

        // Get a restaurant by ID
        public Restaurant GetRestaurantById(int restaurantId)
        {
            string query = "SELECT * FROM Restaurant WHERE RestaurantID = @RestaurantID";
            SqlParameter[] parameters =
            {
            new SqlParameter("@RestaurantID", restaurantId)
        };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new Restaurant
                {
                    RestaurantID = (int)row["RestaurantID"],
                    Name = row["Name"].ToString(),
                    Rating = Convert.ToDecimal(row["Rating"])
                };
            }
            return null;
        }

        public Restaurant GetRestaurantByName(string restaurantName)
        {
            string query = "SELECT * FROM Restaurant WHERE Name = @RestaurantName";
            SqlParameter[] parameters =
            {
            new SqlParameter("@RestaurantName", restaurantName)
        };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new Restaurant
                {
                    RestaurantID = (int)row["RestaurantID"],
                    Name = row["Name"].ToString(),
                    Rating = Convert.ToDecimal(row["Rating"])
                };
            }
            return null;
        }

        // Get all restaurants
        public List<Restaurant> GetAllRestaurants()
        {
            string query = "SELECT * FROM Restaurant";
            DataTable dataTable = _dbHelper.ExecuteQuery(query);

            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (DataRow row in dataTable.Rows)
            {
                restaurants.Add(new Restaurant
                {
                    RestaurantID = (int)row["RestaurantID"],
                    Name = row["Name"].ToString(),
                    Rating = Convert.ToDecimal(row["Rating"])
                });
            }
            return restaurants;
        }

        // Update a restaurant
        public void UpdateRestaurant(Restaurant restaurant)
        {
            string query = "UPDATE Restaurant SET Name = @Name, Rating = @Rating " +
                          "WHERE RestaurantID = @RestaurantID";

            SqlParameter[] parameters =
            {
            new SqlParameter("@RestaurantID", restaurant.RestaurantID),
            new SqlParameter("@Name", restaurant.Name),
            new SqlParameter("@Rating", restaurant.Rating)
        };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // Delete a restaurant
        public void DeleteRestaurant(int restaurantId)
        {
            string query = "DELETE FROM Restaurant WHERE RestaurantID = @RestaurantID";
            SqlParameter[] parameters =
            {
            new SqlParameter("@RestaurantID", restaurantId)
        };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // Search restaurants by name (optional additional method)
        public List<Restaurant> SearchRestaurantsByName(string searchTerm)
        {
            string query = "SELECT * FROM Restaurant WHERE Name LIKE @SearchTerm";
            SqlParameter[] parameters =
            {
            new SqlParameter("@SearchTerm", $"%{searchTerm}%")
        };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (DataRow row in dataTable.Rows)
            {
                restaurants.Add(new Restaurant
                {
                    RestaurantID = (int)row["RestaurantID"],
                    Name = row["Name"].ToString(),
                    Rating = Convert.ToDecimal(row["Rating"])
                });
            }
            return restaurants;
        }

        public void UpdateRestaurant(int restaurantId, string name, decimal? rating = null)
        {
            List<string> setClauses = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                setClauses.Add("Name = @Name");
                parameters.Add(new SqlParameter("@Name", name));
            }

            if (rating.HasValue)
            {
                setClauses.Add("Rating = @Rating");
                parameters.Add(new SqlParameter("@Rating", rating.Value));
            }

            if (setClauses.Count == 0)
                throw new ArgumentException("At least one field (name or rating) must be provided.");

            string query = $@"
                           UPDATE Restaurant
                           SET {string.Join(", ", setClauses)}
                           WHERE RestaurantID = @RestaurantID";

            parameters.Add(new SqlParameter("@RestaurantID", restaurantId));

            _dbHelper.ExecuteNonQuery(query, parameters.ToArray());
        }

    }
}
