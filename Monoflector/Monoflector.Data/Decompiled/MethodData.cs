using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Cecil.Decompiler;
using Cecil.Decompiler.Languages;

namespace Monoflector.Data.Decompiled
{
    /// <summary>
    /// Represents data about a method.
    /// </summary>
    public class MethodData : NamespaceMember
    {
        /// <summary>
        /// Gets the name of the member.
        /// </summary>
        public override string Name
        {
            get { return MethodDefinition.Name; }
        }

        /// <summary>
        /// Gets the method definition.
        /// </summary>
        public MethodDefinition MethodDefinition
        {
            get;
            private set;
        }

        private string _sourceCode;
        /// <summary>
        /// Gets the source code for the member.
        /// </summary>
        public override string SourceCode
        {
            get
            {
                if (_sourceCode == null)
                {
                    _sourceCode = DecompilerServices.GetCode(MethodDefinition);
                }
                return _sourceCode;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodData"/> class.
        /// </summary>
        public MethodData(MethodDefinition methodDefinition)
        {
            if (methodDefinition == null)
                throw new ArgumentNullException("methodDefinition");
            MethodDefinition = methodDefinition;
        }
    }
}
