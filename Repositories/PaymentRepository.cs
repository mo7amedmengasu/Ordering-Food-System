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
    class PaymentRepository
    {
        private readonly DatabaseHelper _dbHelper;
        private const string TableName = "Payment";

        public PaymentRepository(string connectionString)
        {
            _dbHelper = new DatabaseHelper(connectionString);
        }

        // INSERT - Create new payment with automatic timestamp
        public int AddPayment(Payment payment)
        {
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));

            string query = $@"
                INSERT INTO {TableName} 
                (PaymentMethod, Amount, Status, PaymentDate, CustomerID, OrderID)
                OUTPUT INSERTED.PaymentID
                VALUES (@PaymentMethod, @Amount, @Status, GETDATE(), @CustomerID, @OrderID)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@PaymentMethod", payment.PaymentMethod ?? (object)DBNull.Value),
                new SqlParameter("@Amount", payment.Amount),
                new SqlParameter("@Status", payment.Status ?? "Pending"),
                new SqlParameter("@CustomerID", payment.CustomerID),
                new SqlParameter("@OrderID", payment.OrderID)
            };

            return Convert.ToInt32(_dbHelper.ExecuteScalar(query, parameters));
        }
        public List<Payment> GetPayments()
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                ORDER BY PaymentDate DESC";
            DataTable dataTable = _dbHelper.ExecuteQuery(query);
            return MapDataTableToPayments(dataTable);
        }

        // GET BY ID - Retrieve payment by ID
        public Payment GetPaymentById(int paymentId)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE PaymentID = @PaymentID";

            SqlParameter[] parameters = { new SqlParameter("@PaymentID", paymentId) };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return dataTable.Rows.Count > 0 ? MapDataRowToPayment(dataTable.Rows[0]) : null;
        }

        // GET BY ORDER - Retrieve payments by order ID
        public List<Payment> GetPaymentsByOrder(int orderId)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE OrderID = @OrderID
                ORDER BY PaymentDate DESC";

            SqlParameter[] parameters = { new SqlParameter("@OrderID", orderId) };
            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return MapDataTableToPayments(dataTable);
        }

        // GET BY CUSTOMER - Retrieve payments by customer ID
        public List<Payment> GetPaymentsByCustomer(int customerId)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE CustomerID = @CustomerID
                ORDER BY PaymentDate DESC";

            SqlParameter[] parameters = { new SqlParameter("@CustomerID", customerId) };
            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return MapDataTableToPayments(dataTable);
        }

        // GET BY DATE RANGE - Retrieve payments between dates
        public List<Payment> GetPaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE PaymentDate BETWEEN @StartDate AND @EndDate
                ORDER BY PaymentDate DESC";

            SqlParameter[] parameters =
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return MapDataTableToPayments(dataTable);
        }

        // UPDATE - Update payment details
        public void UpdatePayment(Payment payment)
        {
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));

            string query = $@"
                UPDATE {TableName} 
                SET PaymentMethod = @PaymentMethod,
                    Amount = @Amount,
                    Status = @Status
                WHERE PaymentID = @PaymentID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@PaymentID", payment.PaymentID),
                new SqlParameter("@PaymentMethod", payment.PaymentMethod ?? (object)DBNull.Value),
                new SqlParameter("@Amount", payment.Amount),
                new SqlParameter("@Status", payment.Status ?? (object)DBNull.Value)
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // UPDATE STATUS - Update payment status only
        public void UpdatePaymentStatus(int paymentId, string status)
        {
            string query = $@"
                UPDATE {TableName} 
                SET Status = @Status
                WHERE PaymentID = @PaymentID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@PaymentID", paymentId),
                new SqlParameter("@Status", status ?? "Pending")
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // DELETE - Remove payment
        public void DeletePayment(int paymentId)
        {
            string query = $@"
                DELETE FROM {TableName} 
                WHERE PaymentID = @PaymentID";

            SqlParameter[] parameters = { new SqlParameter("@PaymentID", paymentId) };
            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // PRIVATE HELPER METHODS
        private Payment MapDataRowToPayment(DataRow row)
        {
            return new Payment
            {
                PaymentID = (int)row["PaymentID"],
                PaymentMethod = row["PaymentMethod"]?.ToString(),
                Amount = Convert.ToDecimal(row["Amount"]),
                Status = row["Status"]?.ToString(),
                PaymentDate = Convert.ToDateTime(row["PaymentDate"]),
                CustomerID = (int)row["CustomerID"],
                OrderID = (int)row["OrderID"]
            };
        }

        private List<Payment> MapDataTableToPayments(DataTable dataTable)
        {
            List<Payment> payments = new List<Payment>();
            foreach (DataRow row in dataTable.Rows)
            {
                payments.Add(MapDataRowToPayment(row));
            }
            return payments;
        }
    }
}
