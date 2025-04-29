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
    class DeliveryPersonRepository
    {
        private readonly DatabaseHelper _dbHelper;
        private const string TableName = "DeliveryPerson";

        public DeliveryPersonRepository(string connectionString)
        {
            _dbHelper = new DatabaseHelper(connectionString);
        }

        // INSERT - Add new delivery person
        public int AddDeliveryPerson(DeliveryPerson deliveryPerson)
        {
            if (deliveryPerson == null)
                throw new ArgumentNullException(nameof(deliveryPerson));

            string query = $@"
                INSERT INTO {TableName} 
                (Name, Phone, VehicleType)
                OUTPUT INSERTED.DeliveryPersonID
                VALUES (@Name, @Phone, @VehicleType)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", deliveryPerson.Name ?? (object)DBNull.Value),
                new SqlParameter("@Phone", deliveryPerson.Phone ?? (object)DBNull.Value),
                new SqlParameter("@VehicleType", deliveryPerson.VehicleType ?? (object)DBNull.Value)
            };

            return Convert.ToInt32(_dbHelper.ExecuteScalar(query, parameters));
        }

        // GET BY ID - Retrieve delivery person by ID
        public DeliveryPerson GetDeliveryPersonById(int deliveryPersonId)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE DeliveryPersonID = @DeliveryPersonID";

            SqlParameter[] parameters = { new SqlParameter("@DeliveryPersonID", deliveryPersonId) };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return dataTable.Rows.Count > 0 ? MapDataRowToDeliveryPerson(dataTable.Rows[0]) : null;
        }

        // GET ALL - Retrieve all delivery persons
        public List<DeliveryPerson> GetAllDeliveryPersons()
        {
            string query = $@"SELECT * FROM {TableName} ORDER BY DeliveryPersonID";
            DataTable dataTable = _dbHelper.ExecuteQuery(query);
            return MapDataTableToDeliveryPersons(dataTable);
        }

        // GET BY VEHICLE TYPE - Filter by vehicle type
        public List<DeliveryPerson> GetDeliveryPersonsByVehicle(string vehicleType)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE VehicleType = @VehicleType
                ORDER BY Name";

            SqlParameter[] parameters = { new SqlParameter("@VehicleType", vehicleType) };
            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return MapDataTableToDeliveryPersons(dataTable);
        }

        // UPDATE - Update delivery person details
        public void UpdateDeliveryPerson(DeliveryPerson deliveryPerson)
        {
            if (deliveryPerson == null)
                throw new ArgumentNullException(nameof(deliveryPerson));

            string query = $@"
                UPDATE {TableName} 
                SET Name = @Name,
                    Phone = @Phone,
                    VehicleType = @VehicleType
                WHERE DeliveryPersonID = @DeliveryPersonID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@DeliveryPersonID", deliveryPerson.DeliveryPersonID),
                new SqlParameter("@Name", deliveryPerson.Name ?? (object)DBNull.Value),
                new SqlParameter("@Phone", deliveryPerson.Phone ?? (object)DBNull.Value),
                new SqlParameter("@VehicleType", deliveryPerson.VehicleType ?? (object)DBNull.Value)
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // DELETE - Remove delivery person
        public void DeleteDeliveryPerson(int deliveryPersonId)
        {
            string query = $@"
                DELETE FROM {TableName} 
                WHERE DeliveryPersonID = @DeliveryPersonID";

            SqlParameter[] parameters = { new SqlParameter("@DeliveryPersonID", deliveryPersonId) };
            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // PRIVATE HELPER METHODS
        private DeliveryPerson MapDataRowToDeliveryPerson(DataRow row)
        {
            return new DeliveryPerson
            {
                DeliveryPersonID = (int)row["DeliveryPersonID"],
                Name = row["Name"]?.ToString(),
                Phone = row["Phone"]?.ToString(),
                VehicleType = row["VehicleType"]?.ToString()
            };
        }

        private List<DeliveryPerson> MapDataTableToDeliveryPersons(DataTable dataTable)
        {
            List<DeliveryPerson> deliveryPersons = new List<DeliveryPerson>();
            foreach (DataRow row in dataTable.Rows)
            {
                deliveryPersons.Add(MapDataRowToDeliveryPerson(row));
            }
            return deliveryPersons;
        }
    }
}
