// <copyright file="Matrix.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GenericMatrix
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Abstract matrix class that implements common functionality.
    /// </summary>
    /// <typeparam name="T">
    /// Matrix data type (array elements).
    /// </typeparam>
    public abstract class Matrix<T>
    {
        /// <summary>
        /// Array that represents matrix.
        /// </summary>
        protected T[,] array;

        /// <summary>
        /// Comparer, that will be extracted from T type in order to compare elements.
        /// </summary>
        protected IComparer<T> comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// Creates object with given array as matrix.
        /// Validates array first.
        /// </summary>
        /// <param name="array">
        /// Given array.
        /// </param>
        public Matrix(T[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), message: "Array cannot be null");
            }

            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
            {
                throw new ArgumentException(message: $"The {typeof(T)} must immplement IComparable<{typeof(T)}> interface.");
            }

            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
            {
                throw new ArgumentNullException($"The {typeof(T)} must immplement IComparable interface.");
            }

            this.comparer = Comparer<T>.Default;

            this.ValidateMatrix(array);

            this.SetMatrix(array);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// Creates object with empty array of given dimension.
        /// </summary>
        /// <param name="rows">
        /// Number of rows in array.
        /// </param>
        /// <param name="columns">
        /// number of columns in array.
        /// </param>
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException(message: "Invalid matrix dimensions");
            }

            this.array = new T[rows, columns];
        }

        /// <summary>
        /// Event that occurs upon element change.
        /// </summary>
        public event Action<ElementChangeArgs> ElementChange;

        /// <summary>
        /// Gets number of rows in array.
        /// </summary>
        public int Rows
        {
            get => this.array.GetUpperBound(0) + 1;
        }

        /// <summary>
        /// Gets number of columns in array.
        /// </summary>
        public int Columns
        {
            get => this.array.GetUpperBound(1) + 1;
        }

        /// <summary>
        /// Object indexer. Gets and Sets array elements.
        /// </summary>
        /// <param name="i">
        /// Row index.
        /// </param>
        /// <param name="j">
        /// Column index.
        /// </param>
        /// <returns>
        /// Array element with given indexes.
        /// </returns>
        public virtual T this[int i, int j]
        {
            get
            {
                this.CheckIndex(i, j);
                return this.array[i, j];
            }

            set
            {
                this.CheckIndex(i, j);
                this.ChangeElement(i, j, value);
            }
        }

        /// <summary>
        /// Checks if indexes are within array range.
        /// </summary>
        /// <param name="i">
        /// Row index.
        /// </param>
        /// <param name="j">
        /// Column index.
        /// </param>
        protected void CheckIndex(int i, int j)
        {
            if (i > this.array.GetUpperBound(0) || j > this.array.GetUpperBound(1) || i < 0 || j < 0)
            {
                throw new IndexOutOfRangeException(message: "Index is out of range");
            }
        }

        /// <summary>
        /// Method that handles event (Wrapper).
        /// </summary>
        /// <param name="args">
        /// Event arguments.
        /// </param>
        protected void OnElementChange(ElementChangeArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args), message: "Event argument cannot be null");
            }

            this.ElementChange?.Invoke(args);
        }

        /// <summary>
        /// Sets element in array.
        /// </summary>
        /// <param name="i">
        /// Row index.
        /// </param>
        /// <param name="j">
        /// Column index.
        /// </param>
        /// <param name="value">
        /// Value to assign.
        /// </param>
        protected void SetElement(int i, int j, T value)
        {
            this.CheckIndex(i, i);
            this.array[i, j] = value;
        }

        /// <summary>
        /// Will be used to copy given array to this array with constructor.
        /// </summary>
        /// <param name="array">
        /// Given array.
        /// </param>
        protected abstract void SetMatrix(T[,] array);

        /// <summary>
        /// Will be used to check if given array is valid for this object.
        /// </summary>
        /// <param name="array">
        /// Given array.
        /// </param>
        protected abstract void ValidateMatrix(T[,] array);

        /// <summary>
        /// Will be used to change element in array.
        /// Wraps SetElement, will also contain event invoke and validation logic.
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
        protected abstract void ChangeElement(int indexI, int indexJ, T value);
    }
}
