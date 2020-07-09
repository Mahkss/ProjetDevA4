using MiddlewareApp.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp.Coordination
{
    public class LaunchInterrupt
    {
        public void StartInterrupt(string text, string key, string info)
        {
            MailWork.SendValidationMail();

            UncryptWork.validFile[1] = text;
            UncryptWork.validFile[2] = key;
            UncryptWork.validFile[3] = info;

            UncryptWork.interruptCall = true;
        }
    }
}
