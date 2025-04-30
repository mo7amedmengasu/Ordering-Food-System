using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using BCrypt.Net;
using Db_Project.models;

public class UserRepository
{
    private readonly DatabaseHelper _dbHelper;
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
        _dbHelper = new DatabaseHelper(connectionString);
    }

    public int AddUser(Users user)
    {
        try
        {
            string query = "INSERT INTO Users (FirstName, LastName, Email, UserAddress, UserRole, UserPassword) " +
                           "OUTPUT INSERTED.UserID " +
                           "VALUES (@FirstName, @LastName, @Email, @UserAddress, @UserRole, @UserPassword)";

            string plainPassword = user.UserPassword;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);

            SqlParameter[] parameters =
            {
            new SqlParameter("@FirstName", user.FirstName),
            new SqlParameter("@LastName", user.LastName),
            new SqlParameter("@Email", user.Email),
            new SqlParameter("@UserAddress", user.UserAddress),
            new SqlParameter("@UserRole", user.UserRole),
            new SqlParameter("@UserPassword", hashedPassword)
        };

            object result = _dbHelper.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627 || ex.Number == 2601) // Duplicate email
            {
                Console.WriteLine("Duplicate email detected.");
            }
            Console.WriteLine($"Error adding user {user.Email}: {ex}");
            return -1;
        }
    }

    public Users GetUserById(int userId)
    {
        string query = "SELECT * FROM Users WHERE UserID = @UserID";
        SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };
        DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);

        if (dataTable.Rows.Count > 0)
        {
            DataRow row = dataTable.Rows[0];
            return MapDataRowToUser(row, includePasswordHash: false); // Use helper to avoid returning hash
        }
        return null;
    }

    public List<Users> GetAllUsers()
    {
        string query = "SELECT * FROM Users";
        DataTable dataTable = _dbHelper.ExecuteQuery(query);
        List<Users> users = new List<Users>();
        foreach (DataRow row in dataTable.Rows)
        {
            users.Add(MapDataRowToUser(row, includePasswordHash: false)); // Use helper
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
            users.Add(MapDataRowToUser(row, includePasswordHash: false)); // Use helper
        }
        return users;
    }

    public void UpdateUserProfile(Users user) 
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        //don't update the hashed password
        string query = @"UPDATE Users
                     SET FirstName = @FirstName,
                         LastName = @LastName,
                         UserAddress = @UserAddress
                     WHERE UserID = @UserID";

        SqlParameter[] parameters =
        {
        new SqlParameter("@FirstName", user.FirstName ?? (object)DBNull.Value),
        new SqlParameter("@LastName", user.LastName ?? (object)DBNull.Value),
        new SqlParameter("@UserAddress", user.UserAddress ?? (object)DBNull.Value),
        new SqlParameter("@UserID", user.UserID)
    };

        _dbHelper.ExecuteNonQuery(query, parameters);
    }

   

    /*public void UpdateUser(Users user)
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
            new SqlParameter("@UserPassword", user.UserPassword) // Requires logic to check if it's a new plain password to hash
        };
        _dbHelper.ExecuteNonQuery(query, parameters);
    }*/


    public void DeleteUser(int userId)
    {
        string query = "DELETE FROM Users WHERE UserID = @UserID";
        SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };
        _dbHelper.ExecuteNonQuery(query, parameters);
    }

    public Users ValidateUser(string email, string plainTextPassword)
    {
        // Query to get the user by email, specifically retrieving the password hash
        string query = "SELECT UserID, FirstName, LastName, Email, UserAddress, UserRole, UserPassword " + // Select needed fields + password hash
                       "FROM Users WHERE Email = @Email";
        SqlParameter[] parameters =
        {
            new SqlParameter("@Email", email)
        };

        try
        {
            DataTable dataTable = _dbHelper.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                string storedPasswordHash = row["UserPassword"]?.ToString();

                if (string.IsNullOrEmpty(storedPasswordHash))
                {
                    Console.WriteLine($"Warning: User {email} found but has no password hash stored.");
                    return null;
                }

                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(plainTextPassword, storedPasswordHash);

                if (isPasswordValid)
                {
                    return MapDataRowToUser(row, includePasswordHash: false);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during user validation for email {email}: {ex.Message}");
            return null; // Return null on any error during validation
        }
    }

    private Users MapDataRowToUser(DataRow row, bool includePasswordHash = false)
    {
        var user = new Users
        {
            UserID = Convert.ToInt32(row["UserID"]),
            FirstName = row["FirstName"]?.ToString(),
            LastName = row["LastName"]?.ToString(),
            Email = row["Email"]?.ToString(),
            UserAddress = row["UserAddress"]?.ToString(),
            UserRole = row["UserRole"]?.ToString()
        };

        if (includePasswordHash)
        {
            user.UserPassword = row["UserPassword"]?.ToString();
        }

        return user;
    }
}


