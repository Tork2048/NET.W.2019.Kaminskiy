// <copyright file="Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinarySearchTree.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    /// <summary>
    /// Class for unit testing.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        private static TestData[] testDataIntegers = new TestData[]
        {
            new TestData()
            {
                ArrayOfIntegers = new int[] { 8, 10, 3, 14, 6, 1, 13, 7, 4 },
                IntPreOrderTraverse = new int[] { 8, 3, 1, 6, 4, 7, 10, 14, 13 },
            },
        };

        private static TestData[] testDataStrings = new TestData[]
        {
            new TestData()
            {
                ArrayOfString = new string[]
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
                },

                StringPreOrderTraverse = new string[]
                {
                    "lease",
                    "incentive",
                    "housing",
                    "fair",
                    "due",
                    "generation",
                    "plug",
                    "repetition",
                    "wriggle",
                    "wave",
                },
            },
        };

        private static TestData[] testDataBooks = new TestData[]
        {
            new TestData()
            {
                ArrayOfBooks = new Book[]
                {
                    new Book("The Great Gatsby", "F. Scott Fitzgerald", 120M),
                    new Book("Catch-22", "Joseph Heller", 67M),
                    new Book("On the Road", "Jack Kerouac", 85M),
                    new Book("To Kill A Mockingbird", "Harper Lee", 140M),
                    new Book("The Lord Of The Rings", "J. R. R. Tolkien", 125M),
                    new Book("Lolita", "Vladimir Nabokov", 10M),
                    new Book("The Catcher in the Rye", "JD Salinger", 150M),
                    new Book("Midnight’s Children", "Salman Rushdie", 97M),
                },

                BookPreOrderTraverse = new Book[]
                {
                    new Book("The Great Gatsby", "F. Scott Fitzgerald", 120M),
                    new Book("To Kill A Mockingbird", "Harper Lee", 140M),
                    new Book("The Catcher in the Rye", "JD Salinger", 150M),
                    new Book("The Lord Of The Rings", "J. R. R. Tolkien", 125M),
                    new Book("Catch-22", "Joseph Heller", 67M),
                    new Book("On the Road", "Jack Kerouac", 85M),
                    new Book("Midnight’s Children", "Salman Rushdie", 97M),
                    new Book("Lolita", "Vladimir Nabokov", 10M),
                },
            },
        };

        private static TestData[] testDataPoints = new TestData[]
        {
            new TestData()
            {
                ArrayOfPoints = new Point[]
                {
                    new Point(19, 80),
                    new Point(1000, 25),
                    new Point(30, 58),
                    new Point(100, 70),
                    new Point(1, 2),
                },

                PointPreOrderTraverse = new Point[]
                {
                    new Point(19, 80),
                    new Point(30, 58),
                    new Point(1, 2),
                    new Point(1000, 25),
                    new Point(100, 70),
                },
            },
        };

        /// <summary>
        /// TestAdditionAndTraversalInt.
        /// </summary>
        /// <param name="data">
        /// testdata.
        /// </param>
        [Test]
        [TestCaseSource("testDataIntegers")]
        public static void TestAdditionAndTraversalInt(TestData data)
        {
            Tree<int> tree = new Tree<int>();
            foreach (var x in data.ArrayOfIntegers)
            {
                tree.Add(x);
            }

            int[] result = ExtractArrayFromTreePreOrder(tree);

            Assert.That(result, Is.EqualTo(data.IntPreOrderTraverse));
        }

        /// <summary>
        /// TestAdditionAndTraversalString.
        /// </summary>
        /// <param name="data">
        /// test data.
        /// </param>
        [Test]
        [TestCaseSource("testDataStrings")]
        public static void TestAdditionAndTraversalString(TestData data)
        {
            Tree<string> tree = new Tree<string>();
            foreach (var x in data.ArrayOfString)
            {
                tree.Add(x);
            }

            string[] result = ExtractArrayFromTreePreOrder(tree);

            Assert.That(result, Is.EqualTo(data.StringPreOrderTraverse));
        }

        /// <summary>
        /// TestAdditionAndTraversalBook.
        /// </summary>
        /// <param name="data">
        /// test data.
        /// </param>
        [Test]
        [TestCaseSource("testDataBooks")]
        public static void TestAdditionAndTraversalBook(TestData data)
        {
            Tree<Book> tree = new Tree<Book>(new TypeComparer.BookComparerByPriceDescending());
            foreach (var x in data.ArrayOfBooks)
            {
                tree.Add(x);
            }

            Book[] result = ExtractArrayFromTreePreOrder(tree);

            Assert.That(result, Is.EqualTo(data.BookPreOrderTraverse));
        }

        /// <summary>
        /// TestAdditionAndTraversalPoint
        /// </summary>
        /// <param name="data">
        /// test data.
        /// </param>
        [Test]
        [TestCaseSource("testDataPoints")]
        public static void TestAdditionAndTraversalPoint(TestData data)
        {
            Tree<Point> tree = new Tree<Point>(new TypeComparer.PointComparerVectorLength());
            foreach (var x in data.ArrayOfPoints)
            {
                tree.Add(x);
            }

            Point[] result = ExtractArrayFromTreePreOrder(tree);

            Assert.That(result, Is.EqualTo(data.PointPreOrderTraverse));
        }

        /// <summary>
        /// TestFindInTreeInt.
        /// </summary>
        /// <param name="data">
        /// test data.
        /// </param>
        [Test]
        [TestCaseSource("testDataIntegers")]
        public static void TestFindInTreeInt(TestData data)
        {
            Tree<int> tree = new Tree<int>();
            foreach (var x in data.ArrayOfIntegers)
            {
                tree.Add(x);
            }

            Node<int> node = tree.Find(data.ArrayOfIntegers[5]);

            Assert.That(node.Value, Is.EqualTo(data.ArrayOfIntegers[5]));
        }

        /// <summary>
        /// TestFindInTreeStrng.
        /// </summary>
        /// <param name="data">
        /// test data.
        /// </param>
        [Test]
        [TestCaseSource("testDataStrings")]
        public static void TestFindInTreeStrng(TestData data)
        {
            Tree<string> tree = new Tree<string>();
            foreach (var x in data.ArrayOfString)
            {
                tree.Add(x);
            }

            Node<string> node = tree.Find(data.ArrayOfString[5]);

            Assert.That(node.Value, Is.EqualTo(data.ArrayOfString[5]));
        }

        /// <summary>
        /// TestFindInTreeBook
        /// </summary>
        /// <param name="data">
        /// test data.
        /// </param>
        [Test]
        [TestCaseSource("testDataBooks")]
        public static void TestFindInTreeBook(TestData data)
        {
            Tree<Book> tree = new Tree<Book>();
            foreach (var x in data.ArrayOfBooks)
            {
                tree.Add(x);
            }

            Node<Book> node = tree.Find(data.ArrayOfBooks[5]);

            Assert.That(node.Value, Is.EqualTo(data.ArrayOfBooks[5]));
        }

        /// <summary>
        /// TestFindInTreePoint
        /// </summary>
        /// <param name="data">
        /// test data.
        /// </param>
        [Test]
        [TestCaseSource("testDataPoints")]
        public static void TestFindInTreePoint(TestData data)
        {
            Tree<Point> tree = new Tree<Point>(new TypeComparer.PointComparerVectorLength());
            foreach (var x in data.ArrayOfPoints)
            {
                tree.Add(x);
            }

            Node<Point> node = tree.Find(data.ArrayOfPoints[4]);

            Assert.That(node.Value, Is.EqualTo(data.ArrayOfPoints[4]));
        }

        /// <summary>
        /// TestRemoveFromTreeInt.
        /// </summary>
        /// <param name="data">
        /// test data.
        /// </param>
        [Test]
        [TestCaseSource("testDataIntegers")]
        public static void TestRemoveFromTreeInt(TestData data)
        {
            Tree<int> tree = new Tree<int>();
            foreach (var x in data.ArrayOfIntegers)
            {
                tree.Add(x);
            }

            tree.Remove(data.ArrayOfIntegers[5]);

            Assert.That(tree.Find(data.ArrayOfIntegers[5]), Is.EqualTo(null));
        }

        /// <summary>
        /// TestRemoveFromTreeStrng
        /// </summary>
        /// <param name="data">
        /// test data.
        /// </param>
        [Test]
        [TestCaseSource("testDataStrings")]
        public static void TestRemoveFromTreeStrng(TestData data)
        {
            Tree<string> tree = new Tree<string>();
            foreach (var x in data.ArrayOfString)
            {
                tree.Add(x);
            }

            tree.Remove(data.ArrayOfString[5]);

            Assert.That(tree.Find(data.ArrayOfString[5]), Is.EqualTo(null));
        }

        /// <summary>
        /// TestRemoveFromTreeBook.
        /// </summary>
        /// <param name="data">
        /// test data.
        /// </param>
        [Test]
        [TestCaseSource("testDataBooks")]
        public static void TestRemoveFromTreeBook(TestData data)
        {
            Tree<Book> tree = new Tree<Book>();
            foreach (var x in data.ArrayOfBooks)
            {
                tree.Add(x);
            }

            tree.Remove(data.ArrayOfBooks[5]);

            Assert.That(tree.Find(data.ArrayOfBooks[5]), Is.EqualTo(null));
        }

        /// <summary>
        /// TestRemoveFromTreePoint.
        /// </summary>
        /// <param name="data">
        /// test data,
        /// </param>
        [Test]
        [TestCaseSource("testDataPoints")]
        public static void TestRemoveFromTreePoint(TestData data)
        {
            Tree<Point> tree = new Tree<Point>(new TypeComparer.PointComparerVectorLength());
            foreach (var x in data.ArrayOfPoints)
            {
                tree.Add(x);
            }

            tree.Remove(data.ArrayOfPoints[4]);

            Assert.That(tree.Find(data.ArrayOfPoints[4]), Is.EqualTo(null));
        }

        private static T[] ExtractArrayFromTreePreOrder<T>(Tree<T> tree)
        {
            List<T> list = new List<T>();

            foreach (var x in tree.TraversePreOrder())
            {
                list.Add(x);
            }

            return list.ToArray();
        }
    }
}
