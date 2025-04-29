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
    class OrderDetailsRepository
    {
        private readonly DatabaseHelper _dbHelper;
        private const string TableName = "OrderDetails"; 
        public OrderDetailsRepository(string connectionString)
        {
            _dbHelper = new DatabaseHelper(connectionString);
        }

        // INSERT - Add new order detail
        public void AddOrderDetail(OrderDetails orderDetail)
        {
            if (orderDetail == null)
                throw new ArgumentNullException(nameof(orderDetail));

            string query = $@"
                INSERT INTO {TableName} 
                (OrderID, ItemID, Quantity, Subtotal)
                VALUES 
                (@OrderID, @ItemID, @Quantity, @Subtotal)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderID", orderDetail.OrderID),
                new SqlParameter("@ItemID", orderDetail.ItemID),
                new SqlParameter("@Quantity", orderDetail.Quantity),
                new SqlParameter("@Subtotal", orderDetail.Subtotal)
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // GET BY ORDER ID - Get all details for an order
        public List<OrderDetails> GetDetailsByOrder(int orderId)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE OrderID = @OrderID";

            SqlParameter[] parameters = { new SqlParameter("@OrderID", orderId) };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return MapDataTableToOrderDetails(dataTable);
        }

        // GET BY ITEM ID - Get all order details for an item
        public List<OrderDetails> GetDetailsByItem(int itemId)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE ItemID = @ItemID";

            SqlParameter[] parameters = { new SqlParameter("@ItemID", itemId) };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return MapDataTableToOrderDetails(dataTable);
        }

        // GET SPECIFIC DETAIL - Get specific order detail
        public OrderDetails GetOrderDetail(int orderId, int itemId)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE OrderID = @OrderID AND ItemID = @ItemID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderID", orderId),
                new SqlParameter("@ItemID", itemId)
            };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return dataTable.Rows.Count > 0 ? MapDataRowToOrderDetail(dataTable.Rows[0]) : null;
        }

        // UPDATE - Update order detail
        public void UpdateOrderDetail(OrderDetails orderDetail)
        {
            if (orderDetail == null)
                throw new ArgumentNullException(nameof(orderDetail));

            string query = $@"
                UPDATE {TableName} 
                SET Quantity = @Quantity, 
                    Subtotal = @Subtotal
                WHERE OrderID = @OrderID AND ItemID = @ItemID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderID", orderDetail.OrderID),
                new SqlParameter("@ItemID", orderDetail.ItemID),
                new SqlParameter("@Quantity", orderDetail.Quantity),
                new SqlParameter("@Subtotal", orderDetail.Subtotal)
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // DELETE - Remove order detail
        public void DeleteOrderDetail(int orderId, int itemId)
        {
            string query = $@"
                DELETE FROM {TableName} 
                WHERE OrderID = @OrderID AND ItemID = @ItemID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderID", orderId),
                new SqlParameter("@ItemID", itemId)
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // PRIVATE HELPER METHODS
        private OrderDetails MapDataRowToOrderDetail(DataRow row)
        {
            return new OrderDetails
            {
                OrderID = (int)row["OrderID"],
                ItemID = (int)row["ItemID"],
                Quantity = (int)row["Quantity"],
                Subtotal = Convert.ToDecimal(row["Subtotal"])
            };
        }

        private List<OrderDetails> MapDataTableToOrderDetails(DataTable dataTable)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            foreach (DataRow row in dataTable.Rows)
            {
                orderDetails.Add(MapDataRowToOrderDetail(row));
            }
            return orderDetails;
        }
    }
}
