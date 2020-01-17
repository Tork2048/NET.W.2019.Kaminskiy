// <copyright file="TestData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GenericMatrix.Tests
{
    /// <summary>
    /// Class that provides data for tests.
    /// </summary>
    /// <typeparam name="T">
    /// Tested methods are generic. Data class should have the same type of data.
    /// </typeparam>
    public class TestData<T>
    {
        /// <summary>
        /// Gets or Sets square array for tests.
        /// </summary>
        public T[,] SqaureArray { get; set; }

        /// <summary>
        /// Gets or Sets symmetric array for tests.
        /// </summary>
        public T[,] SymmmetricArray { get; set; }

        /// <summary>
        /// Gets or Sets diagonal array for tests.
        /// </summary>
        public T[,] DiagonalArray { get; set; }

        /// <summary>
        /// Gets or Sets result of matrices addition array.
        /// </summary>
        public T[,] AdditionResult { get; set; }

        /// <summary>
        /// Gets or Sets row index to change element.
        /// </summary>
        public int IndexI { get; set; }

        /// <summary>
        /// Gets or Sets column index to change element.
        /// </summary>
        public int IndexJ { get; set; }

        /// <summary>
        /// Gets or Sets value to change.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets or Sets message from matrices events. Is set by GetEvent method which handles the event.
        /// </summary>
        public string EventMessage { get; set; }

        /// <summary>
        /// Gets or Sets expected event message from square matrix.
        /// </summary>
        public string ExpectedEventMessageSquare { get; set; }

        /// <summary>
        /// Gets or Sets expected event message from symmetric matrix.
        /// </summary>
        public string ExpectedEventMessageSymmetric { get; set; }

        /// <summary>
        /// Gets or Sets expected event message from diagonal matrix.
        /// </summary>
        public string ExpectedEventMessageDiagonal { get; set; }

        /// <summary>
        /// Method that will handle matrix event.
        /// </summary>
        /// <param name="args">
        /// Event args
        /// </param>
        public void GetEvent(ElementChangeArgs args)
        {
            this.EventMessage = args.EventMessage;
        }
    }
}
