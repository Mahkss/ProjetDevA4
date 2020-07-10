using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjetDevA4.Logic;
using System.ServiceModel.Security.Tokens;

namespace ProjetDevA4.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string userToken;
        public string appToken;

        public MainWindow(string usrTok, string appTok)
        {
            InitializeComponent();

            userToken = usrTok;
            appToken = appTok;

            
        }

        public void Update()
        {
            this.Show();
        }


        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            Upload.UploadFile(this);
        }

    }
}
