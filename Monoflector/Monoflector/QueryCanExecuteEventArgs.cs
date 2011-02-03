using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector
{
    /// <summary>
    /// Event arguments for querying whether a command can execute.
    /// </summary>
    public class QueryCanExecuteEventArgs : EventArgs
    {
        /// <summary>
        /// Gets a value indicating whether the command can execute.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if the command can execute; otherwise, <see langword="false"/>.
        /// </value>
        public bool CanExecute
        {
            get;
            private set;
        }

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
        /// Initializes a new instance of the <see cref="QueryCanExecuteEventArgs"/> class.
        /// </summary>
        public QueryCanExecuteEventArgs(RoutedCommand command, object parameter)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            Command = command;
            Parameter = parameter;
        }

        /// <summary>
        /// Casts a vote to indicate the command can be executed.
        /// </summary>
        public void Yes()
        {
            CanExecute = true;
        }

        /// <summary>
        /// Casts a vote to indicate the command can be executed, if a condition is
        /// matched.
        /// </summary>
        /// <param name="condition">If set to <see langword="true"/> the command can be executed; otherwise, </param>
        public void YesIf(bool condition)
        {
            CanExecute |= condition;
        }
    }
}
