using MiddlewareApp.Service;
using MySql.Data.X.XDevAPI.Common;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp.Metier
{
    class AuthentificationWork
    {
        public string StartWork(string appToken, string login, string pwd)
        {

            //Vérification du Token Application
            if (CheckAppToken(appToken))
            {
                AuthentificationCheckService AC = new AuthentificationCheckService();

                //Vérification du login et mot de passe
                if(AC.GetUser(login, pwd))
                {
                    return GenerateUserToken(login, pwd);
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }

        private string GenerateUserToken(string login, string pwd)
        {
            return "123456789";
        }

        //Vérification du Token Application
        private bool CheckAppToken(string aT)
        {
            bool valid = false;

            int A = aT[2] - 48;
            int B = aT[6] - 48;
            int C = aT[3] - 48;
            int D = aT[0] - 48;
            int E = aT[8] - 48;
            int F = aT[5] - 48;
            int G = aT[9] - 48;
            int H = aT[1] - 48;
            int I = aT[4] - 48;
            int J = aT[7] - 48;

            if ((A * B)/10 == C && (A * B)%10 == D )
            {
                if (E == (A + B + C + D)/10 && F == (A + B + C + D) % 10)
                {
                    if (G == (9 - C) && H == (9 - D) && I == (9 - E) && J == (9 - F))
                    {
                        valid = true;
                    }
                }
            }
            Console.WriteLine("AppToken Valide: " + valid);
            return valid;
        }
    }
}
