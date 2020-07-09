using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjetDevA4.Presentation;
using ProjetDevA4.Service;
using System.Security.Cryptography;
using System.Diagnostics;

namespace ProjetDevA4.Logic
{
    class Authentication
    {

        public static void Login(LoginWindow window)
        {
            string appToken = AppTokenGenerator();
            string password = CreateMD5Hash(window.PasswordBox.Password);
            Debug.WriteLine(password);

            string userToken = AuthenticationService.Login(window.LoginTextBox.Text, password, appToken);

            if (userToken != "0")
            {
                _ = new MainWindow(userToken, appToken);
                window.Close();
            }
            else MessageBox.Show("L'identifiant ou le mot de passe est incorrect", "Erreur d'authentification", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static string CreateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static string AppTokenGenerator()
        {
            Random RandomNumber = new Random();
            int A = RandomNumber.Next(1, 10);
            int B = RandomNumber.Next(1, 10);

            int C = (A * B) / 10;
            int D = (A * B) % 10;

            int E = (A + B + C + D) / 10;
            int F = (A + B + C + D) % 10;

            int G = 9 - C;
            int H = 9 - D;
            int I = 9 - E;
            int J = 9 - F;

            string app_token = D.ToString() + H.ToString() + A.ToString() + C.ToString() + I.ToString() + F.ToString() + B.ToString() + J.ToString() + E.ToString() + G.ToString();

            //Console.WriteLine("AppToken: " + app_token);
            return app_token;
        }
    }
}
