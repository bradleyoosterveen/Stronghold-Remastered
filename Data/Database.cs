using System;
using System.Data;
using System.Data.SqlClient;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Data
{
    public static class Database
    {
        public static SqlConnection SqlConnection;
        public static SqlServerCompiler SqlServerCompiler;
        public static QueryFactory QueryFactory;

        public static void Initialize()
        {
            if (DotNetEnv.Env.GetString("DB_Host") == null)
                return;

            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = DotNetEnv.Env.GetString("DB_Host");
            cs.UserID = DotNetEnv.Env.GetString("DB_User");
            cs.Password = DotNetEnv.Env.GetString("DB_Password");
            cs.InitialCatalog = DotNetEnv.Env.GetString("DB_Database");

            Database.SqlConnection = new SqlConnection(cs.ConnectionString);

            Database.SqlServerCompiler = new SqlServerCompiler();

            Database.QueryFactory = new QueryFactory(Database.SqlConnection, Database.SqlServerCompiler);
        }
    }
}
