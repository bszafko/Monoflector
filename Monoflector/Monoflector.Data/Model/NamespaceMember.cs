using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector.Data.Model
{
    /// <summary>
    /// Represents information about a namespace member.
    /// </summary>
    public abstract class NamespaceMember : ModelCollection<NamespaceMember>
    {
        /// <summary>
        /// Gets the name of the member.
        /// </summary>
        public abstract string Name
        {
            get;
        }

        /// <summary>
        /// Gets the source code for the member.
        /// </summary>
        public virtual string SourceCode
        {
            get { return string.Empty; }
        }
    }
}
