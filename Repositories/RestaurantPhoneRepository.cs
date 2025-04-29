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
    class RestaurantPhoneRepository
    {
        private readonly DatabaseHelper _dbHelper;
        private const string TableName = "RestaurantPhone"; 
        public RestaurantPhoneRepository(string connectionString)
        {
            _dbHelper = new DatabaseHelper(connectionString);
        }

        // INSERT - Add a new phone number
        public void AddPhone(RestaurantPhone phone)
        {
            if (phone == null)
                throw new ArgumentNullException(nameof(phone));

            string query = $@"
            INSERT INTO {TableName} 
            (RestaurantID, Phone) 
            VALUES 
            (@RestaurantID, @Phone)";

            SqlParameter[] parameters =
            {
            new SqlParameter("@RestaurantID", phone.RestaurantID),
            new SqlParameter("@Phone", phone.Phone ?? (object)DBNull.Value)
        };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // GET BY RESTAURANT ID - Get all phones for a restaurant
        public List<RestaurantPhone> GetPhonesByRestaurant(int restaurantId)
        {
            string query = $@"
            SELECT * 
            FROM {TableName} 
            WHERE RestaurantID = @RestaurantID";

            SqlParameter[] parameters =
            {
            new SqlParameter("@RestaurantID", restaurantId)
        };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            List<RestaurantPhone> phones = new List<RestaurantPhone>();

            foreach (DataRow row in dataTable.Rows)
            {
                phones.Add(MapDataRowToPhone(row));
            }

            return phones;
        }

        // GET ALL - Get all phone numbers
        public List<RestaurantPhone> GetAllPhones()
        {
            string query = $@"SELECT * FROM {TableName}";
            DataTable dataTable = _dbHelper.ExecuteQuery(query);
            List<RestaurantPhone> phones = new List<RestaurantPhone>();

            foreach (DataRow row in dataTable.Rows)
            {
                phones.Add(MapDataRowToPhone(row));
            }

            return phones;
        }

        // UPDATE - Update a phone number
        public void UpdatePhone(RestaurantPhone phone)
        {
            if (phone == null)
                throw new ArgumentNullException(nameof(phone));

            string query = $@"
            UPDATE {TableName} 
            SET Phone = @Phone
            WHERE RestaurantID = @RestaurantID";

            SqlParameter[] parameters =
            {
            new SqlParameter("@RestaurantID", phone.RestaurantID),
            new SqlParameter("@Phone", phone.Phone ?? (object)DBNull.Value)
        };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // DELETE - Remove a phone number
        public void DeletePhone(int restaurantId)
        {
            string query = $@"
            DELETE FROM {TableName} 
            WHERE RestaurantID = @RestaurantID";

            SqlParameter[] parameters =
            {
            new SqlParameter("@RestaurantID", restaurantId)
        };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // Helper method to map DataRow to RestaurantPhone
        private RestaurantPhone MapDataRowToPhone(DataRow row)
        {
            return new RestaurantPhone
            {
                RestaurantID = (int)row["RestaurantID"],
                Phone = row["Phone"]?.ToString()
            };
        }
    }
}
