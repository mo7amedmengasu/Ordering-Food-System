using System;
using System.Data;
using System.Data.SqlClient;

public class DatabaseHelper
{
   

    private readonly string _connectionString;

    public DatabaseHelper(string connectionString) // Good approach
    {
        _connectionString = connectionString;
    }

    // Open a new connection to the database
    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }

    // Execute a non-query SQL command (e.g., INSERT, UPDATE, DELETE)
    public void ExecuteNonQuery(string query, params SqlParameter[] parameters)
    {
        using (var connection = GetConnection())
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Execute a query that returns a single value (e.g., SELECT COUNT)
    public object ExecuteScalar(string query, params SqlParameter[] parameters)
    {
        using (var connection = GetConnection())
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);
            connection.Open();
            return command.ExecuteScalar();
        }
    }

    // Execute a query that returns data (e.g., SELECT)
    public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
    {
        using (var connection = GetConnection())
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);
            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
