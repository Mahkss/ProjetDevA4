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
        public void StartInterrupt(string filename, string text, string key, string info)
        {

            UncryptWork.interruptCall = true;

            UncryptWork.validFile[0] = filename;
            UncryptWork.validFile[1] = text;
            UncryptWork.validFile[2] = key;
            UncryptWork.validFile[3] = info;

        }
    }
}
