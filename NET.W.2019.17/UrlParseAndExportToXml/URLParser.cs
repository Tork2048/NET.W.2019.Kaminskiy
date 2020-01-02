// <copyright file="URLParser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseFileAndExportXML
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Class designed to parse array of Urls into IXmlSerializable object.
    /// </summary>
    public class URLParser
    {
        /// <summary>
        /// Event occurs on parse failure of any url in given array.
        /// </summary>
        public event Action<object, ParserEventArgs> OnParseFailed;

        /// <summary>
        /// Parse method.
        /// </summary>
        /// <param name="urls">
        /// Array of urls as strings to parse.
        /// </param>
        /// <returns>
        /// Asignes bunch of parsed Urls as UrlAddresses object to IXmlSerializable interface.
        /// </returns>
        public IXmlSerializable Parse(string[] urls)
        {
            List<UrlAddress> addresses = new List<UrlAddress>();

            for (int k = 0; k < urls.Length; k++)
            {
                Uri siteUri = null;

                try
                {
                    siteUri = new Uri(urls[k]);
                }
                catch (Exception ex)
                {
                    this.OnInvalid(this, new ParserEventArgs(ex.Message, k));
                    continue;
                }

                UrlAddress parsedUrl = new UrlAddress();
                parsedUrl.Host = siteUri.Host;

                string[] segments = null;

                if (siteUri.Segments.Length > 1)
                {
                    segments = new string[siteUri.Segments.Length - 1];
                    for (int i = 0; i < siteUri.Segments.Length - 1; i++)
                    {
                        segments[i] = siteUri.Segments[i + 1];
                        int lastIndex = segments[i].Length - 1;
                        if (segments[i][lastIndex] == '/')
                        {
                            segments[i] = segments[i].Substring(0, lastIndex);
                        }
                    }
                }

                parsedUrl.Uri = segments;

                if (!string.IsNullOrWhiteSpace(siteUri.Query))
                {
                    string fullQuery = siteUri.Query.Substring(1);
                    string[] queries = fullQuery.Split('&', StringSplitOptions.RemoveEmptyEntries);
                    Dictionary<string, string> parameters = new Dictionary<string, string>();

                    foreach (var s in queries)
                    {
                        string[] parametersArray = s.Split('=', 2, StringSplitOptions.RemoveEmptyEntries);

                        if (parametersArray.Length >= 2 && !string.IsNullOrWhiteSpace(parametersArray[0]) && !string.IsNullOrWhiteSpace(parametersArray[1]))
                        {
                            if (!parameters.ContainsKey(parametersArray[0]))
                            {
                                parameters.Add(parametersArray[0], parametersArray[1]);
                            }
                        }
                    }

                    if (parameters.Count > 0)
                    {
                        parsedUrl.Parameters = parameters;
                    }
                }

                addresses.Add(parsedUrl);
            }

            return new UrlAddresses(addresses);
        }

        /// <summary>
        /// Method being called on parse failure of each Urls string.
        /// Triggers OnParseFailed event.
        /// </summary>
        /// <param name="sender">
        /// caller object.
        /// </param>
        /// <param name="args">
        /// Event arguments as ParserEventArgs object.
        /// </param>
        private void OnInvalid(object sender, ParserEventArgs args)
        {
            if (args != null)
            {
                this.OnParseFailed?.Invoke(sender, args);
            }
        }
    }
}
