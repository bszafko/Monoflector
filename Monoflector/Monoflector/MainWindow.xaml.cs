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
using Monoflector.Data.Decompiled;
using Mono.Cecil;

namespace Monoflector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var set = new AssemblySet() { Name = ".Net 3.5" };
            set.Add(new AssemblyData(typeof(string).Assembly));

            var root = new Root();
            root.AssemblySet.Add(set);

            this.DataContext = root;

        }
    }
}
