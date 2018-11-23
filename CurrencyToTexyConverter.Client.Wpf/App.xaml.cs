using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace CurrencyToTexyConverter.Client.Wpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootStrapper = new BootStrapper();

            var mainWindow = bootStrapper.Container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
