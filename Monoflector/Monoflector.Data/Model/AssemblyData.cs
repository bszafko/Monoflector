using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace Monoflector.Data.Model
{
    /// <summary>
    /// Represents data about an assembly.
    /// </summary>
    public class AssemblyData : NamespaceMember
    {
        /// <summary>
        /// Gets or sets the name of the assembly.
        /// </summary>
        /// <value>
        /// The name of the assembly.
        /// </value>
        public override string Name
        {
            get
            {
                return _assemblyDefinition.Name.Name;
            }
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        public string Path
        {
            get;
            private set;
        }

        private AssemblyDefinition _assemblyDefinition;
        /// <summary>
        /// Gets or sets the assembly definition.
        /// </summary>
        /// <value>
        /// The assembly definition.
        /// </value>
        public AssemblyDefinition AssemblyDefinition
        {
            get
            {
                return _assemblyDefinition;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyData"/> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        private AssemblyData(Mono.Cecil.AssemblyDefinition assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");
            _assemblyDefinition = assembly;
            Refresh();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyData"/> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public AssemblyData(System.Reflection.Assembly assembly)
            : this(assembly.Location)
        {
            Path = assembly.Location;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyData"/> class.
        /// </summary>
        /// <param name="assemblyLocation">The assembly location.</param>
        public AssemblyData(string assemblyLocation)
            : this(AssemblyDefinition.ReadAssembly(assemblyLocation))
        {
            Path = assemblyLocation;
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        private void Refresh()
        {
            Clear();
            foreach (var item in AssemblyDefinition.Modules)
            {
                this.Add(new ModuleData(item));
            }
        }
    }
}
