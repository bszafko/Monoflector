using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector.Data.Model
{
    /// <summary>
    /// Represents an assembly set (list of assemblies defined by the user).
    /// </summary>
    public class AssemblySet : ModelCollection<AssemblyData>
    {
        private string _name;
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetPropertyValue("Name", ref _name, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblySet"/> class.
        /// </summary>
        public AssemblySet()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblySet"/> class.
        /// </summary>
        public AssemblySet(string name)
        {
            Name = name;
        }
    }
}
