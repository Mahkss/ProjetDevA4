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

        public string[] StartWork(string userTok, string fileName, string file)
        {
            //Task.Run(() =>
            //{
                //Genération de la première clé AAAA
                KeyGeneratorService KG = new KeyGeneratorService();
            string key = KG.GenerateKey();


            Thread.Sleep(5000);

            //Tant que JEE n'a pas renvoyé de fichier décrypté valide
            while (!interruptCall && key != "")
            {

                //Paraléllisation des tâches de déchiffrement, un fichier = un thread
                
                    //Lancer le service Uncrypt avec la clé donnée
                    UncryptService US = new UncryptService();
                    VerificationService VS = new VerificationService();

                    string uncipherText = US.Uncrypt(file, key);

                    //Envoyer le texte déchiffré au service de vérification
                    Task.Run(() => VS.Verify(fileName, uncipherText, key));

                //Générer la prochaine clé
                key = KG.GenerateKey(key);

            }

            while(validFile[0] == null)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Fichier validé pas encore reçu...");
            }

            //});

            /*validFile[0] = fileName;
            validFile[1] = "test text";
            validFile[2] = "test key";
            validFile[3] = "test info";*/

            return validFile;
        }
    }
}
