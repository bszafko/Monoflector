using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Monoflector
{
    /// <summary>
    /// Represents the WPF-specific commands.
    /// </summary>
    public static class Commands
    {
        /// <summary>
        /// The command that shows the assemblies panel.
        /// </summary>
        public static readonly RoutedCommand ShowAssemblies = new RoutedCommand("Core.Navigation.ShowAssemblies");

        /// <summary>
        /// The command that shows the navigator.
        /// </summary>
        public static readonly RoutedCommand ShowNavigator = new RoutedCommand("Core.Navigation.ShowNavigator");

        /// <summary>
        /// The command that adds an assembly.
        /// </summary>
        public static readonly RoutedCommand AddAssembly = new RoutedCommand("Root.AssemblySets.AddAssembly");
        
        /// <summary>
        /// Initializes the <see cref="Commands"/> class.
        /// </summary>
        static Commands()
        {
            
        }
    }
}
