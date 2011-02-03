using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace Monoflector.Data.Decompiled
{
    /// <summary>
    /// Represents information about a module.
    /// </summary>
    public class ModuleData : NamespaceMember
    {
        private Dictionary<string, NamespaceData> _namespaces = new Dictionary<string, NamespaceData>();

        /// <summary>
        /// Gets the name of the member.
        /// </summary>
        public override string Name
        {
            get { return ModuleDefinition.Name; }
        }

        /// <summary>
        /// Gets the module definition.
        /// </summary>
        public ModuleDefinition ModuleDefinition
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleData"/> class.
        /// </summary>
        public ModuleData(ModuleDefinition moduleDefinition)
        {
            if (moduleDefinition == null)
                throw new ArgumentNullException("moduleDefinition");
            ModuleDefinition = moduleDefinition;

            Refresh();
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        private void Refresh()
        {
            Clear();
            foreach (var type in ModuleDefinition.Types)
            {
                if (!string.IsNullOrEmpty(type.Namespace))
                {
                    NamespaceData ns;
                    if (!_namespaces.TryGetValue(type.Namespace, out ns))
                    {
                        _namespaces.Add(type.Namespace, ns = new NamespaceData(type.Namespace));
                        Add(ns);
                    }
                    ns.Add(new TypeData(type));
                }
                else
                {
                    Add(new TypeData(type));
                }
            }
        }
    }
}
