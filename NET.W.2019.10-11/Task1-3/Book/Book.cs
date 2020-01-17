// <copyright file="Book.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BookStore
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Class Book contains fields and methods associated with storing and operating books
    /// </summary>
    public class Book : IComparable<Book>, IEquatable<Book>, IFormattable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// Contains constrains enough to ensure that created instance of Book is valid.
        /// </summary>
        /// <param name="isbn">
        /// ISBN - unique book ID.
        /// </param>
        /// <param name="author">
        /// Author.
        /// </param>
        /// <param name="name">
        /// Book title.
        /// </param>
        /// <param name="publisher">
        /// Publisher.
        /// </param>
        /// <param name="year">
        /// Year.
        /// </param>
        /// <param name="pages">
        /// Amount of pages.
        /// </param>
        /// <param name="price">
        /// Book price.
        /// </param>
        public Book(string isbn, string author, string name, string publisher, int year, int pages, float price)
        {
            bool temp = string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(publisher);

            if (temp || year <= 0 || pages <= 0 || price <= 0)
            {
                throw new ArgumentException(message: "Unable to create Book - invalid arguments");
            }

            this.ISBN = isbn;
            this.Author = author;
            this.Name = name;
            this.Publisher = publisher;
            this.Year = year;
            this.Pages = pages;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets iSBN, unique book ID.
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets book author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets book title.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets book publisher.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets book release year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets amount of pages.
        /// </summary>
        public int Pages { get; set; }

        /// <summary>
        /// Gets or sets book price.
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Method for sorting by custom property.
        /// </summary>
        /// <returns>
        /// IComparer.
        /// </returns>
        public static IComparer<Book> SortAuthorAscending()
        {
            return (IComparer<Book>)new SortAuthorAscendingHelper();
        }

        /// <summary>
        /// Method for sorting by custom property.
        /// </summary>
        /// <returns>
        /// IComparer.
        /// </returns>
        public static IComparer<Book> SortNameAscending()
        {
            return (IComparer<Book>)new SortNameAscendingHelper();
        }

        /// <summary>
        /// Method for sorting by custom property.
        /// </summary>
        /// <returns>
        /// IComparer.
        /// </returns>
        public static IComparer<Book> SortPublisherAscending()
        {
            return (IComparer<Book>)new SortPublisherAscendingHelper();
        }

        /// <summary>
        /// Method for sorting by custom property.
        /// </summary>
        /// <returns>
        /// IComparer.
        /// </returns>
        public static IComparer<Book> SortYearAscending()
        {
            return (IComparer<Book>)new SortYearAscendingHelper();
        }

        /// <summary>
        /// Method for sorting by custom property.
        /// </summary>
        /// <returns>
        /// IComparer.
        /// </returns>
        public static IComparer<Book> SortPagesAscending()
        {
            return (IComparer<Book>)new SortPagesAscendingHelper();
        }

        /// <summary>
        /// Method for sorting by custom property.
        /// </summary>
        /// <returns>
        /// IComparer.
        /// </returns>
        public static IComparer<Book> SortPriceAscending()
        {
            return (IComparer<Book>)new SortPriceAscendingHelper();
        }

        /// <summary>
        /// IFormattable interface implementation.
        /// Converts instances of Book class into string with formatting.
        /// </summary>
        /// <param name="format">
        /// Format.
        /// </param>
        /// <param name="provider">
        /// Cultureinfo.
        /// </param>
        /// <returns>
        /// Formatted string.
        /// </returns>
        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                format = "I-A-N-PUB-Y-PA-PR";
            }

            if (provider == null)
            {
                provider = CultureInfo.InvariantCulture;
            }

            StringBuilder sb = new StringBuilder(50);
            var inputs = format.Split('-', 20);
            for (int i = 0; i < inputs.Length; i++)
            {
                bool isValid = true;
                switch (inputs[i])
                {
                    case "I":
                        sb.Append($"ISBN = {this.ISBN}, ");
                        break;
                    case "i":
                        sb.Append($"ISBN 13: {this.ISBN}, ");
                        break;
                    case "A":
                        sb.Append($"AuthorName = {this.Author}, ");
                        break;
                    case "a":
                        sb.Append($"{this.Author}, ");
                        break;
                    case "N":
                        sb.Append($"Title = {this.Name}, ");
                        break;
                    case "n":
                        sb.Append($"{this.Name}, ");
                        break;
                    case "PUB":
                        sb.Append($"Publisher = {this.Publisher}, ");
                        break;
                    case "pub":
                        sb.Append($"\"{this.Publisher}\", ");
                        break;
                    case "Y":
                        sb.Append($"Year = {this.Year}, ");
                        break;
                    case "y":
                        sb.Append($"{this.Year}, ");
                        break;
                    case "PA":
                        sb.Append($"NumberOfPages = {this.Pages}, ");
                        break;
                    case "pa":
                        sb.Append($"P.{this.Pages}, ");
                        break;
                    case "PR":
                        sb.Append($"Price = {this.Price}$, ");
                        break;
                    case "pr":
                        sb.Append($"{this.Price}$, ");
                        break;
                    default:
                        isValid = false;
                        break;
                }

                if (!isValid)
                {
                    return "Format is not supported";
                }
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        /// <summary>
        /// Overload that takes only format string.
        /// Format provider is CultureInfo.InvariantCulture.
        /// </summary>
        /// <param name="format">
        /// Format.
        /// </param>
        /// <returns>
        /// Formatted string.
        /// </returns>
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Overload that takes no parameters.
        /// Default parameters are used.
        /// Format = "I-A-N-PUB-Y-PA-PR".
        /// Format provider = CultureInfo.InvariantCulture.
        /// </summary>
        /// <returns>
        /// Formatted string.
        /// </returns>
        public override string ToString()
        {
            return this.ToString("I-A-N-PUB-Y-PA-PR", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// IEquatable interface imnplementation.
        /// Equality is based on unique ISBN.
        /// </summary>
        /// <param name="book">
        /// Book instance.
        /// </param>
        /// <returns>
        /// True/False.
        /// </returns>
        public bool Equals(Book book)
        {
            return this.ISBN.Equals(book.ISBN);
        }

        /// <summary>
        /// Overrides object.GetHashCode().
        /// </summary>
        /// <returns>
        /// Integer hashcode.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// IComparable interface impementation.
        /// Provides Book class with default compare property (ISBN).
        /// </summary>
        /// <param name="book">
        /// Book instance
        /// </param>
        /// <returns>
        /// Compare result (0,1,-1).
        /// </returns>
        int IComparable<Book>.CompareTo(Book book)
        {
            return string.Compare(this.ISBN, book.ISBN);
        }

        /// <summary>
        /// Class that implements IComparer interface.
        /// </summary>
        private class SortAuthorAscendingHelper : IComparer<Book>
        {
            int IComparer<Book>.Compare(Book a, Book b)
            {
                return string.Compare(a.Author, b.Author);
            }
        }

        /// <summary>
        /// Class that implements IComparer interface.
        /// </summary>
        private class SortNameAscendingHelper : IComparer<Book>
        {
            int IComparer<Book>.Compare(Book a, Book b)
            {
                return string.Compare(a.Name, b.Name);
            }
        }

        /// <summary>
        /// Class that implements IComparer interface.
        /// </summary>
        private class SortPublisherAscendingHelper : IComparer<Book>
        {
            int IComparer<Book>.Compare(Book a, Book b)
            {
                return string.Compare(a.Publisher, b.Publisher);
            }
        }

        /// <summary>
        /// Class that implements IComparer interface.
        /// </summary>
        private class SortYearAscendingHelper : IComparer<Book>
        {
            int IComparer<Book>.Compare(Book a, Book b)
            {
                if (a.Year > b.Year)
                {
                    return 1;
                }

                if (a.Year < b.Year)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Class that implements IComparer interface.
        /// </summary>
        private class SortPagesAscendingHelper : IComparer<Book>
        {
            int IComparer<Book>.Compare(Book a, Book b)
            {
                if (a.Pages > b.Pages)
                {
                    return 1;
                }

                if (a.Pages < b.Pages)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Class that implements IComparer interface.
        /// </summary>
        private class SortPriceAscendingHelper : IComparer<Book>
        {
            int IComparer<Book>.Compare(Book a, Book b)
            {
                if (a.Price > b.Price)
                {
                    return 1;
                }

                if (a.Price < b.Price)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
