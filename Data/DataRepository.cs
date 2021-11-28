using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public static class DataRepository
    {
        public static User GetUser(int id)
        {
            SqlCommand sql = new SqlCommand($"SELECT * FROM {User.Table} WHERE {User.Table}.ID = @ID");
            sql.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            DataSet dataSet = Database.Select(sql);

            foreach (DataTable dataTable in dataSet.Tables)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Role role = DataRepository.getRole((int)dataRow["Role_ID"]);

                    return new User(
                        (int) dataRow["ID"],
                        dataRow["Username"].ToString(),
                        dataRow["SecurityToken"].ToString(),
                        role
                    );
                }
            }

            return null;
        }

        public static int InsertUser(User user)
        {
            SqlCommand sql = new SqlCommand($"INSERT INTO {User.Table} (Username, SecurityToken, Role_ID) VALUES (@Username, @SecurityToken, @Role_ID)");
            sql.Parameters.Add("@Username", SqlDbType.VarChar).Value = user.Username;
            sql.Parameters.Add("@SecurityToken", SqlDbType.VarChar).Value = user.SecurityToken;
            sql.Parameters.Add("@Role_ID", SqlDbType.VarChar).Value = user.Role.ID;

            return Database.InsertUpdateDelete(sql);
        }

        public static Role getRole(int id)
        {
            SqlCommand sql = new SqlCommand($"SELECT * FROM {Role.Table} WHERE {Role.Table}.ID = @ID");
            sql.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            DataSet dataSet = Database.Select(sql);

            foreach (DataTable dataTable in dataSet.Tables)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    return new Role(
                        (int) dataRow["ID"], dataRow["Description"].ToString()
                    );
                }
            }

            return null;
        }

        public static int InsertRole(Role role)
        {
            SqlCommand sql = new SqlCommand($"INSERT INTO {Role.Table} (Description) VALUES (@Description)");
            sql.Parameters.Add("@Description", SqlDbType.VarChar).Value = role.Description;

            return Database.InsertUpdateDelete(sql);
        }

        public static int DeleteRolesWithDescription(string description)
        {
            SqlCommand sql = new SqlCommand($"DELETE FROM {Role.Table} WHERE {Role.Table}.description = @Description");
            sql.Parameters.Add("@Description", SqlDbType.VarChar).Value = description;

            return Database.InsertUpdateDelete(sql);
        }
    }
}
