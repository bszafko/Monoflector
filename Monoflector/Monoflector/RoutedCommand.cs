using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Monoflector
{
    /// <summary>
    /// Represents a routed command.
    /// </summary>
    public class RoutedCommand : ICommand
    {
        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Occurs when a request is made inquiring whether the command can be executed.
        /// </summary>
        /// <remarks>
        /// If any handler is attached to this, it will override the <see cref="IsExecutable"/>
        /// member.
        /// </remarks>
        public event EventHandler<QueryCanExecuteEventArgs> QueryCanExecute;

        /// <summary>
        /// Occurs when the command is executed.
        /// </summary>
        public event EventHandler<ExecuteEventArgs> CommandExecuted;

        private bool _isExecutable;
        /// <summary>
        /// Gets or sets a value indicating whether this instance can execute.
        /// </summary>
        /// <value>
        /// <see langword="true"></see> if this instance can execute; otherwise, <see langword="false"></see>.
        /// </value>
        public bool IsExecutable
        {
            get
            {
                return _isExecutable;
            }
            set
            {
                if (_isExecutable != value)
                {
                    _isExecutable = value;
                    var tmp = CanExecuteChanged;
                    if (tmp != null)
                        tmp(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoutedCommand"/> class.
        /// </summary>
        public RoutedCommand(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            Name = name;
            IsExecutable = true;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public virtual bool CanExecute(object parameter)
        {
            var tmp = QueryCanExecute;
            if (tmp != null)
            {
                var args = new QueryCanExecuteEventArgs(this, parameter);
                tmp(this, args);
                return _isExecutable = args.CanExecute;
            }
            else
            { 
                return IsExecutable;
            }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public virtual void Execute(object parameter)
        {
            var tmp = CommandExecuted;
            if (tmp != null)
                tmp(this, new ExecuteEventArgs(this, parameter));
        }
    }
}
