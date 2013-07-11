using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocketLabs.TestApp.Domain.Abstract;
using SocketLabs.TestApp.Domain.Entities;
using System.Data.SqlServerCe; 

namespace SocketLabs.TestApp.Domain.Concrete
{
    public class SqlCeLoginProvider : ILoginProvider
    {
        private string _ConnectionString;
        public SqlCeLoginProvider(string connectionString)
        {
            _ConnectionString = connectionString;
        }


        public bool TryLogin(string name, string password)
        {
            bool retVal = false;
            string sql = "SELECT 1 FROM Users WHERE Users.Name = @name AND Users.Passwrd = @pwd";
 
            using (SqlCeConnection connection = new SqlCeConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCeCommand sqlCmd = new SqlCeCommand(sql, connection))
                {
                    sqlCmd.Parameters.AddWithValue("@name", name);
                    sqlCmd.Parameters.AddWithValue("@pwd", password);
                    retVal = sqlCmd.ExecuteScalar() != null;
                }
            }

            return retVal;
        } 
    }
}
