using System.Data.SqlClient;
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
        SqlConnection con = new SqlConnection("server=localhost;user id=test;password=test;database=dev_project;persistsecurityinfo=True");

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
            SqlDataAdapter da = new SqlDataAdapter("select * from users", con);

            da.Fill(dt);
            return dt;
        }
    }
}
