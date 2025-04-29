using Db_Project.models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;



public class UserRepository
{
    private readonly DatabaseHelper _dbHelper;

    public UserRepository(string connectionString)
    {
        _dbHelper = new DatabaseHelper(connectionString);
    }

    // Add a new customer
    public void AddUser(Users user)
    {
        string query = "INSERT INTO Users (FirstName, LastName, Email, UserAddress, UserRole, UserPassword) " +
                       "VALUES (@FirstName, @LastName, @Email, @UserAddress, @UserRole, @UserPassword)";

        SqlParameter[] parameters =
        {
            new SqlParameter("@FirstName", user.FirstName),
            new SqlParameter("@LastName", user.LastName),
            new SqlParameter("@Email", user.Email),
            new SqlParameter("@UserAddress", user.UserAddress),
            new SqlParameter("@UserRole", user.UserRole),
            new SqlParameter("@UserPassword", user.UserPassword)
        };

        _dbHelper.ExecuteNonQuery(query, parameters);
    }

    // Get a user by ID
    public Users GetUserById(int userId)
    {
        string query = "SELECT * FROM Users WHERE UserID = @UserID";
        SqlParameter[] parameters =
        {
            new SqlParameter("@UserID", userId)
        };

        DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);
        if (dataTable.Rows.Count > 0)
        {
            DataRow row = dataTable.Rows[0];
            return new Users
            {
                UserID = (int)row["UserID"],
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Email = row["Email"].ToString(),
                UserAddress = row["UserAddress"].ToString(),
                UserRole = row["UserRole"].ToString(),
                UserPassword = row["UserPassword"].ToString()
            };
        }
        return null; // If no user found
    }

    // Get all users
    public List<Users> GetAllUsers()
    {
        string query = "SELECT * FROM Users";
        DataTable dataTable = _dbHelper.ExecuteQuery(query);

        List<Users> users = new List<Users>();
        foreach (DataRow row in dataTable.Rows)
        {
            users.Add(new Users
            {
                UserID = (int)row["UserID"],
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Email = row["Email"].ToString(),
                UserAddress = row["UserAddress"].ToString(),
                UserRole = row["UserRole"].ToString(),
                UserPassword = row["UserPassword"].ToString()
            });
        }
        return users;
    }
    public List<Users> GetAllCustomers()
    {
        string query = "SELECT * FROM Users where UserRole = 'Customer' ";
        DataTable dataTable = _dbHelper.ExecuteQuery(query);

        List<Users> users = new List<Users>();
        foreach (DataRow row in dataTable.Rows)
        {
            users.Add(new Users
            {
                UserID = (int)row["UserID"],
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Email = row["Email"].ToString(),
                UserAddress = row["UserAddress"].ToString(),
                UserRole = row["UserRole"].ToString(),
                UserPassword = row["UserPassword"].ToString()
            });
        }
        return users;
    }

    // Update a user
    public void UpdateUser(Users user)
    {
        string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, " +
                       "UserAddress = @UserAddress, UserRole = @UserRole, UserPassword = @UserPassword " +
                       "WHERE UserID = @UserID";

        SqlParameter[] parameters =
        {
            new SqlParameter("@UserID", user.UserID),
            new SqlParameter("@FirstName", user.FirstName),
            new SqlParameter("@LastName", user.LastName),
            new SqlParameter("@Email", user.Email),
            new SqlParameter("@UserAddress", user.UserAddress),
            new SqlParameter("@UserRole", user.UserRole),
            new SqlParameter("@UserPassword", user.UserPassword)
        };

        _dbHelper.ExecuteNonQuery(query, parameters);
    }

    // Delete a user
    public void DeleteUser(int userId)
    {
        string query = "DELETE FROM Users WHERE UserID = @UserID";
        SqlParameter[] parameters =
        {
            new SqlParameter("@UserID", userId)
        };

        _dbHelper.ExecuteNonQuery(query, parameters);
    }
}
