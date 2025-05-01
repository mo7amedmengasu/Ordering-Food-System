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
    class RestaurantAddressRepository
    {
        private readonly DatabaseHelper _dbHelper;
        private const string TableName = "RestaurantAddress";

        public RestaurantAddressRepository(string connectionString)
        {
            _dbHelper = new DatabaseHelper(connectionString);
        }

        // INSERT - Add a new restaurant address
        public void Insert(RestaurantAddress address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            string query = $@"
            INSERT INTO {TableName} 
            (RestaurantID, Address) 
            VALUES 
            (@RestaurantID, @Address)";

            SqlParameter[] parameters =
            {
            new SqlParameter("@RestaurantID", address.RestaurantID),
            new SqlParameter("@Address", address.Address ?? (object)DBNull.Value)
        };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // GET BY ID - Get address by restaurant ID
        public RestaurantAddress GetById(int restaurantId)
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

            if (dataTable.Rows.Count == 0)
                return null;

            return MapDataRowToAddress(dataTable.Rows[0]);
        }


        // GET ALL - Get all restaurant addresses
        public List<RestaurantAddress> GetAll()
        {
            string query = $@"
            SELECT * 
            FROM {TableName}";

            DataTable dataTable = _dbHelper.ExecuteQuery(query);
            List<RestaurantAddress> addresses = new List<RestaurantAddress>();

            foreach (DataRow row in dataTable.Rows)
            {
                addresses.Add(MapDataRowToAddress(row));
            }

            return addresses;
        }

        // DELETE - Remove a restaurant address
        public void Delete(int restaurantId)
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

        public void DeleteByAddressAndId( int restaurantId,string address)
        {
            string query = $@"
            DELETE FROM {TableName} 
            WHERE RestaurantID = @RestaurantID and Address=@address";

            SqlParameter[] parameters =
            {
            new SqlParameter("@RestaurantID", restaurantId),
            new SqlParameter("@address", address)
        };

            _dbHelper.ExecuteNonQuery(query, parameters);

        }

        // Helper method to map DataRow to RestaurantAddress
        private RestaurantAddress MapDataRowToAddress(DataRow row)
        {
            return new RestaurantAddress
            {
                RestaurantID = (int)row["RestaurantID"],
                Address = row["Address"]?.ToString()
            };
        }

        public List<RestaurantAddress> GetByRestaurantId(int restaurantId)
        {
            string query = $@"
                           SELECT * 
                           FROM {TableName} 
                           WHERE RestaurantID = @RestaurantID";

            SqlParameter[] parameters =
            {
            new SqlParameter("@RestaurantID", restaurantId) };
            

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            List<RestaurantAddress> addresses = new List<RestaurantAddress>();

            foreach (DataRow row in dataTable.Rows)
            {
                addresses.Add(MapDataRowToAddress(row));
            }

            return addresses;
        }

    }
}
