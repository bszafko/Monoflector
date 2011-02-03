using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector.Data.Decompiled
{
    /// <summary>
    /// Represents the root container.
    /// </summary>
    public class Root : ModelObject
    {
        /// <summary>
        /// Gets the assembly set.
        /// </summary>
        public ModelCollection<AssemblySet> AssemblySet
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Root"/> class.
        /// </summary>
        public Root()
        {
            AssemblySet = new ModelCollection<AssemblySet>();
        }
    }
}
