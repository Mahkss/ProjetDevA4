using MiddlewareApp.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp.Coordination
{
    public class LaunchAuthentification
    {

        public string StartAuthWork(string appToken, string login, string pwd)
        {
            AuthentificationWork AW = new AuthentificationWork();
            string success;

            success = AW.StartWork(appToken, login, pwd);
            
            return success;
        }


    }
}
