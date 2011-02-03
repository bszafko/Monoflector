using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Monoflector.Data;

namespace Monoflector
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            GlobalDispatcher.Dispatcher = this.Dispatcher;
            base.OnStartup(e);
        }
    }
}
