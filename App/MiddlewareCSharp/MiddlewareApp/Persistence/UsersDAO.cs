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
        SqlConnection con = new SqlConnection(@"Data Source=LOÏC\TEW_SQLEXPRESS;Initial Catalog=dev_middleware;Integrated Security=True");

        public void OpenConnection()
        {
            con.Open();

            // Insert a user login ID and PWD (after deleting table rows)
            String sql = "DELETE FROM users";
            String sql2 = "INSERT INTO users (login,pwd) VALUES ('Loic', '5F4DCC3B5AA765D61D8327DEB882CF99')";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
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
