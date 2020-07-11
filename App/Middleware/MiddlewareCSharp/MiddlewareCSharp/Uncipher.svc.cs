using MiddlewareApp.Coordination;
using System;
using MiddlewareApp.Service;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace MiddlewareCSharp
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Uncipher" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Uncipher.svc ou Uncipher.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Uncipher : IUncipher
    {


        public Message GetUncryptedInfo(Message msg)
        {
            //Namespace Coordination courcicuité pour gagner du temps. A réagencer
            /*if (!MiddlewareApp.Service.AuthentificationCheckService.CheckUserToken(msg.TokenUSer))
            {
                msg.StatusOp = false;
                return msg;
            } */

            LaunchUncrypt LU = new LaunchUncrypt();

            string[] validFile = LU.StartUncryptWork(msg.TokenUSer , msg.OperationName, msg.Data.ToList());

            //callback plutot, à faire -- Envoie l'e-mail de validation
            LU.SendMail(msg.TokenUSer);

            Message response = new Message();
            response.OperationName = msg.OperationName;
            response.TokenApp = msg.TokenApp;
            response.TokenUSer = msg.TokenUSer;
            response.Data = validFile;
            OperationContext.Current.GetCallbackChannel<IUncipherCallback>().Test();
            return response;
        }

    }
}
