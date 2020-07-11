using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using MiddlewareApp.ReferenceReceptionJEE;

namespace MiddlewareCSharp
{
    public class MessagingComponent : IContract
    {
        
        // Will receive a successful JEE verification request
        public MSG m_service(MSG msg)
        {
            if (msg.data != null && msg.data.Length > 0)
            {
                msg.op_statut = receiveXMLMessage(msg.tokenUser, msg.data);
            }
            Console.WriteLine("Fin du déchiffrage - information secrète trouvée");
            
            //TMP
            msg.info = "Déchiffrement terminé";
            // TODO : change msg data or others ...

            return msg;
        }

        public Boolean receiveXMLMessage(string fileName, object[] data)
        {
            sendMail();
            Boolean dataAdded = false;

            // TODO : fct that search or get the file data
            // ... dataAdded = true;

            return dataAdded;
        }

        public void sendMail()
        {
            // Instanciation du client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            //On indique au client d'utiliser les informations qu'on va lui fournir
            smtpClient.UseDefaultCredentials = true;
            //Ajout des informations de connexion
            smtpClient.Credentials = new System.Net.NetworkCredential("testprojetdevcesi@gmail.com", "lrjfzjzikqzwwcrc");
            //On indique que l'on envoie le mail par le réseau
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //On active le protocole SSL
            smtpClient.EnableSsl = true;

            MailMessage mail = new MailMessage();
            //Expéditeur
            mail.From = new MailAddress("testprojetdevcesi@gmail.com", "Décryptage du fichier terminé");
            //Destinataire
            mail.Body = "Le décryptage du fichier est terminé, vous pouvez télécharger le rapport PDF.";
            mail.To.Add(new MailAddress("clienttestcesi@gmail.com"));
            //Copie

            smtpClient.Send(mail);
        }

    }
}
