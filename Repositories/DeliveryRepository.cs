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
    class DeliveryRepository
    {
        private readonly DatabaseHelper _dbHelper;
        private const string TableName = "Delivery";

        public DeliveryRepository(string connectionString)
        {
            _dbHelper = new DatabaseHelper(connectionString);
        }

        // INSERT - Create new delivery record
        public int AddDelivery(Delivery delivery)
        {
            if (delivery == null)
                throw new ArgumentNullException(nameof(delivery));

            string query = $@"
                INSERT INTO {TableName} 
                (Status, DeliveryAddress, EstimatedTime, OrderID, DeliveryPersonID, DeliveryFee)
                OUTPUT INSERTED.DeliveryID
                VALUES (@Status, @DeliveryAddress, @EstimatedTime, @OrderID, @DeliveryPersonID, @DeliveryFee)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Status", delivery.Status ?? "Pending"),
                new SqlParameter("@DeliveryAddress", delivery.DeliveryAddress ?? string.Empty),
                new SqlParameter("@EstimatedTime", delivery.EstimatedTime),
                new SqlParameter("@OrderID", delivery.OrderID),
                new SqlParameter("@DeliveryPersonID", delivery.DeliveryPersonID),
                new SqlParameter("@DeliveryFee", delivery.DeliveryFee)
            };

            return Convert.ToInt32(_dbHelper.ExecuteScalar(query, parameters));
        }

        // GET BY ID - Get delivery by ID
        public Delivery GetDeliveryById(int deliveryId)
        {
            string query = $@"
                SELECT * FROM {TableName} 
                WHERE DeliveryID = @DeliveryID";

            SqlParameter[] parameters = { new SqlParameter("@DeliveryID", deliveryId) };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return dataTable.Rows.Count > 0 ? MapDataRowToDelivery(dataTable.Rows[0]) : null;
        }

        // GET BY ORDER - Get delivery by OrderID
        public Delivery GetDeliveryByOrder(int orderId)
        {
            string query = $@"
                SELECT * FROM {TableName} 
                WHERE OrderID = @OrderID";

            SqlParameter[] parameters = { new SqlParameter("@OrderID", orderId) };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return dataTable.Rows.Count > 0 ? MapDataRowToDelivery(dataTable.Rows[0]) : null;
        }

        // GET BY DELIVERY PERSON - Get deliveries assigned to a person
        public List<Delivery> GetDeliveriesByPerson(int deliveryPersonId)
        {
            string query = $@"
                SELECT * FROM {TableName} 
                WHERE DeliveryPersonID = @DeliveryPersonID
                ORDER BY Status";

            SqlParameter[] parameters = { new SqlParameter("@DeliveryPersonID", deliveryPersonId) };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return MapDataTableToDeliveries(dataTable);
        }

        // GET ALL - Get all deliveries
        public List<Delivery> GetAllDeliveries()
        {
            string query = $@"SELECT * FROM {TableName} ORDER BY DeliveryID";
            DataTable dataTable = _dbHelper.ExecuteQuery(query);
            return MapDataTableToDeliveries(dataTable);
        }

        // UPDATE - Update delivery details
        public void UpdateDelivery(Delivery delivery)
        {
            if (delivery == null)
                throw new ArgumentNullException(nameof(delivery));

            string query = $@"
                UPDATE {TableName} 
                SET Status = @Status,
                    DeliveryAddress = @DeliveryAddress,
                    EstimatedTime = @EstimatedTime,
                    DeliveryPersonID = @DeliveryPersonID,
                    DeliveryFee = @DeliveryFee
                WHERE DeliveryID = @DeliveryID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@DeliveryID", delivery.DeliveryID),
                new SqlParameter("@Status", delivery.Status ?? "Pending"),
                new SqlParameter("@DeliveryAddress", delivery.DeliveryAddress ?? string.Empty),
                new SqlParameter("@EstimatedTime", delivery.EstimatedTime),
                new SqlParameter("@DeliveryPersonID", delivery.DeliveryPersonID),
                new SqlParameter("@DeliveryFee", delivery.DeliveryFee)
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // UPDATE STATUS - Update only delivery status
        public void UpdateDeliveryStatus(int deliveryId, string status)
        {
            string query = $@"
                UPDATE {TableName} 
                SET Status = @Status
                WHERE DeliveryID = @DeliveryID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@DeliveryID", deliveryId),
                new SqlParameter("@Status", status ?? "Pending")
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // DELETE - Remove delivery record
        public void DeleteDelivery(int deliveryId)
        {
            string query = $@"DELETE FROM {TableName} WHERE DeliveryID = @DeliveryID";
            SqlParameter[] parameters = { new SqlParameter("@DeliveryID", deliveryId) };
            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // Helper method to map DataRow to Delivery
        private Delivery MapDataRowToDelivery(DataRow row)
        {
            return new Delivery
            {
                DeliveryID = (int)row["DeliveryID"],
                Status = row["Status"].ToString(),
                DeliveryAddress = row["DeliveryAddress"].ToString(),
                EstimatedTime = (TimeSpan)row["EstimatedTime"],
                OrderID = (int)row["OrderID"],
                DeliveryPersonID = (int)row["DeliveryPersonID"],
                DeliveryFee = Convert.ToDecimal(row["DeliveryFee"])
            };
        }

        // Helper method to map DataTable to List<Delivery>
        private List<Delivery> MapDataTableToDeliveries(DataTable dataTable)
        {
            List<Delivery> deliveries = new List<Delivery>();
            foreach (DataRow row in dataTable.Rows)
            {
                deliveries.Add(MapDataRowToDelivery(row));
            }
            return deliveries;
        }
    }
}
