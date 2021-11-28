using System;
using System.Data;
using System.Data.SqlClient;

namespace Data
{

    public static class Database
    {
        private static SqlConnectionStringBuilder _connectionString;
        private static SqlConnection _connection;
        private static SqlCommand _command;
        private static SqlDataAdapter _adapter;
        private static string ConnectionString()
        {
            _connectionString = new SqlConnectionStringBuilder();
            _connectionString.DataSource = DotNetEnv.Env.GetString("DB_Host");
            _connectionString.UserID = DotNetEnv.Env.GetString("DB_User");
            _connectionString.Password = DotNetEnv.Env.GetString("DB_Password");
            _connectionString.InitialCatalog = DotNetEnv.Env.GetString("DB_Database");
            return _connectionString.ConnectionString;
        }
        public static void EnsureConnection()
        {
            ConnectionString();
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString.ConnectionString);
                _connection.Open();
            }
        }
        public static int InsertUpdateDelete(SqlCommand command)
        {
            try
            {
                EnsureConnection();
                _command = command;
                _command.Connection = _connection;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return _command.ExecuteNonQuery();
        }
        public static DataSet Select(SqlCommand command)
        {
            DataSet ds = new DataSet();
            try
            {
                EnsureConnection();
                _command = command;
                _command.Connection = _connection;
                _adapter = new SqlDataAdapter(_connectionString.ConnectionString, _connection);
                _adapter.SelectCommand = _command;
                _adapter.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ds;
        }
        public static void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
