using MiddlewareApp.Coordination;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp.Service
{
    class VerificationService
    {
        public void Verify(string text, string key)
        {

            Random RandomNumber = new Random();
            int A = RandomNumber.Next(1, 20);

            if(A == 2)
            {
                LaunchInterrupt LI = new LaunchInterrupt();
                LI.StartInterrupt(text, key, "secretInfo");
                Debug.WriteLine(text + " " + key);
            }
            
        }
    }
}
