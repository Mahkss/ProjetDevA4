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

        public string[] StartWork(string userTok, string fileName, List<String> filesOne)
        {
            //Genération la première clé AAAA
            KeyGeneratorService KG = new KeyGeneratorService();
            string key = KG.GenerateKey();

            validFile[0] = fileName;

            //Tant que JEE n'a pas renvoyé de fichier décrypté valide
            while (!interruptCall && key != "AWHJ")
            {

                //Paraléllisation des tâches de déchiffrement, un fichier = un thread (FAUX, un seul fichier est envoyé dans data[] depuis le client)
                Parallel.ForEach(filesOne, fileData =>
                {
                    //Lancer le service Uncrypt avec la clé donnée
                    UncryptService US = new UncryptService();
                    VerificationService VS = new VerificationService();

                    string uncipherText = US.Uncrypt(fileData, key);

                    //Envoyer le texte déchiffré au service de vérification
                    VS.Verify(uncipherText, key, fileName);
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
