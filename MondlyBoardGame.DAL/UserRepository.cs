using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondlyBoardGame.DAL
{
    public class UserRepository : RepositoryBase
    {   


        public bool IsValidUser(string userName)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = Commands.IsValidUser;

                    cmd.Parameters.AddWithValue("@Name", userName);

                    var result = cmd.ExecuteScalar();

                    return result != null;
                }
            }
        }
    }
}
