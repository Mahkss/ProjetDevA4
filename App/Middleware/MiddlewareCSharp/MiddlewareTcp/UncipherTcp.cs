using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MiddlewareApp.Coordination;

namespace MiddlewareCSharp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UncipherTcp" in both code and config file together.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class UncipherTcp : IUncipherTcp
    {
        public void GetUncryptedInfo(Message msg)
        {
            OperationContext current = OperationContext.Current;
            //Namespace Coordination courcicuité pour gagner du temps. A réagencer
            if (!MiddlewareApp.Service.AuthentificationCheckService.CheckUserToken(msg.TokenUSer))
            {
                msg.StatusOp = false;
                //--Lever exception---      A FAIRE
            } 
            Task.Run(() =>
            {
                LaunchUncrypt LU = new LaunchUncrypt();
                LU.SendMail(msg.TokenUSer);

                string[] validFile = LU.StartUncryptWork(msg.TokenUSer, msg.OperationName, msg.Data.ToList());

                //callback plutot, à faire -- Envoie l'e-mail de validation
                LU.SendMail(msg.TokenUSer);

                Message response = new Message();
                response.OperationName = msg.OperationName;
                response.TokenApp = msg.TokenApp;
                response.TokenUSer = msg.TokenUSer;
                response.Data = validFile;
                current.GetCallbackChannel<IUncipherTcpCallback>().ReturnMessage(response);
            });
        }
    }
}
