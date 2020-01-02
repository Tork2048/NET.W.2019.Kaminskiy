// <copyright file="ParserEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseFileAndExportXML
{
    /// <summary>
    /// Data class for parser event.
    /// </summary>
    public class ParserEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParserEventArgs"/> class.
        /// </summary>
        /// <param name="message">
        /// Message - reason of parse failure.
        /// </param>
        /// <param name="line">
        /// Used as a number of string failed to parse.
        /// </param>
        public ParserEventArgs(string message, int line)
        {
            this.Message = message;
            this.Line = line;
        }

        /// <summary>
        /// Gets error message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the number of failed string.
        /// </summary>
        public int Line { get; }
    }
}
