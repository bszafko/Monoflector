using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Reflection;

namespace Monoflector.Data.Model
{
    /// <summary>
    /// Represents the root container.
    /// </summary>
    public class Root : ModelObject
    {
        /// <summary>
        /// Gets the data folder.
        /// </summary>
        public static string DataFolder
        {
            get
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                path = System.IO.Path.Combine(path, "Monoflector");
                Directory.CreateDirectory(path);
                return path;
            }
        }

        /// <summary>
        /// Gets the current root.
        /// </summary>
        public static Root Current
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the assembly set.
        /// </summary>
        public ModelCollection<AssemblySet> AssemblySets
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Root"/> class.
        /// </summary>
        public Root()
        {
            AssemblySets = new ModelCollection<AssemblySet>();
            Current = this;
        }

        // TODO: A proper pattern for saving/loading.

        /// <summary>
        /// Saves any persistable data.
        /// </summary>
        public void Save()
        {
            var doc = new XDocument();
            var rootElem = new XElement("preferences");
            doc.Add(rootElem);

            var sets = new XElement("assemblySets");
            rootElem.Add(sets);
            foreach(var set in AssemblySets)
            {
                var setElement = new XElement("set", new XAttribute("name", set.Name));
                sets.Add(setElement);

                foreach (var asm in set)
                {
                    var asmElement = new XElement("assembly", asm.Path);
                    setElement.Add(asmElement);
                }
            }

            var file = Path.Combine(DataFolder, "preferences.xml");

            if (File.Exists(file))
                File.Delete(file);
            doc.Save(file);
        }

        public void Load()
        {
            var file = Path.Combine(DataFolder, "preferences.xml");
            if (!File.Exists(file))
            {
                DefaultSettings();
            }
            else
            {
                var doc = XDocument.Load(file);
                foreach (var setElement in doc.Elements("preferences").Elements("assemblySets").Elements("set"))
                {
                    var set = new AssemblySet((string)setElement.Attribute("name"));
                    foreach (var asmElement in setElement.Elements("assembly"))
                    {
                        var asm = new AssemblyData(asmElement.Value);
                        set.Add(asm);
                    }
                    AssemblySets.Add(set);
                }
            }
        }

        private void DefaultSettings()
        {
            var set = new AssemblySet();
            set.Name = string.Format(".Net v{0}", new AssemblyName(typeof(string).Assembly.FullName).Version.ToString());
            set.Add(new AssemblyData(typeof(string).Assembly));
            set.Add(new AssemblyData(typeof(System.Xml.XmlElement).Assembly));
            AssemblySets.Add(set);
        }
    }
}
