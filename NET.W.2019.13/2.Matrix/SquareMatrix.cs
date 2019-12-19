// <copyright file="SquareMatrix.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GenericMatrix
{
    using System;

    /// <summary>
    /// More specific matrix - square.
    /// Derived from Matrix.
    /// </summary>
    /// <typeparam name="T">
    /// Matrix data type.
    /// </typeparam>
    public class SquareMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// Uses base constructor.
        /// </summary>
        /// <param name="array">
        /// Given array.
        /// </param>
        public SquareMatrix(T[,] array)
            : base(array)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// Uses base constructor.
        /// </summary>
        /// <param name="dimension">
        /// Dimension to create square array.
        /// </param>
        public SquareMatrix(int dimension)
            : base(dimension, dimension)
        {
        }

        /// <summary>
        /// Square matrix validator.
        /// </summary>
        /// <param name="array">
        /// Given array.
        /// </param>
        protected override void ValidateMatrix(T[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), message: "matrix is null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(message: "matrix is empty", nameof(array));
            }

            int rows = array.GetUpperBound(0) + 1;
            int columns = array.GetUpperBound(1) + 1;

            if (rows != columns)
            {
                throw new InvalidOperationException(message: "Matrix is not square");
            }
        }

        /// <summary>
        /// Copies given array to object array.
        /// </summary>
        /// <param name="array">
        /// Given array.
        /// </param>
        protected override void SetMatrix(T[,] array)
        {
            int dimensionLength = array.GetUpperBound(0) + 1;
            T[,] newArray = new T[dimensionLength, dimensionLength];
            Array.Copy(array, newArray, array.Length);
            this.array = newArray;
        }

        /// <summary>
        /// Element change logic for square matrix.
        /// </summary>
        /// <param name="indexI">
        /// Row index.
        /// </param>
        /// <param name="indexJ">
        /// Column index.
        /// </param>
        /// <param name="value">
        /// Value to assign.
        /// </param>
        protected override void ChangeElement(int indexI, int indexJ, T value)
        {
            this.SetElement(indexI, indexJ, value);
            string eventMessage = $"Element in Square matrix at index ({indexI}, {indexJ}) has been changed to {value}";
            this.OnElementChange(new ElementChangeArgs(indexI, indexJ, eventMessage));
        }
    }
}
