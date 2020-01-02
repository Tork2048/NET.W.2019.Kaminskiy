// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseFileAndExportXML
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Entry point class.
    /// </summary>
    public class Program
    {
        private const string PATH = "URL.txt";

        /// <summary>
        /// Emtry point method (Main).
        /// </summary>
        /// <param name="args">
        /// Start arguments - not implemented.
        /// </param>
        public static void Main(string[] args)
        {
            FileReader fReader = new FileReader(PATH);
            string[] uStrings = fReader.ReadFile();
            DisplayStrings(uStrings);

            URLParser parser = new URLParser();
            parser.OnParseFailed += DisplayEvenet;

            IXmlSerializable urlAddresses = parser.Parse(uStrings);
            XmlExporter xmlExporter = new XmlExporter(urlAddresses);
            xmlExporter.WriteToXml("E:\\newXML.xml");

            Console.ReadKey();
        }

        /// <summary>
        /// Method outputs arrays of strings (Urls) to console.
        /// </summary>
        /// <param name="str">
        /// Arrays of strings.
        /// </param>
        public static void DisplayStrings(string[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine(str[i]);
            }
        }

        /// <summary>
        /// Method that is called when parser event is triggered.
        /// Outputs event information on console.
        /// </summary>
        /// <param name="sender">
        /// Caller object.
        /// </param>
        /// <param name="args">
        /// Event arguments - event information.
        /// </param>
        public static void DisplayEvenet(object sender, ParserEventArgs args)
        {
            Console.WriteLine($"Unable to process line {args.Line} - {args.Message}");
        }
    }
}
