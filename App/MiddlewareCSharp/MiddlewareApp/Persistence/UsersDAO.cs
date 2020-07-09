using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp.Persistence
{
    class UsersDAO
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=dev_project;persistsecurityinfo=True");

        public void OpenConnection()
        {
            con.Open();
        }
        public void CloseConnection()
        {
            con.Close();
        }

        public DataTable GetUsersTable()
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from users", con);

            da.Fill(dt);
            return dt;
        }
    }
}
