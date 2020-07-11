using MiddlewareApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;

namespace MiddlewareApp.Service
{
    class RegisterUserTokenService
    {
        public static void RegisterUserToken(string login, string usertoken)
        {
            UsersDAO DB = new UsersDAO();

            //Recuperer la table Users
            DB.OpenConnection();
            DB.SetUserToken(login, usertoken);

            DB.CloseConnection();
            Debug.WriteLine("fin");
        }
    }
}