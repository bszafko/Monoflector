using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector.Data.Model
{
    /// <summary>
    /// Represents namespace data.
    /// </summary>
    public class NamespaceData : NamespaceMember
    {
        private string _name;
        /// <summary>
        /// Gets the name of the member.
        /// </summary>
        public override string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceData"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public NamespaceData(string name)
        {
            _name = name;
        }
    }
}
