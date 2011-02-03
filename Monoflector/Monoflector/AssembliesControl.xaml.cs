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
using Microsoft.Win32;

namespace Monoflector
{
    /// <summary>
    /// Interaction logic for AssembliesControl.xaml
    /// </summary>
    public partial class AssembliesControl : UserControl
    {
        public AssembliesControl()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse For Assembly";
            dlg.Filter = "Dlls (*.dll)|*.dll|Executables (*.exe)|*.exe";
            dlg.FilterIndex = 0;
            dlg.CheckFileExists = true;
            dlg.Multiselect = false;

            if (dlg.ShowDialog().GetValueOrDefault())
            {
                _filenameTextBox.Text = dlg.FileName;
            }
        }

        private void InvalidateCommands(object sender, TextChangedEventArgs e)
        {
            _addButton.IsEnabled = !string.IsNullOrEmpty(_filenameTextBox.Text);
        }
    }
}
