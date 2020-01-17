// <copyright file="BookListService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BookStore
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using static BookStore.Book;

    /// <summary>
    /// Class implements various servives for list of books.
    /// </summary>
    public class BookListService
    {
        private readonly Ilogger logger;
        private string path = "BookListStorage.dat";
        private List<Book> list = new List<Book>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// Constructor reads data from file upon class instance creation.
        /// </summary>
        public BookListService(Ilogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger), message: "Logger cannot be null");
            }

            this.OpenDefault();
            this.logger = logger;
            this.logger.Info($"Service started succesfully. List contains {this.list.Count} record(s)");
        }

        /// <summary>
        /// Delegate required for eventhandler.
        /// </summary>
        /// <param name="sender">
        /// Object that raises the event.
        /// </param>
        /// <param name="e">
        /// Argument class instance. Provides eventhandler with data.
        /// </param>
        public delegate void BookEventHandler(object sender, BookServiceEventArgs e);

        /// <summary>
        /// Event meant to provide with infromation about servie actions.
        /// </summary>
        public event BookEventHandler BookEventOutput;

        /// <summary>
        /// Method ouputs list entries as events.
        /// Supports formatting.
        /// </summary>
        /// <param name="list">
        /// List.
        /// </param>
        /// <param name="format">
        /// String format.
        /// </param>
        public void DisplayList(List<Book> list, string format)
        {
            if (list == null)
            {
                this.OnOutput(this, new BookServiceEventArgs("List is Empty"));
                return;
            }

            foreach (Book b in list)
            {
                this.OnOutput(this, new BookServiceEventArgs(b.ToString(format)));
            }
        }

        /// <summary>
        /// Overload that outputs current (this) class field list.
        /// </summary>
        /// <param name="format">
        /// String format.
        /// </param>
        public void DisplayList(string format)
        {
            this.DisplayList(this.list, format);
        }

        /// <summary>
        /// Overload that outputs this class list using default formatting.
        /// </summary>
        public void DisplayList()
        {
            this.DisplayList(this.list, "I-A-N-PUB-Y-PA-PR");
        }

        /// <summary>
        /// Overload that outputs given list using default formatting.
        /// </summary>
        /// <param name="list">
        /// List.
        /// </param>
        public void DisplayList(List<Book> list)
        {
            this.DisplayList(list, "I-A-N-PUB-Y-PA-PR");
        }

        /// <summary>
        /// Method opens custom file.
        /// </summary>
        /// <param name="path">
        /// File path.
        /// </param>
        public void Open(string path)
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
                {
                    string isbn;
                    string author;
                    string name;
                    string publisher;
                    int year;
                    int pages;
                    float price;
                    List<Book> newlist = new List<Book>();

                    while (reader.PeekChar() > -1)
                    {
                        isbn = reader.ReadString();
                        author = reader.ReadString();
                        name = reader.ReadString();
                        publisher = reader.ReadString();
                        year = reader.ReadInt32();
                        pages = reader.ReadInt32();
                        price = reader.ReadSingle();
                        newlist.Add(new Book(isbn, author, name, publisher, year, pages, price));
                    }

                    FileInfo fileInf = new FileInfo(path);
                    this.list = newlist;
                    this.path = path;
                    string output = $"{this.list.Count} records has been read from {fileInf.Directory + "\\" + fileInf.Name}";
                    this.OnOutput(this, new BookServiceEventArgs(output));
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"Failed to open file using path: {path}");
                this.OnOutput(this, new BookServiceEventArgs(ex.Message));
            }
        }

        /// <summary>
        /// Method writes current data to custom file.
        /// </summary>
        /// <param name="path">
        /// Target file path.
        /// </param>
        public void Write(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                this.OnOutput(this, new BookServiceEventArgs("Invalid path"));
            }

            try
            {
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    fileInf.Delete();
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    foreach (Book b in this.list)
                    {
                        writer.Write(b.ISBN);
                        writer.Write(b.Author);
                        writer.Write(b.Name);
                        writer.Write(b.Publisher);
                        writer.Write(b.Year);
                        writer.Write(b.Pages);
                        writer.Write(b.Price);
                    }

                    string output = $"Data is successfully saved to file {fileInf.Directory + "\\" + fileInf.Name}";
                    this.OnOutput(this, new BookServiceEventArgs(output));
                    this.path = path;
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"Failed to write to file using path: {path}");
                this.OnOutput(this, new BookServiceEventArgs(ex.Message));
            }
        }

        /// <summary>
        /// Overload that opens current file.
        /// </summary>
        public void OpenDefault()
        {
            this.Open(this.path);
        }

        /// <summary>
        /// Overload that saves data to current file.
        /// </summary>
        public void WriteDefault()
        {
            this.Write(this.path);
        }

        /// <summary>
        /// Sort by criteria.
        /// </summary>
        /// <param name="criteria">
        /// Criteria (sort by custom property).
        /// </param>
        public void Sort(string criteria)
        {
            string output;
            switch (criteria?.ToUpperInvariant())
            {
                case "ISBN":
                    this.list.Sort();
                    output = "Sorted by ISBN";
                    break;
                case "AUTHOR":
                    this.list.Sort(SortAuthorAscending());
                    output = "Sorted by Author";
                    break;
                case "NAME":
                    this.list.Sort(SortNameAscending());
                    output = "Sorted by Name";
                    break;
                case "PUBLISHER":
                    output = "Sorted by publisher";
                    this.list.Sort(SortPublisherAscending());
                    break;
                case "YEAR":
                    this.list.Sort(SortYearAscending());
                    output = "Sorted by Year";
                    break;
                case "PAGES":
                    this.list.Sort(SortPagesAscending());
                    output = "Sorted by Pages";
                    break;
                case "PRICE":
                    this.list.Sort(SortPriceAscending());
                    output = "Sorted by Price";
                    break;
                default:
                    output = "Sort criteria not found";
                    break;
            }

            this.OnOutput(this, new BookServiceEventArgs(output));
        }

        /// <summary>
        /// Search by ISBN.
        /// </summary>
        /// <param name="isbn">
        /// ISBN.
        /// </param>
        /// <returns>
        /// List of search matches.
        /// </returns>
        public List<Book> FindById(string isbn)
        {
            List<Book> result = new List<Book>();
            foreach (Book b in this.list)
            {
                if (b.ISBN.ToUpperInvariant() == isbn.ToUpperInvariant())
                {
                    result.Add(b);
                }
            }

            return result;
        }

        /// <summary>
        /// Search by Author.
        /// </summary>
        /// <param name="author">
        /// Author.
        /// </param>
        /// <returns>
        /// List of search matches.
        /// </returns>
        public List<Book> FindByAuthor(string author)
        {
            List<Book> result = new List<Book>();
            foreach (Book b in this.list)
            {
                if (b.Author.ToUpperInvariant() == author.ToUpperInvariant())
                {
                    result.Add(b);
                }
            }

            return result;
        }

        /// <summary>
        /// Search by Name.
        /// </summary>
        /// <param name="name">
        /// Name.
        /// </param>
        /// <returns>
        /// List of search matches.
        /// </returns>
        public List<Book> FindByName(string name)
        {
            List<Book> result = new List<Book>();
            foreach (Book b in this.list)
            {
                if (b.Name.ToUpperInvariant() == name.ToUpperInvariant())
                {
                    result.Add(b);
                }
            }

            return result;
        }

        /// <summary>
        /// Search by publisher.
        /// </summary>
        /// <param name="publisher">
        /// Publisher.
        /// </param>
        /// <returns>
        /// List of search matches.
        /// </returns>
        public List<Book> FindByPublisher(string publisher)
        {
            List<Book> result = new List<Book>();
            foreach (Book b in this.list)
            {
                if (b.Publisher.ToUpperInvariant() == publisher.ToUpperInvariant())
                {
                    result.Add(b);
                }
            }

            return result;
        }

        /// <summary>
        /// Search by year.
        /// </summary>
        /// <param name="value">
        /// Year.
        /// </param>
        /// <returns>
        /// List of search matches.
        /// </returns>
        public List<Book> FindByYear(string value)
        {
            List<Book> result = new List<Book>();

            if (int.TryParse(value, out int year))
            {
                foreach (Book b in this.list)
                {
                    if (b.Year == year)
                    {
                        result.Add(b);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Search by pages amount.
        /// </summary>
        /// <param name="value">
        /// Pages amount.
        /// </param>
        /// <returns>
        /// List of search matches.
        /// </returns>
        public List<Book> FindByPages(string value)
        {
            List<Book> result = new List<Book>();

            if (int.TryParse(value, out int pages))
            {
                foreach (Book b in this.list)
                {
                    if (b.Pages == pages)
                    {
                        result.Add(b);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Search by price.
        /// </summary>
        /// <param name="value">
        /// Price.
        /// </param>
        /// <returns>
        /// List of search matches.
        /// </returns>
        public List<Book> FindByPrice(string value)
        {
            List<Book> result = new List<Book>();

            if (float.TryParse(value, out float price))
            {
                foreach (Book b in this.list)
                {
                    if (b.Price == price)
                    {
                        result.Add(b);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Adds new book to current(this) list.
        /// </summary>
        /// <param name="book">
        /// Book to add.
        /// </param>
        public void AddBook(Book book)
        {
            if (this.BookExists(book))
            {
                throw new Exception(message: "Book with such Id already exists");
            }
            else
            {
                this.list.Add(book);
            }
        }

        /// <summary>
        /// Removes book from current(this) list by ISBN.
        /// </summary>
        /// <param name="id">
        /// ISBN.
        /// </param>
        public void RemoveBook(string id)
        {
            if (!string.IsNullOrEmpty(id) && this.list.Remove(this.list.Find(i => i.ISBN == id)))
            {
                string output = $"Book with ISBN = {id} has been successfully removed";
                this.OnOutput(this, new BookServiceEventArgs(output));
            }
            else
            {
                throw new Exception(message: "There is no such book in the store");
            }
        }

        /// <summary>
        /// Method that incapsulates event call.
        /// </summary>
        /// <param name="sender">
        /// Caller object.
        /// </param>
        /// <param name="e">
        /// Event data.
        /// </param>
        protected virtual void OnOutput(object sender, BookServiceEventArgs e)
        {
            this.BookEventOutput?.Invoke(sender, e);
        }

        private bool BookExists(Book book)
        {
            return this.list.Contains(book);
        }
    }
}
