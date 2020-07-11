using MiddlewareApp.Coordination;
using MiddlewareApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Timers;
using MiddlewareApp.ReferenceReceptionJEE;

namespace MiddlewareApp.Service
{
    class VerificationService
    {
        private static Timer aTimer;

        public void Verify(string text, string key, String fileName)
        {
            sendXMLMessage(text, key, fileName);
        }

        private void sendXMLMessage(string decipheredText, string usedKey, string fileName)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            //myBinding.MessageEncoding = WSMessageEncoding.Text;
            myBinding.CloseTimeout = new TimeSpan(1000000000);
            myBinding.OpenTimeout = new TimeSpan(1000000000);
            myBinding.ReceiveTimeout = new TimeSpan(1000000000);
            myBinding.SendTimeout = new TimeSpan(1000000000);
            EndpointAddress myEndpoint = new EndpointAddress("http://localhost:10080/receptionService/ReceptionServiceBean");

            ReceptionEndPointClient proxy = new ReceptionEndPointClient(myBinding, myEndpoint);
            string base64Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(decipheredText));

            proxy.createReceptionOperation(base64Text, usedKey, fileName);
        }

        private void consolLogTimer()
        {
            // Create a timer and set a two second interval.
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 2000;
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;
            // Start the timer
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine("Verification in progress ... ({0})", e.SignalTime);
        }
    }
}
