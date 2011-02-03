using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace Monoflector.Data
{
    /// <summary>
    /// Represents the global dispatcher.
    /// </summary>
    public static class GlobalDispatcher
    {
        /// <summary>
        /// Gets or sets the dispatcher.
        /// </summary>
        /// <value>
        /// The dispatcher.
        /// </value>
        public static Dispatcher Dispatcher
        {
            get;
            set;
        }

#if WPF
        /// <summary>
        /// Dispatches a call to the specified event handler.
        /// </summary>
        /// <typeparam name="TEventArgs">The type of the event args.</typeparam>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="TEventArgs"/> instance containing the event data.</param>
        public static void Dispatch<TEventArgs>(this EventHandler<TEventArgs> handler, object sender, TEventArgs eventArgs)
            where TEventArgs : EventArgs
        {
            if (handler != null)
            {
                if (Dispatcher == null)
                    handler(sender, eventArgs);
                else
                    Dispatcher.Invoke(handler, sender, eventArgs);
            }
        }

        /// <summary>
        /// Dispatches a call to the specified event handler.
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public static void Dispatch(this EventHandler handler, object sender, EventArgs eventArgs)
        {
            if (handler != null)
            {
                if (Dispatcher == null)
                    handler(sender, eventArgs);
                else
                    Dispatcher.Invoke(handler, sender, eventArgs);
            }
        }

        /// <summary>
        /// Dispatches a call to the specified event method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="arguments">The arguments.</param>
        public static void Dispatch(this Delegate method, params object[] arguments)
        {
            if (method != null)
            {
                if (Dispatcher == null)
                    method.DynamicInvoke(arguments);
                else
                    Dispatcher.Invoke(method, arguments);
            }
        }
#endif
    }
}
