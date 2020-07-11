using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjetDevA4.Logic;
using ProjetDevA4.Presentation;
using ProjetDevA4.MiddlewareTcp;
using System.ServiceModel;

namespace ProjetDevA4.Service
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    class UploadService : IUncipherTcpCallback
    {
        
        public void SendFile(string userToken, string appToken, string filename, string[] content)
        {
            InstanceContext context = new InstanceContext(this);

            var client = new UncipherTcpClient(context);

            Message mes = new Message();
            mes.Data = content;
            mes.OperationName = filename;
            mes.TokenApp = appToken;
            mes.TokenUSer = userToken;

            string[] tempData = new string[4];

            
           client.GetUncryptedInfo(mes);
           
           
        }

        public void ReturnMessage(Message msg)
        {
            string[] tempData = new string[4];
            tempData = msg.Data;
            Console.WriteLine("{0} ; {1} ; {2} ", msg.Data[0], msg.Data[1], msg.Data[2]);

            Upload.ShowResult(tempData[0], tempData[1], tempData[2], tempData[3]);
        }

    }
}
