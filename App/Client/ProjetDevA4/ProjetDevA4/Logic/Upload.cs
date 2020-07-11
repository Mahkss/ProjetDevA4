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

namespace ProjetDevA4.Logic
{
    class Upload
    {
        public static void UploadFile(MainWindow window)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Texte|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                string FileName = System.IO.Path.GetFileName((openFileDialog.FileName));
                string[] Content = new string[1];
                Content[0] = File.ReadAllText(openFileDialog.FileName);

                UploadService service = new UploadService();
                service.SendFile(window.userToken, window.appToken, FileName, Content);

                MessageBox.Show("Le fichier \"" + FileName + "\" a bien été envoyé. \n\n Vous recevrez un e-mail lorsque le message aura été déchiffré.", "Fichier envoyé", MessageBoxButton.OK, MessageBoxImage.Information);
                window.FileList.Items.Add(new TxtFile() { Hour = DateTime.Now.ToString(), Name = FileName, Content = ShorteningContent(Content[0]) });
            }
        }

        private static string ShorteningContent(string content)
        {
            int max_length = 100;

            if (content.Length > max_length)
                return content.Substring(0, max_length) + "...";
            else
                return content;
        }

        public static void ShowResult(string fileName, string plainText, string secret, string key)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                ResultWindow RW = new ResultWindow(fileName, plainText, secret, key);
            });
        }

    }
    public class TxtFile
    {
        public string Hour { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
