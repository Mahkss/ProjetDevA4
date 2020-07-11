using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjetDevA4.Logic;
using ProjetDevA4.Presentation;
using ProjetDevA4.ServiceReference2;

namespace ProjetDevA4.Service
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    class UploadService : IUncipher2Callback
    {
        private ResultWindow rw;

        public void SendFile(string userToken, string appToken, string filename, string[] content)
        {

            rw = Upload.CreateShowResult();

            Task.Run(() =>
            {
                InstanceContext context = new InstanceContext(this);
                var client = new Uncipher2Client(context);

                Message mes = new Message();

                mes.OperationName = filename;
                mes.TokenApp = appToken;
                mes.TokenUSer = userToken;
                mes.Data = content;

                client.GetUncryptedInfo(mes);

                client.Close();

            });
        }

        public void UncipherEnd(Message msg)
        {
            
            object[] tempData = new string[4];

            tempData = msg.Data;

            Upload.ShowResult(rw, tempData[0].ToString(), tempData[1].ToString(), tempData[2].ToString(), tempData[3].ToString());
        }
    }
}
