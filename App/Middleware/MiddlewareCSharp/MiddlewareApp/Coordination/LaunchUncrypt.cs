using MiddlewareApp.Metier;
using MiddlewareApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp.Coordination
{
    public class LaunchUncrypt
    {

        public string[] StartUncryptWork(string userToken, string fileName, List<string> files)
        {
            UncryptWork UW = new UncryptWork();

            string[] result = UW.StartWork(userToken, fileName, files);
            MailWork.SendValidationMail(userToken);
            return result;
        }

        public void SendMail(string usertoken)
        {
            MailWork.SendValidationMail(usertoken);
        }
    }
}
