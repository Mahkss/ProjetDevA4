using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MiddlewareApp.Service;

namespace MiddlewareApp.Metier
{
    class MailWork
    {
        public static void SendValidationMail(string user_token)
        {
            MailMessage message = new MailMessage("projet_dev@pansera.fr", AuthentificationCheckService.GetMailAdress(user_token));
            message.Subject = "Fichier décrypté";
            message.Body = @"Un fichier a été décrypté ! Rendez-vous sur l'application pour consulter les résultats.";
            SmtpClient MailServer = new SmtpClient("ssl0.ovh.net");
            MailServer.Port = 587;
            //l'adresse mail si dessous a été créée uniquement pour ce projet et sera suppprimé ensuite
            MailServer.Credentials = new System.Net.NetworkCredential("projet_dev@pansera.fr", "projet_dev");

            try
            {
                MailServer.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'envoie du mail: {0}",
                    ex.ToString());
            }
        }
    }
}