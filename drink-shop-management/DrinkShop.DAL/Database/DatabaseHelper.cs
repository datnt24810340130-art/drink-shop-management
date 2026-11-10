using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;

namespace DrinkShop.DAL.Database;

public static class DatabaseHelper
{
    private static readonly string ConnectionString =
        ConfigurationManager.ConnectionStrings["DrinkShopConn"]?.ConnectionString
        ?? throw new InvalidOperationException("Không tìm thấy chuỗi kết nối DrinkShopConn trong cấu hình ứng dụng.");

    public static SqlConnection GetConnection()
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();
        return connection;
    }

    public static int ExecuteNonQuery(string sql, SqlParameter[]? parameters = null)
    {
        using var connection = GetConnection();
        using var command = new SqlCommand(sql, connection);
        AddParameters(command, parameters);
        return command.ExecuteNonQuery();
    }

    public static object? ExecuteScalar(string sql, SqlParameter[]? parameters = null)
    {
        using var connection = GetConnection();
        using var command = new SqlCommand(sql, connection);
        AddParameters(command, parameters);
        return command.ExecuteScalar();
    }

    public static DataTable ExecuteDataTable(string sql, SqlParameter[]? parameters = null)
    {
        using var connection = GetConnection();
        using var command = new SqlCommand(sql, connection);
        AddParameters(command, parameters);
        using var adapter = new SqlDataAdapter(command);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public static SqlDataReader ExecuteReader(string sql, SqlParameter[]? parameters = null)
    {
        var connection = GetConnection();
        var command = new SqlCommand(sql, connection);
        try
        {
            AddParameters(command, parameters);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch
        {
            command.Dispose();
            connection.Dispose();
            throw;
        }
    }

    public static string HashPassword(string password)
    {
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
    }

    private static void AddParameters(SqlCommand command, SqlParameter[]? parameters)
    {
        if (parameters is { Length: > 0 })
        {
            command.Parameters.AddRange(parameters);
        }
    }
}
