using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace Monoflector.Data.Decompiled
{
    /// <summary>
    /// Represents information about a type.
    /// </summary>
    public class TypeData : NamespaceMember
    {
        /// <summary>
        /// Gets the name of the member.
        /// </summary>
        public override string Name
        {
            get { return TypeDefinition.Name; }
        }

        /// <summary>
        /// Gets the type definition.
        /// </summary>
        public TypeDefinition TypeDefinition
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeData"/> class.
        /// </summary>
        /// <param name="definition">The definition.</param>
        public TypeData(TypeDefinition typeDefinition)
        {
            if (typeDefinition == null)
                throw new ArgumentNullException("typeDefinition");
            TypeDefinition = typeDefinition;
            Refresh();
        }

        private void Refresh()
        {
            foreach (var item in TypeDefinition.Methods)
            {
                Add(new MethodData(item));
            }
        }
    }
}
