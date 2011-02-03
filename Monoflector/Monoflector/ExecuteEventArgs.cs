using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector
{
    /// <summary>
    /// Represents event arguments about a command execution.
    /// </summary>
    public class ExecuteEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the command.
        /// </summary>
        public RoutedCommand Command
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the parameter.
        /// </summary>
        public object Parameter
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecuteEventArgs"/> class.
        /// </summary>
        public ExecuteEventArgs(RoutedCommand command, object parameter)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            Command = command;
            Parameter = parameter;
        }
    }
}
