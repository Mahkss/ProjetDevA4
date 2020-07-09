using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MiddlewareApp.Coordination;

namespace MiddlewareCSharp
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Authentification" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Authentification.svc ou Authentification.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Authentification : IAuthentification
    {
        public string CheckLogin(string login, string pwd, string appToken)
        {
            LaunchAuthentification LA = new LaunchAuthentification();
            string userToken = LA.StartAuthWork(appToken, login, pwd);
            return userToken;
        }

        public void DoWork()
        {

        }
    }
}
