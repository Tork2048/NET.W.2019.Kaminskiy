// <copyright file="Point.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinarySearchTree
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Custom class for Binary Search Tree test purpose.
    /// </summary>
    public class Point : IEquatable<Point>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        /// <param name="x">
        /// Coordinate x.
        /// </param>
        /// <param name="y">
        /// Coordinate y.
        /// </param>
        public Point(int x, int y)
        {
            this.CoordinateX = x;
            this.CoordinateY = y;
        }

        /// <summary>
        /// Gets or Sets coordinate x.
        /// </summary>
        public int CoordinateX { get; set; }

        /// <summary>
        /// Gets or Sets coordinate y.
        /// </summary>
        public int CoordinateY { get; set; }

        /// <summary>
        /// Calculates vector length with this coordinates.
        /// </summary>
        /// <returns>
        /// Floored vector length for the sake of simplicity.
        /// </returns>
        public int VectorLength()
        {
            return (int)Math.Sqrt((this.CoordinateX * this.CoordinateX) + (this.CoordinateY * this.CoordinateY));
        }

        public override string ToString()
        {
            return $"|({this.CoordinateX} {this.CoordinateY}), {this.VectorLength()}|";
        }

        public bool Equals(Point point)
        {
            return this.CoordinateX == point.CoordinateX && this.CoordinateY == this.CoordinateY;
        }
    }
}
