// <copyright file="BookFormatter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BookStore
{
    using System;

    /// <summary>
    /// Class provides additional formatting for Book objects.
    /// </summary>
    public class BookFormatter : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// IFormatProvider iterface implementation.
        /// </summary>
        /// <param name="formatType">
        /// Format type.
        /// </param>
        /// <returns>
        /// Returns current object if it emplements ICustomFormatter interface.
        /// </returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ICustomFormatter interface implementation.
        /// Provides with additional custom formatting.
        /// </summary>
        /// <param name="format">
        /// Custom format string.
        /// </param>
        /// <param name="arg">
        /// Object to convert to string with custom formatting.
        /// </param>
        /// <param name="formatProvider">
        /// Culture information.
        /// </param>
        /// <returns>
        /// Formatted string.
        /// </returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!this.Equals(formatProvider))
            {
                return null;
            }

            if (string.IsNullOrEmpty(format))
            {
                format = "U";
            }

            string resultString = arg.ToString();

            if (format == "U")
            {
                resultString = resultString.ToUpperInvariant();
            }
            else if (format == "L")
            {
                resultString = resultString.ToLowerInvariant();
            }
            else
            {
                throw new FormatException(message: "Such format option is not supported");
            }

            return resultString;
        }
    }
}
