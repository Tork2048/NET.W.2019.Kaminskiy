// <copyright file="TestData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinarySearchTree.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Data class for testing purposes.
    /// </summary>
    public class TestData
    {
        /// <summary>
        /// Gets or Sets array of integers.
        /// </summary>
        public int[] ArrayOfIntegers { get; set; }

        /// <summary>
        /// Gets or Sets expected preorder traverse for tree of integers.
        /// </summary>
        public int[] IntPreOrderTraverse { get; set; }

        /// <summary>
        /// Gets or Sets array of strings.
        /// </summary>
        public string[] ArrayOfString { get; set; }

        /// <summary>
        /// Gets or Sets expected preorder traverse for tree of strings.
        /// </summary>
        public string[] StringPreOrderTraverse { get; set; }

        /// <summary>
        /// Gets or Sets array of books.
        /// </summary>
        public Book[] ArrayOfBooks { get; set; }

        /// <summary>
        /// Gets or Sets expected preorder traverse for tree of books.
        /// </summary>
        public Book[] BookPreOrderTraverse { get; set; }

        /// <summary>
        /// Gets or Sets array of points.
        /// </summary>
        public Point[] ArrayOfPoints { get; set; }

        /// <summary>
        /// Gets or Sets expected preorder traverse for tree of Points.
        /// </summary>
        public Point[] PointPreOrderTraverse { get; set; }
    }
}
