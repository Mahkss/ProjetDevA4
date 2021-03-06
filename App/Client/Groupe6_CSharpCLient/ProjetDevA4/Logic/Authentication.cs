﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjetDevA4.Presentation;
using ProjetDevA4.Service;

namespace ProjetDevA4.Logic
{
    class Authentication
    {

        public static void Login(LoginWindow window)
        {
            string appToken = AppTokenGenerator();
            string userToken = AuthenticationService.Login(window.LoginTextBox.Text, window.PasswordBox.Password, appToken);

            if (userToken != "0")
            {
                _ = new MainWindow(userToken, appToken);
                window.Close();
            }
            else MessageBox.Show("L'identifiant ou le mot de passe est incorrect", "Erreur d'authentification", MessageBoxButton.OK, MessageBoxImage.Error);
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
