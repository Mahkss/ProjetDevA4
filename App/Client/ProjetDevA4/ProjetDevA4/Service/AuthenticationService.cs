using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevA4.Service
{
    class AuthenticationService
    {
        public static string Login(string login, string password, string Apptoken)
        {
            var client = new MiddlewareWCF.AuthentificationClient();

            var UserToken = client.CheckLogin(login, password, Apptoken);

            client.Close();

            return UserToken;
            //return 10;
        }
    }
}
