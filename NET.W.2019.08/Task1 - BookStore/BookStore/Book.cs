using System;
using System.Collections.Generic;

namespace BookStore
{
    public class Book : IComparable<Book>, IEquatable<Book>
    {
        public Book(int isbn, string author, string name, string publisher, int year, int pages, float price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Name = name;
            this.Publisher = publisher;
            this.Year = year;
            this.Pages = pages;
            this.Price = price;
        }

        public int ISBN { get; set; }

        public string Author { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }

        public int Year { get; set; }

        public int Pages { get; set; }

        public float Price { get; set; }

        public static IComparer<Book> SortAuthorAscending()
        {
            return (IComparer<Book>)new SortAuthorAscendingHelper();
        }

        public static IComparer<Book> SortNameAscending()
        {
            return (IComparer<Book>)new SortNameAscendingHelper();
        }

        public static IComparer<Book> SortPublisherAscending()
        {
            return (IComparer<Book>)new SortPublisherAscendingHelper();
        }

        public static IComparer<Book> SortYearAscending()
        {
            return (IComparer<Book>)new SortYearAscendingHelper();
        }

        public static IComparer<Book> SortPagesAscending()
        {
            return (IComparer<Book>)new SortPagesAscendingHelper();
        }

        public static IComparer<Book> SortPriceAscending()
        {
            return (IComparer<Book>)new SortPriceAscendingHelper();
        }

        public bool Equals(Book book)
        {
            return this.ISBN == book.ISBN;
        }

        public override string ToString()
        {
            string output;
            output = this.Name + ", " + this.Author + ", " + this.Year + ".";
            return output;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        int IComparable<Book>.CompareTo(Book book)
        {
            if (this.ISBN > book.ISBN)
            {
                return 1;
            }

            if (this.ISBN < book.ISBN)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private class SortAuthorAscendingHelper : IComparer<Book>
        {
            int IComparer<Book>.Compare(Book a, Book b)
            {
                return string.Compare(a.Author, b.Author);
            }
        }

        private class SortNameAscendingHelper : IComparer<Book>
        {
            int IComparer<Book>.Compare(Book a, Book b)
            {
                return string.Compare(a.Name, b.Name);
            }
        }

        private class SortPublisherAscendingHelper : IComparer<Book>
        {
            int IComparer<Book>.Compare(Book a, Book b)
            {
                return string.Compare(a.Publisher, b.Publisher);
            }
        }

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
