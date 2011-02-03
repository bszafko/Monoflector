using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Monoflector.Data.Model;
using Mono.Cecil;

namespace Monoflector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Gets the root.
        /// </summary>
        public Root Root
        {
            get;
            private set;
        }

        public MainWindow()
        {
            InitializeComponent();

            Root = new Root();
            Root.Load();
            this.DataContext = Root;

            WireCommands();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Root.Save();
            base.OnClosing(e);
        }

        #region Command Handlers
        private void WireCommands()
        {
            Commands.ShowAssemblies.CommandExecuted += ShowAssemblies_CommandExecuted;
            Commands.ShowNavigator.CommandExecuted += ShowNavigator_CommandExecuted;
        }

        void ShowNavigator_CommandExecuted(object sender, ExecuteEventArgs e)
        {
            ChangePanel(_navigator);
        }

        void ShowAssemblies_CommandExecuted(object sender, ExecuteEventArgs e)
        {
            ChangePanel(_assemblies);
        }
        #endregion

        private void ChangePanel(UIElement newPanel)
        {
            foreach (UIElement control in _primaryGrid.Children)
            {
                if (control == newPanel)
                {
                    control.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    control.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
        } 
    }
}
