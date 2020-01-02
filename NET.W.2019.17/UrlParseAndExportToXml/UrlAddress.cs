// <copyright file="UrlAddress.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseFileAndExportXML
{
    using System.Collections.Generic;

    /// <summary>
    /// Data class that contains parsed information about URL.
    /// </summary>
    public class UrlAddress
    {
        /// <summary>
        /// Gets or sets url hostname.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets array of url segments.
        /// Allows null.
        /// </summary>
        public string[] Uri { get; set; }

        /// <summary>
        /// Gets or sets dictionary of unique keys and values - url query.
        /// Allows null.
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }
    }
}
