// <copyright file="BookServiceEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BookStore
{
    using System;

    /// <summary>
    /// Class required to provide with event data.
    /// </summary>
    public class BookServiceEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookServiceEventArgs"/> class.
        /// Takes event string and sets event time.
        /// </summary>
        /// <param name="output">
        /// Event string.
        /// </param>
        public BookServiceEventArgs(string output)
        {
            this.Output = output;
            this.Timestamp = DateTime.Now;
        }

        /// <summary>
        /// Gets Output string.
        /// </summary>
        public string Output { get; private set; }

        /// <summary>
        /// Gets event timestamp.
        /// </summary>
        public DateTime Timestamp { get; private set; }
    }
}
