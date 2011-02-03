using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil.Cil;
using Cecil.Decompiler;
using Cecil.Decompiler.Languages;
using Mono.Cecil;
using System.IO;

namespace Monoflector.Data
{
    /// <summary>
    /// Represents the decompiler services.
    /// </summary>
    public static class DecompilerServices
    {
        /// <summary>
        /// Gets the code for the specified method body.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public static string GetCode(this MethodDefinition method)
        {
            using (var writer = new StringWriter())
            {
                try
                {
                    CSharp.GetLanguage(CSharpVersion.V3).GetWriter(new PlainTextFormatter(writer)).Write(method);
                }
                catch
                {
                    return string.Empty;
                }
                return writer.ToString();
            }
        }
    }
}
