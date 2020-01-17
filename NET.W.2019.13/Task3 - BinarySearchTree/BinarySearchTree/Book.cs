// <copyright file="Book.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinarySearchTree
{
    using System;

    /// <summary>
    /// Custom class to test Binary Search Tree.
    /// </summary>
    public class Book : IComparable<Book>, IEquatable<Book>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="name">
        /// Name.
        /// </param>
        /// <param name="author">
        /// Author.
        /// </param>
        /// <param name="price">
        /// Price.
        /// </param>
        public Book(string name, string author, decimal price)
        {
            this.Name = name;
            this.Author = author;
            this.Price = price;
        }

        /// <summary>
        /// Gets or Sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or Sets price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Default comparer.
        /// </summary>
        /// <param name="book">
        /// Another Book object.
        /// </param>
        /// <returns>
        /// Standard comparer output (1, -1, 0).
        /// </returns>
        int IComparable<Book>.CompareTo(Book book)
        {
            return this.Price.CompareTo(book.Price);
        }

        /// <summary>
        /// Overrides object.ToString for easy data output.
        /// </summary>
        /// <returns>
        /// String representation of class instance.
        /// </returns>
        public override string ToString()
        {
            return $"|{this.Name}, {this.Author}, {this.Price}$|";
        }

        public bool Equals(Book book)
        {
            return this.Name == book.Name && this.Author == book.Author && this.Price == book.Price;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
