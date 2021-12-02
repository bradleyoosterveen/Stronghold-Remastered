using System;
using System.Data;
using System.Data.SqlClient;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using Utility;

namespace Data
{
    public static class Database
    {
        public static SqlConnection SqlConnection;
        public static SqlServerCompiler SqlServerCompiler;
        public static QueryFactory QueryFactory;

        public static Feedback Initialize()
        {
            if (DotNetEnv.Env.GetString("DB_Host") == null)
                return new Feedback(Feedback.Type.Error, "Could not connect to the database.");

            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = DotNetEnv.Env.GetString("DB_Host");
            cs.UserID = DotNetEnv.Env.GetString("DB_User");
            cs.Password = DotNetEnv.Env.GetString("DB_Password");
            cs.InitialCatalog = DotNetEnv.Env.GetString("DB_Database");

            Database.SqlConnection = new SqlConnection(cs.ConnectionString);

            Database.SqlServerCompiler = new SqlServerCompiler();

            Database.QueryFactory = new QueryFactory(Database.SqlConnection, Database.SqlServerCompiler);

            return new Feedback(Feedback.Type.Success, "Successfully connected to the database.");
        }
    }
}
