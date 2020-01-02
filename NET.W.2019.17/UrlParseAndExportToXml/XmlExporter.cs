// <copyright file="XmlExporter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseFileAndExportXML
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Class that exports object to Xml file.
    /// Can work with any IXmlSerializable object.
    /// </summary>
    public class XmlExporter
    {
        private const string DefaultPath = "UrlAddresses.xml";
        private readonly IXmlSerializable source;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlExporter"/> class.
        /// Takes IXmlSerializable object as a dependency.
        /// </summary>
        /// <param name="source">
        /// Object to export.
        /// </param>
        public XmlExporter(IXmlSerializable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), message: "Unable to construct XmlExportImport with null");
            }

            this.source = source;
        }

        /// <summary>
        /// Version of method that takes filepath to export to.
        /// </summary>
        /// <param name="path">
        /// File path.
        /// </param>
        public void WriteToXml(string path)
        {
            using (XmlWriter writer = XmlWriter.Create(path))
            {
                this.source.WriteXml(writer);
            }
        }

        /// <summary>
        /// Overloaded version that uses class default path.
        /// </summary>
        public void WriteToXml()
        {
            this.WriteToXml(DefaultPath);
        }
    }
}
