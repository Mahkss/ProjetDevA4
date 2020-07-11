using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetDevA4.Presentation;
using Microsoft.Win32;
using System.Windows;
using System.IO;
using ProjetDevA4.Service;
using System.Text.RegularExpressions;
using System.Threading;

namespace ProjetDevA4.Logic
{
    class Upload
    {
        private Mutex mut = new Mutex();
        //private UploadService US = new UploadService();
        //public UploadService US1 { get => US; set => US = value; }

        public static void UploadFile(MainWindow window)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();


            if (openFileDialog.ShowDialog() == true)
            {
                string FileName = System.IO.Path.GetFileName(openFileDialog.FileName);
                string[] Content;
                string display = "";

                Regex reg = new Regex(@"file_\d*\.txt");


                if (reg.Match(openFileDialog.SafeFileName).Success)
                {
                    Content = new string[1];

                    //Content[0, 0] = FileName;
                    //Content[0, 1] = File.ReadAllText(openFileDialog.FileName);
                    Content[0] = File.ReadAllText(openFileDialog.FileName);

                    if (CheckContent(Content[0]))
                    {
                        UploadService US = new UploadService();
                        US.SendFile(window.userToken, window.appToken, FileName, Content);
                        

                        display = ShorteningContent(Content[0]);
                    }
                }
                else
                {
                    string[] textFiles = Directory.GetFiles(openFileDialog.FileName);
                    int i = 0;
                    //Content = new string[textFiles.Length, 2];

                    foreach (string file in textFiles)
                    {
                        if (openFileDialog.ShowDialog() == true)
                        {
                      //      if (CheckContent(Content[i, 1]))
                            {
                        //        Content[i, 0] = Path.GetFileName(openFileDialog.FileName);
                          //      Content[i, 1] = File.ReadAllText(openFileDialog.FileName);

                                display += " " + Path.GetFileName(openFileDialog.FileName);
                                i++;
                            }
                        }
                    }

                    display = ShorteningContent(display);

                    //UploadService.SendFile(window.userToken, window.appToken, FileName, Content);
                    
                }

                Console.WriteLine("allo");

                MessageBox.Show("Le fichier \"" + FileName + "\" a bien été envoyé. \n\n Vous recevrez un e-mail lorsque le message aura été déchiffré.", "Fichier envoyé", MessageBoxButton.OK, MessageBoxImage.Information);
                window.FileList.Items.Add(new TxtFile() { Hour = DateTime.Now.ToString(), Name = FileName, Content = display });
            }
        }

        private static bool CheckContent(string Content)
        {
            bool result = true;

            if (Content.Length == 0)
            {
                result = false;
            }

            return result;
        }

        private static string ShorteningContent(string content)
        {
            int max_length = 100;

            if (content.Length > max_length)
                return content.Substring(0, max_length) + "...";
            else
                return content;
        }

        public static ResultWindow CreateShowResult()
        {
            ResultWindow RW = new ResultWindow();
            return RW;

        }

        public static void ShowResult(ResultWindow rw, string fileName, string plainText, string secret, string key)
        {
            rw.Update(fileName, plainText, secret, key);
        }

    }
    public class TxtFile
    {
        public string Hour { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
