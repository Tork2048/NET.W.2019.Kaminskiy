// <copyright file="SymmetricMatrix.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GenericMatrix
{
    using System;

    /// <summary>
    /// More specific matrix - square.
    /// Derived from SqaureMatrix.
    /// </summary>
    /// <typeparam name="T">
    /// Matrix data type.
    /// </typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// Uses base constructor.
        /// </summary>
        /// <param name="array">
        /// Given array.
        /// </param>
        public SymmetricMatrix(T[,] array)
            : base(array)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="dimension">
        /// Dimension to create symmetric array.
        /// </param>
        public SymmetricMatrix(int dimension)
            : base(dimension)
        {
        }

        /// <summary>
        /// Validation logic for symetric matrix.
        /// </summary>
        /// <param name="array">
        /// Given array.
        /// </param>
        protected override void ValidateMatrix(T[,] array)
        {
            base.ValidateMatrix(array);

            int rows = array.GetUpperBound(0) + 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else if (this.comparer.Compare(array[i, j], array[j, i]) != 0)
                    {
                        throw new InvalidOperationException(message: "Array is not symmetric. Object cannot be constructed");
                    }
                }
            }
        }

        /// <summary>
        /// Element change logic for symmetric matrix.
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
            this.CheckIndex(indexI, indexJ);

            if (indexI != indexJ && this.comparer.Compare(value, this.array[indexJ, indexI]) != 0)
            {
                throw new ArgumentException(message: $"Element {value} at index ({indexI}, {indexJ}) is not compliant with symmetric matrix");
            }

            this.SetElement(indexI, indexJ, value);
            string eventMessage = $"Element in Symmetric matrix at index ({indexI}, {indexJ}) has been changed to {value}";
            this.OnElementChange(new ElementChangeArgs(indexI, indexJ, eventMessage));
        }
    }
}
