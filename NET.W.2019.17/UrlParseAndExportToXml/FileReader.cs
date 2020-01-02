// <copyright file="FileReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseFileAndExportXML
{
    using System;
    using System.IO;

    /// <summary>
    /// Class designed to read Urls from text file.
    /// </summary>
    public class FileReader
    {
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="path">
        /// Used as a path text file that contains Urls.
        /// </param>
        public FileReader(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Read method that splits Urls into array of strings.
        /// </summary>
        /// <returns>
        /// Array of strings.
        /// </returns>
        public string[] ReadFile()
        {
            string result;

            using (StreamReader sr = new StreamReader(this.path))
            {
                result = sr.ReadToEnd();
            }

            return this.SplitStrings(result);
        }

        private string[] SplitStrings(string str)
        {
            string[] result = str.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            return result;
        }
    }
}
