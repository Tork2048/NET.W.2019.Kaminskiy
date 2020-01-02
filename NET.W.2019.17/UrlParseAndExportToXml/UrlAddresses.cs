// <copyright file="UrlAddresses.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseFileAndExportXML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// Class that contains List of parsed Url addresses.
    /// Implements IXmlSerializable interface for further Xml export.
    /// </summary>
    public class UrlAddresses : IXmlSerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlAddresses"/> class.
        /// </summary>
        /// <param name="addresses">
        /// List of parsed Urls addresses (of UrlAddress objects).
        /// </param>
        public UrlAddresses(List<UrlAddress> addresses)
        {
            if (addresses == null)
            {
                throw new ArgumentNullException(nameof(addresses), message: "Unable to construct object with null");
            }

            this.Addresses = addresses;
        }

        /// <summary>
        /// Gets List of parsed Urls addresses.
        /// </summary>
        public List<UrlAddress> Addresses { get; private set; }

        /// <summary>
        /// IXmlSerializable implementation of GetSchema method.
        /// </summary>
        /// <returns>
        /// Always returns null.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// IXmlSerializable interface implementation of ReadXml method.
        /// </summary>
        /// <param name="reader">
        /// Used as XmlReader.
        /// </param>
        public void ReadXml(XmlReader reader)
        {
            List<UrlAddress> addresses = new List<UrlAddress>();

            reader.ReadStartElement();

            while (reader.Name == "urlAddress")
            {
                UrlAddress address = new UrlAddress();

                reader.ReadStartElement();

                XElement host = (XElement)XNode.ReadFrom(reader);
                address.Host = (string)host.Attribute("name");

                if (reader.Name == "uri")
                {
                    XElement uri = (XElement)XNode.ReadFrom(reader);
                    address.Uri = uri.Elements("segment").Select(element => element.Value).ToArray();
                }

                if (reader.Name == "parameters")
                {
                    XElement parameters = (XElement)XNode.ReadFrom(reader);
                    address.Parameters = parameters.Elements("parameter").ToDictionary(element => (string)element.Attribute("key"), element => (string)element.Attribute("value"));
                }

                reader.ReadEndElement();

                addresses.Add(address);
            }

            reader.ReadEndElement();

            this.Addresses = addresses;
        }

        /// <summary>
        /// IXmlSerializable interface implementation of WriteXml method.
        /// </summary>
        /// <param name="writer">
        /// Used as XmlWriter.
        /// </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("urlAddresses");

            foreach (var address in this.Addresses)
            {
                this.WriteAddress(writer, address);
            }

            writer.WriteEndElement();
        }

        /// <summary>
        /// Supplementary class that handles XmlWrite of individual UrlAddress as a fragment.
        /// </summary>
        /// <param name="writer">
        /// Used as XmlWriter.
        /// </param>
        /// <param name="address">
        /// UrlAddress instance.
        /// </param>
        private void WriteAddress(XmlWriter writer, UrlAddress address)
        {
            writer.WriteStartElement("urlAddress");
            writer.WriteStartElement("host");

            writer.WriteAttributeString("name", address.Host);
            writer.WriteEndElement();

            if (address.Uri != null && address.Uri.Length > 0)
            {
                writer.WriteStartElement("uri");

                foreach (var segment in address.Uri)
                {
                    XElement element = new XElement("segment", segment);
                    element.WriteTo(writer);
                }

                writer.WriteEndElement();
            }

            if (address.Parameters != null && address.Parameters.Count > 0)
            {
                writer.WriteStartElement("parameters");

                foreach (var item in address.Parameters)
                {
                    XElement element = new XElement("parameter", new XAttribute("key", item.Key), new XAttribute("value", item.Value));
                    element.WriteTo(writer);
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}
