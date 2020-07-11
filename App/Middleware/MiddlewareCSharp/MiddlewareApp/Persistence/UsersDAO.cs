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

        public void SetUserToken(string login, string usertoken)
        {
            using (SqlConnection con = new SqlConnection("server=localhost;user id=test;password=test;database=dev_project;persistsecurityinfo=True")) {

                SqlCommand command = new SqlCommand("UPDATE users SET user_token = @usertoken Where login = @login", con);
                command.Parameters.AddWithValue("@usertoken", usertoken);
                command.Parameters.AddWithValue("@login", login);
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
