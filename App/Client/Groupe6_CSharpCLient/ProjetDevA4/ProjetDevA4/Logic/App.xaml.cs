using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ProjetDevA4.Presentation;
using ProjetDevA4.Service;

namespace ProjetDevA4.Logic
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private void App_StartUp(object sender, StartupEventArgs e)
		{
            _ = new LoginWindow();
        }

        }

}
