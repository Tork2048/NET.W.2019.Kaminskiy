// <copyright file="AdditionExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GenericMatrix
{
    using System;

    /// <summary>
    /// Extension for Matrix class which implements Add extension method.
    /// </summary>
    public static class AdditionExtension
    {
        /// <summary>
        /// Extension method for Matrix class.
        /// Performs addition for this and another matrix.
        /// </summary>
        /// <typeparam name="T">
        /// Matrix data type.
        /// </typeparam>
        /// <param name="matrix1">
        /// First matrix.
        /// </param>
        /// <param name="matrix2">
        /// Second matrix.
        /// </param>
        /// <returns>
        /// Matrix object as a result of addition.
        /// </returns>
        public static Matrix<T> Add<T>(this Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<T> result = null;
            try
            {
                result = Addition<T>((dynamic)matrix1, (dynamic)matrix2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Checks if dimensions for 2 matrices are the same.
        /// </summary>
        /// <typeparam name="T">
        /// Matrix data type.
        /// </typeparam>
        /// <param name="matrix1">
        /// First matrix.
        /// </param>
        /// <param name="matrix2">
        /// Second matrix.
        /// </param>
        private static void VerifyDimensions<T>(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Columns != matrix2.Columns || matrix1.Rows != matrix2.Rows)
            {
                throw new InvalidOperationException(message: "Impossible to add matrices with different dimensions");
            }
        }

        /// <summary>
        /// Performs addition of 2 matrices.
        /// Stores result in on of input argument in order to keep object type.
        /// </summary>
        /// <typeparam name="T">
        /// Matrix data type.
        /// </typeparam>
        /// <param name="matrix1">
        /// First matrix.
        /// </param>
        /// <param name="matrix2">
        /// Second matrix.
        /// </param>
        /// <param name="result">
        /// Used to store the result of method.
        /// </param>
        private static void MatricesSum<T>(Matrix<T> matrix1, Matrix<T> matrix2, Matrix<T> result)
        {
            VerifyDimensions<T>(matrix1, matrix2);

            dynamic firstMatrix = matrix1;
            dynamic secondMatrix = matrix2;

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    ((SquareMatrix<T>)result)[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                }
            }
        }

        /// <summary>
        /// Method creates Matrix object with an empty array of T with specific dimension as a result.
        /// Delegates addition to MatricesSum method.
        /// </summary>
        /// <typeparam name="T">
        /// Matrix data type.
        /// </typeparam>
        /// <param name="matrix1">
        /// First matrix.
        /// </param>
        /// <param name="matrix2">
        /// Second matrix.
        /// </param>
        /// <returns>
        /// Addition result.
        /// </returns>
        private static SquareMatrix<T> Addition<T>(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            SquareMatrix<T> resultMatrix = new SquareMatrix<T>(matrix1.Rows);

            MatricesSum<T>(matrix1, matrix2, resultMatrix);

            return resultMatrix;
        }
    }
}
