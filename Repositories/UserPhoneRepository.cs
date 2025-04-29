using Db_Project.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Db_Project.Repositories
{
    class UserPhoneRepository
    {
        private readonly DatabaseHelper _dbHelper;
        private const string TableName = "CustomerPhone";

        public UserPhoneRepository(string connectionString)
        {
            _dbHelper = new DatabaseHelper(connectionString);
        }

        // INSERT - Add new user phone number
        public void AddUserPhone(UserPhone userPhone)
        {
            if (userPhone == null)
                throw new ArgumentNullException(nameof(userPhone));

            string query = $@"
                INSERT INTO {TableName} 
                (UserID, Phone)
                VALUES (@UserID, @Phone)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@UserID", userPhone.UserID),
                new SqlParameter("@Phone", userPhone.Phone ?? string.Empty)
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // GET BY USER - Get all phone numbers for a user
        public List<UserPhone> GetPhonesByUser(int userId)
        {
            string query = $@"
                SELECT * 
                FROM {TableName} 
                WHERE UserID = @UserID";

            SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };

            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
            return MapDataTableToUserPhones(dataTable);
        }

        // GET ALL - Get all user phone numbers
        public List<UserPhone> GetAllUserPhones()
        {
            string query = $@"SELECT * FROM {TableName}";
            DataTable dataTable = _dbHelper.ExecuteQuery(query);
            return MapDataTableToUserPhones(dataTable);
        }

        public void UpdatePhone(UserPhone phone)
        {
            // Basic validation
            if (phone == null)
                throw new ArgumentNullException(nameof(phone));
            if (string.IsNullOrEmpty(phone.Phone)) 
                throw new ArgumentException("Phone number cannot be null or empty for update. Use DeleteUserPhone instead.", nameof(phone));

            string query = $"UPDATE Users SET Phone = @NewPhone WHERE UserID = @UserID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@NewPhone", phone.Phone),
                new SqlParameter("@UserID", phone.UserID)  
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // DELETE - Remove a user phone number
        public void DeleteUserPhone(int userId, string phone)
        {
            string query = $@"
                DELETE FROM {TableName} 
                WHERE UserID = @UserID AND Phone = @Phone";

            SqlParameter[] parameters =
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@Phone", phone)
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
        }

        // PRIVATE HELPER METHODS
        private UserPhone MapDataRowToUserPhone(DataRow row)
        {
            return new UserPhone
            {
                UserID = (int)row["UserID"],
                Phone = row["Phone"].ToString()
            };
        }

        private List<UserPhone> MapDataTableToUserPhones(DataTable dataTable)
        {
            List<UserPhone> phones = new List<UserPhone>();
            foreach (DataRow row in dataTable.Rows)
            {
                phones.Add(MapDataRowToUserPhone(row));
            }
            return phones;
        }
    }
}






