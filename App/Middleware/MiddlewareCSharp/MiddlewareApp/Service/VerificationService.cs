using MiddlewareApp.Coordination;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp.Service
{
    class VerificationService
    {
        public void Verify(string text, string key)
        {

            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress("http://localhost:10080/receptionService/ReceptionServiceBean");

            /*ReceptionEndPointClient proxy = new ReceptionEndPointClient(myBinding, myEndpoint);
            string base64Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));

            bool result = proxy.createReceptionOperation(base64Text, key, filename);

            if (result)
            {
                LaunchInterrupt LI = new LaunchInterrupt();
                LI.StartInterrupt(filename, text, key, "secretInfo");
                Debug.WriteLine(text + " " + key);

            }*/
        }

    }
}
