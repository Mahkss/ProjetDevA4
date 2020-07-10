using MiddlewareApp.Metier;
using MiddlewareApp.Service;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiddlewareApp.Coordination
{
    public class LaunchUncrypt
    {

        //public string[] result;

        public string[] StartUncryptWork(string userToken, string fileName, string file)
        {

            //AsyncMethod(userToken, fileName, file);

            UncryptWork UW = new UncryptWork();
            string[] result = UW.StartWork(userToken, fileName, file);
            
            return result;
        }

        public async void AsyncMethod(string userToken, string fileName, string file)
        {

            UncryptWork UW = new UncryptWork();

            string[] result;

            result = UW.StartWork(userToken, fileName, file);
            
        }
    }
}
