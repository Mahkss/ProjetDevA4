using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjetDevA4.Logic;
using ProjetDevA4.Presentation;
using ProjetDevA4.ServiceReference2;

namespace ProjetDevA4.Service
{
    class UploadService
    {
        public static void SendFile(string userToken, string appToken, string filename, string[] content)
        {
            var client = new ServiceReference2.UncipherClient();

            Message mes = new Message();
            mes.Data = content;
            mes.OperationName = filename;
            mes.TokenApp = appToken;
            mes.TokenUSer = userToken;

            string[] tempData = new string[4];

            Thread thread = new Thread(new ThreadStart( () =>
            {
                Message res = client.GetUncryptedInfo(mes);
                tempData = res.Data;
                Console.WriteLine("{0} ; {1} ; {2} ", res.Data[0], res.Data[1], res.Data[2]);
            }));

            thread.Start();

            while (thread.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(1000);
            }
            Upload.ShowResult(tempData[0], tempData[1], tempData[2], tempData[3]);

            client.Close();
        }
    }
}
