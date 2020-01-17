// <copyright file="ElementChangeArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GenericMatrix
{
    /// <summary>
    /// Data class for element change event.
    /// </summary>
    public class ElementChangeArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementChangeArgs"/> class.
        /// Constructs object with indexes and event message.
        /// </summary>
        /// <param name="i">
        /// Row index.
        /// </param>
        /// <param name="j">
        /// Column index.
        /// </param>
        /// <param name="message">
        /// Event message.
        /// </param>
        public ElementChangeArgs(int i, int j, string message)
        {
            this.IndexI = i;
            this.IndexJ = j;
            this.EventMessage = message;
        }

        /// <summary>
        /// Gets event message.
        /// </summary>
        public string EventMessage { get; }

        /// <summary>
        /// Gets row index.
        /// </summary>
        public int IndexI { get; }

        /// <summary>
        /// Gets column index.
        /// </summary>
        public int IndexJ { get; }
    }
}
