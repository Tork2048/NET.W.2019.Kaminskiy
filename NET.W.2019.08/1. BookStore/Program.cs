using System;
using System.Collections;
using System.Collections.Generic;

namespace BookStore
{
    public class Program
    {
        private static BookListService booklistService = new BookListService();
        private static bool isRunning = true;
        private static Tuple<string, Action<string>>[] commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("sort", Sort),
            new Tuple<string, Action<string>>("open", Open),
            new Tuple<string, Action<string>>("write", Write),
            new Tuple<string, Action<string>>("add", Add),
            new Tuple<string, Action<string>>("remove", Remove),
            new Tuple<string, Action<string>>("find", Find),
            new Tuple<string, Action<string>>("exit", Exit),
            new Tuple<string, Action<string>>("display", Display),
        };

        private static void Main(string[] args)
        {
            booklistService.GetHashCode();

            do
            {
                Console.Write("> ");
                var inputs = Console.ReadLine().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
                if (inputs.Length == 0)
                {
                    continue;
                }

                var command = inputs[0];

                if (string.IsNullOrEmpty(command))
                {
                    continue;
                }

                var index = Array.FindIndex(commands, 0, commands.Length, i => i.Item1.Equals(command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    var parameters = inputs.Length > 1 ? inputs[1] : string.Empty;
                    commands[index].Item2(parameters);
                }
                else
                {
                    Console.WriteLine($"Command not found - {command}");
                }
            }
            while (isRunning);
        }

        private static void Sort(string parameters)
        {
            booklistService.Sort(parameters);
        }

        private static void Add(string parameters)
        {
            int isbn;
            string author;
            string name;
            string publisher;
            int year;
            int pages;
            float price;

            while (true)
            {
                Console.Write("ISBN: ");
                if (int.TryParse(Console.ReadLine(), out isbn))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid ISBN");
                }
            }

            while (true)
            {
                Console.Write("Author: ");
                author = Console.ReadLine();
                break;
            }

            while (true)
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                break;
            }

            while (true)
            {
                Console.Write("Publisher: ");
                publisher = Console.ReadLine();
                break;
            }

            while (true)
            {
                Console.Write("Year: ");
                if (int.TryParse(Console.ReadLine(), out year))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid year");
                }
            }

            while (true)
            {
                Console.Write("Pages: ");
                if (int.TryParse(Console.ReadLine(), out pages))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid pages amount");
                }
            }

            while (true)
            {
                Console.Write("Price: ");
                if (float.TryParse(Console.ReadLine(), out price))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid Price");
                }
            }

            try
            {
                booklistService.AddBook(new Book(isbn, author, name, publisher, year, pages, price));
                Console.WriteLine("Book added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Remove(string parameters)
        {
            int isbn;
            while (true)
            {
                if (int.TryParse(parameters, out isbn))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid ISBN");
                }
            }

            try
            {
                booklistService.RemoveBook(isbn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Open(string parameters)
        {
            if (string.IsNullOrEmpty(parameters))
            {
                booklistService.OpenDefault();
            }
            else
            {
                booklistService.Open(parameters);
            }
        }

        private static void Write(string parameters)
        {
            if (string.IsNullOrEmpty(parameters))
            {
                booklistService.WriteDefault();
            }
            else
            {
                booklistService.Write(parameters);
            }
        }

        private static void Find(string parameters)
        {
            var inputs = parameters.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            if (inputs.Length < 2 || string.IsNullOrEmpty(inputs[0]) || string.IsNullOrEmpty(inputs[1]))
            {
                Console.WriteLine("Please enter valid criteria and value for search");
                return;
            }
            else
            {
                List<Book> list = null;
                string criteria = inputs[0].ToLowerInvariant();
                string value = inputs[1];
                switch (criteria)
                {
                    case "isbn":
                        list = booklistService.FindById(value);
                        break;
                    case "author":
                        list = booklistService.FindByAuthor(value);
                        break;
                    case "name":
                        list = booklistService.FindByName(value);
                        break;
                    case "publisher":
                        list = booklistService.FindByPublisher(value);
                        break;
                    case "year":
                        list = booklistService.FindByYear(value);
                        break;
                    case "pages":
                        list = booklistService.FindByPages(value);
                        break;
                    case "price":
                        list = booklistService.FindByPrice(value);
                        break;
                    default:
                        Console.WriteLine("Such criteria does not exist");
                        break;
                }

                if (list != null)
                {
                    if (list.Count == 0)
                    {
                        Console.WriteLine("No records found");
                    }
                    else
                    {
                        booklistService.DisplayList(list);
                    }
                }
            }
        }

        private static void Exit(string parameters)
        {
            string answer;

            while (true)
            {
                Console.Write("Save changes? Y/N ");
                answer = Console.ReadLine().ToLowerInvariant();

                if (answer == "y")
                {
                    booklistService.WriteDefault();
                    break;
                }
                else if (answer == "n")
                {
                    break;
                }
            }

            isRunning = false;
        }

        private static void Display(string parameters)
        {
            booklistService.DisplayList();
        }
    }
}
