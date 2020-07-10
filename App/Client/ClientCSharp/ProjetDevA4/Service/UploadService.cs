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

            ResultWindow rw = Upload.CreateShowResult();

             Task.Run(() =>
             {
            
                var client = new ServiceReference2.UncipherClient();

                Message mes = new Message();

                object[] tempData = new string[4];

                mes.OperationName = filename;
                mes.TokenApp = appToken;
                mes.TokenUSer = userToken;
                mes.Data = content;
            
                mes = client.GetUncryptedInfo(mes);

                tempData = mes.Data;

                client.Close();

                Upload.ShowResult(tempData[0].ToString(), tempData[1].ToString(), tempData[2].ToString(), tempData[3].ToString());

             });



        }
    }
}
