using MiddlewareApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiddlewareApp.Metier
{
    class UncryptWork
    {
        public static bool interruptCall = false;

        public static string[] validFile = new string[4];

        public string[] StartWork(string userTok, string fileName, List<String> files)
        {
            //Genération la première clé AAAA
            KeyGeneratorService KG = new KeyGeneratorService();
            string key = KG.GenerateKey();

            validFile[0] = fileName;

            //Tant que JEE n'a pas renvoyé de fichier décrypté valide
            while (!interruptCall && key != "")
            {

                //Paraléllisation des tâches de déchiffrement, un fichier = un thread
                Parallel.ForEach(files, file =>
                {
                    //Lancer le service Uncrypt avec la clé donnée
                    UncryptService US = new UncryptService();
                    VerificationService VS = new VerificationService();

                    string uncipherText = US.Uncrypt(file, key);

                    //Envoyer le texte déchiffré au service de vérification
                    VS.Verify(uncipherText, key);
                }
                );

                //Générer la prochaine clé
                key = KG.GenerateKey(key);

            }

            while(validFile == null)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Fichier validé pas encore reçu...");
            }

            interruptCall = false;

            return validFile;

        }
    }
}
