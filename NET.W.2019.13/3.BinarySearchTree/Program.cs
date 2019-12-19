// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinarySearchTree
{
    using System;

    /// <summary>
    /// Class that contains entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">
        /// Start arguments.
        /// </param>
        public static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(new TypeComparer.IntComparerDescending());

            var rand = new Random();
            for (int i = 0; i < 15; i++)
            {
                tree.Add(rand.Next(0, 1000));
            }

            Book book1 = new Book("C#", "Rihter", 99M);
            Book book2 = new Book("C++", "Someone", 135M);
            Book book3 = new Book("Delphi", "Borland", 200M);
            Book book4 = new Book("Pascal", "School", 30M);

            Tree<Book> bookTree = new Tree<Book>(new TypeComparer.BookComparerByPriceDescending());
            Book[] arrayOfBooks = new Book[]
                {
                    new Book("The Great Gatsby", "F. Scott Fitzgerald", 120M),
                    new Book("Catch-22", "Joseph Heller", 67M),
                    new Book("On the Road", "Jack Kerouac", 85M),
                    new Book("To Kill A Mockingbird", "Harper Lee", 140M),
                    new Book("The Lord Of The Rings", "J. R. R. Tolkien", 125M),
                    new Book("Lolita", "Vladimir Nabokov", 10M),
                    new Book("The Catcher in the Rye", "JD Salinger", 150M),
                    new Book("Midnight’s Children", "Salman Rushdie", 97M),
                };
            foreach (var book in arrayOfBooks)
            {
                bookTree.Add(book);
            }

            Point point1 = new Point(19, 80);
            Point point2 = new Point(1000, 25);
            Point point3 = new Point(30, 58);
            Point point4 = new Point(100, 70);
            Point point5 = new Point(1, 2);

            Tree<Point> pointTree = new Tree<Point>(new TypeComparer.PointComparerVectorLength());
            pointTree.Add(point1);
            pointTree.Add(point2);
            pointTree.Add(point3);
            pointTree.Add(point4);
            pointTree.Add(point5);

            string[] arrayOfString = new string[]
                {
                    "lease",
                    "incentive",
                    "plug",
                    "repetition",
                    "wriggle",
                    "housing",
                    "fair",
                    "generation",
                    "due",
                    "wave",
                };
            Tree<string> stringTree = new Tree<string>();
            foreach (string s in arrayOfString)
            {
                stringTree.Add(s);
            }

            foreach (int x in tree.TraversePreOrder())
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();

            foreach (var x in bookTree.TraversePreOrder())
            {
                Console.WriteLine(x + " ");
            }

            Console.WriteLine();

            foreach (var x in pointTree.TraversePreOrder())
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();

            foreach (var x in stringTree.TraversePreOrder())
            {
                Console.WriteLine(x + " ");
            }

            Console.ReadKey();
        }
    }
}
