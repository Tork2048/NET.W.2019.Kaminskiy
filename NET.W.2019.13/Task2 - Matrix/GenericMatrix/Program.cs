// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GenericMatrix
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
            double[,] matrixArray = new double[,]
            {
                { 0, 1, 2, 3 },
                { 4, 5, 6, 7 },
                { 8, 9, 10, 11 },
                { 12, 13, 14, 15 },
            };

            double[,] matrixArray2 = new double[,]
            {
                { 0, 1, 2, 3 },
                { 1, 5, 6, 7 },
                { 2, 6, 10, 11 },
                { 3, 7, 11, 15 },
            };

            double[,] matrixArray3 = new double[,]
            {
                { 1, 0, 0, 0 },
                { 0, 5, 0, 0 },
                { 0, 0, 10, 0 },
                { 0, 0, 0, 0 },
            };

            SquareMatrix<double> squareMatrix = new SquareMatrix<double>(matrixArray);
            SymmetricMatrix<double> symmetricMatrix = new SymmetricMatrix<double>(matrixArray2);
            DiagonalMatrix<double> diagonalMatrix = new DiagonalMatrix<double>(matrixArray3);

            Matrix<double> sumresult = symmetricMatrix.Add(diagonalMatrix);
            sumresult.ElementChange += DisplayEventMessage;

            sumresult[3, 3] = 2048;
            DisplayMatrix(sumresult);

            squareMatrix.ElementChange += DisplayEventMessage;
            symmetricMatrix.ElementChange += DisplayEventMessage;
            diagonalMatrix.ElementChange += DisplayEventMessage;

            squareMatrix[1, 3] = 10d;
            symmetricMatrix[2, 2] = 33d;
            diagonalMatrix[3, 3] = 1d;

            DisplayMatrix<double>(squareMatrix);
            DisplayMatrix<double>(symmetricMatrix);
            DisplayMatrix<double>(diagonalMatrix);
        }

        private static void DisplayEventMessage(ElementChangeArgs args)
        {
            Console.WriteLine(args.EventMessage);
        }

        private static void DisplayMatrix<T>(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
