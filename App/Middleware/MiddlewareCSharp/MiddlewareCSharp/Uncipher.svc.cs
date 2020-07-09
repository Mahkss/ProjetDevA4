using MiddlewareApp.Coordination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MiddlewareCSharp
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Uncipher" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Uncipher.svc ou Uncipher.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Uncipher : IUncipher
    {
        public void DoWork()
        {
        }

        public Message GetUncryptedInfo(Message msg)
        {
            LaunchUncrypt LU = new LaunchUncrypt();

            string[] validFile = LU.StartUncryptWork(msg.TokenUSer , msg.OperationName, msg.Data.ToList());

            Message response = new Message();
            response.OperationName = msg.OperationName;
            response.TokenApp = msg.TokenApp;
            response.TokenUSer = msg.TokenUSer;
            response.Data = validFile;

            return response;
        }

    }
}
