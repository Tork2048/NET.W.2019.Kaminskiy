using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static BookStore.Book;

namespace BookStore
{
    public class BookListService
    {
        private List<Book> list = new List<Book>();
        private string path = "BookListStorage.dat";

        public BookListService()
        {
            this.OpenDefault();
        }

        public void DisplayList(List<Book> list)
        {
            foreach (Book b in list)
            {
                Console.WriteLine($"{b.ISBN}, {b.Author}, {b.Name}, {b.Publisher}, {b.Year}, {b.Pages}, {b.Price}");
            }
        }

        public void DisplayList()
        {
            this.DisplayList(this.list);
        }

        public void Open(string path)
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
                {
                    int isbn;
                    string author;
                    string name;
                    string publisher;
                    int year;
                    int pages;
                    float price;
                    List<Book> newlist = new List<Book>();

                    while (reader.PeekChar() > -1)
                    {
                        isbn = reader.ReadInt32();
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
                    Console.WriteLine($"{this.list.Count} records has been read from {fileInf.Directory + "\\" + fileInf.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Write(string path)
        {
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

                    Console.WriteLine($"Data is successfully saved to file {fileInf.Directory + "\\" + fileInf.Name}");
                    this.path = path;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void OpenDefault()
        {
            this.Open(this.path);
        }

        public void WriteDefault()
        {
            this.Write(this.path);
        }

        public void Sort(string criteria)
        {
            switch (criteria?.ToUpperInvariant())
            {
                case "ISBN":
                    this.list.Sort();
                    break;
                case "AUTHOR":
                    this.list.Sort(SortAuthorAscending());
                    break;
                case "NAME":
                    this.list.Sort(SortNameAscending());
                    break;
                case "PUBLISHER":
                    this.list.Sort(SortPublisherAscending());
                    break;
                case "YEAR":
                    this.list.Sort(SortYearAscending());
                    break;
                case "PAGES":
                    this.list.Sort(SortPagesAscending());
                    break;
                case "PRICE":
                    this.list.Sort(SortPriceAscending());
                    break;
                default:
                    Console.WriteLine("Sort criteria not found");
                    break;
            }
        }

        public List<Book> FindById(string id)
        {
            List<Book> result = new List<Book>();
            if (int.TryParse(id, out int isbn))
            {
                foreach (Book b in this.list)
                {
                    if (b.ISBN == isbn)
                    {
                        result.Add(b);
                    }
                }
            }

            return result;
        }

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

        public void RemoveBook(int id)
        {
            Book book = new Book(id, string.Empty, string.Empty, string.Empty, 0, 0, 0);

            if (this.BookExists(book))
            {
                this.list.Remove(book);
                Console.WriteLine($"Book with ISBN = {id} has been successfully removed");
            }
            else
            {
                throw new Exception(message: "There is no such book in the store");
            }
        }

        private bool BookExists(Book book)
        {
            return this.list.Contains(book);
        }
    }
}
