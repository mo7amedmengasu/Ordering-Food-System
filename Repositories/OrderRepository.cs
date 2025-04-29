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
    class OrderRepository
    {
        private readonly DatabaseHelper _dbHelper;
        private const string TableName = "[Order]";

        public OrderRepository(string connectionString)
        {
            _dbHelper = new DatabaseHelper(connectionString);
        }

        // INSERT - Create new order with automatic timestamp
        public int AddOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            string query = $@"
            INSERT INTO {TableName} 
            (Status, OrderDate, TotalAmount, RestaurantID, CustomerID)
            OUTPUT INSERTED.OrderID
            VALUES (@Status, GETDATE(), @TotalAmount, @RestaurantID, @CustomerID)";

            SqlParameter[] parameters =
            {
            new SqlParameter("@Status", order.Status ?? "Pending"),
            new SqlParameter("@TotalAmount", order.TotalAmount),
            new SqlParameter("@RestaurantID", order.RestaurantID),
            new SqlParameter("@CustomerID", order.CustomerID)
        };

            int newOrderId = Convert.ToInt32(_dbHelper.ExecuteScalar(query, parameters));
            order.OrderDate = GetOrderDate(newOrderId); // Retrieve exact server timestamp
            return newOrderId;
        }

        // GET BY ID - Retrieve single order
        public Order GetOrderById(int orderId)
        {
            string query = $@"
            SELECT * 
            FROM {TableName} 
            WHERE OrderID = @OrderID";

            SqlParameter[] parameters = { new SqlParameter("@OrderID", orderId) };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return dataTable.Rows.Count > 0 ? MapDataRowToOrder(dataTable.Rows[0]) : null;
        }

        // GET ALL - Retrieve all orders
        public List<Order> GetAllOrders()
        {
            string query = $@"SELECT * FROM {TableName} ORDER BY OrderDate DESC";
            return MapDataTableToOrders(_dbHelper.ExecuteQuery(query));
        }

        // GET BY RESTAURANT - Retrieve orders by restaurant
        public List<Order> GetOrdersByRestaurant(int restaurantId)
        {
            string query = $@"
            SELECT * 
            FROM {TableName} 
            WHERE RestaurantID = @RestaurantID
            ORDER BY OrderDate DESC";

            SqlParameter[] parameters = { new SqlParameter("@RestaurantID", restaurantId) };
            return MapDataTableToOrders(_dbHelper.ExecuteQuery(query, parameters));
        }

        // GET BY CUSTOMER - Retrieve orders by customer
        public List<Order> GetOrdersByCustomer(int customerId)
        {
            string query = $@"
            SELECT * 
            FROM {TableName} 
            WHERE CustomerID = @CustomerID
            ORDER BY OrderDate DESC";

            SqlParameter[] parameters = { new SqlParameter("@CustomerID", customerId) };
            return MapDataTableToOrders(_dbHelper.ExecuteQuery(query, parameters));
        }

        // GET BY DATE RANGE - Retrieve orders between dates
        public List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = $@"
            SELECT * 
            FROM {TableName} 
            WHERE OrderDate BETWEEN @StartDate AND @EndDate
            ORDER BY OrderDate DESC";

            SqlParameter[] parameters =
            {
            new SqlParameter("@StartDate", startDate),
            new SqlParameter("@EndDate", endDate)
        };

            return MapDataTableToOrders(_dbHelper.ExecuteQuery(query, parameters));
        }

        // UPDATE - Update order details (except date)
        public void UpdateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            string query = $@"
            UPDATE {TableName} 
            SET Status = @Status, 
                TotalAmount = @TotalAmount
            WHERE OrderID = @OrderID";

            SqlParameter[] parameters =
            {
            new SqlParameter("@OrderID", order.OrderID),
            new SqlParameter("@Status", order.Status ?? (object)DBNull.Value),
            new SqlParameter("@TotalAmount", order.TotalAmount)
        };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // UPDATE STATUS - Change order status only
        public void UpdateOrderStatus(int orderId, string status)
        {
            string query = $@"
            UPDATE {TableName} 
            SET Status = @Status
            WHERE OrderID = @OrderID";

            SqlParameter[] parameters =
            {
            new SqlParameter("@OrderID", orderId),
            new SqlParameter("@Status", status ?? "Pending")
        };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // DELETE - Remove an order
        public void DeleteOrder(int orderId)
        {
            string query = $@"
            DELETE FROM {TableName} 
            WHERE OrderID = @OrderID";

            SqlParameter[] parameters = { new SqlParameter("@OrderID", orderId) };
            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // PRIVATE HELPER METHODS
        private DateTime GetOrderDate(int orderId)
        {
            string query = $@"
            SELECT OrderDate 
            FROM {TableName} 
            WHERE OrderID = @OrderID";

            SqlParameter[] parameters = { new SqlParameter("@OrderID", orderId) };
            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return Convert.ToDateTime(dataTable.Rows[0]["OrderDate"]);
        }

        private Order MapDataRowToOrder(DataRow row)
        {
            return new Order
            {
                OrderID = (int)row["OrderID"],
                Status = row["Status"].ToString(),
                OrderDate = Convert.ToDateTime(row["OrderDate"]),
                TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                RestaurantID = (int)row["RestaurantID"],
                CustomerID = (int)row["CustomerID"]
            };
        }

        private List<Order> MapDataTableToOrders(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            foreach (DataRow row in dataTable.Rows)
            {
                orders.Add(MapDataRowToOrder(row));
            }
            return orders;
        }
    }
}
