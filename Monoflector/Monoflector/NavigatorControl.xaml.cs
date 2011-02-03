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

namespace Monoflector
{
    /// <summary>
    /// Interaction logic for NavigatorControl.xaml
    /// </summary>
    public partial class NavigatorControl : UserControl
    {
        public Root Root
        {
            get
            {
                return DataContext as Root;
            }
        }

        public NavigatorControl()
        {
            InitializeComponent();
        }

        void AssemblySets_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SelectDefaultItem();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Root != null)
            {
                Root.AssemblySets.CollectionChanged += AssemblySets_CollectionChanged;
                SelectDefaultItem();
            }
        }

        private void SelectDefaultItem()
        {
            if (Root != null &&
                Root.AssemblySets.Count > 0 && 
                _setsTabControl.SelectedIndex == -1)
                _setsTabControl.SelectedIndex = 0;
        }
    }
}
