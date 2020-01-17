// <copyright file="Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GenericMatrix.Tests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Class with unit tests (Nunit).
    /// </summary>
    [TestFixture]
    public class Tests
    {
        private static TestData<double>[] testdata = new TestData<double>[]
        {
            new TestData<double>
            {
                SqaureArray = new double[,]
                {
                    { 0, 1, 2, 3 },
                    { 4, 5, 6, 7 },
                    { 8, 9, 10, 11 },
                    { 12, 13, 14, 15 },
                },

                SymmmetricArray = new double[,]
                {
                    { 0, 1, 2, 3 },
                    { 1, 5, 6, 7 },
                    { 2, 6, 10, 11 },
                    { 3, 7, 11, 15 },
                },

                DiagonalArray = new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 5, 0, 0 },
                    { 0, 0, 10, 0 },
                    { 0, 0, 0, 0 },
                },

                IndexI = 2,
                IndexJ = 2,
                Value = 33,
                ExpectedEventMessageSquare = $"Element in Square matrix at index (2, 2) has been changed to 33",
                ExpectedEventMessageSymmetric = $"Element in Symmetric matrix at index (2, 2) has been changed to 33",
                ExpectedEventMessageDiagonal = $"Element in Diagonal matrix at index (2, 2) has been changed to 33",
            },

            new TestData<double>
            {
                SqaureArray = new double[,]
                {
                    { 0, 1, 2, 3 },
                    { 4, 5, 6, 7 },
                    { 8, 9, 10, 11 },
                    { 12, 13, 14, 15 },
                },

                SymmmetricArray = new double[,]
                {
                    { 0, 1, 2, 3 },
                    { 1, 5, 0, 7 },
                    { 2, 0, 10, 11 },
                    { 3, 7, 11, 15 },
                },

                DiagonalArray = new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 5, 0, 0 },
                    { 0, 0, 10, 0 },
                    { 0, 0, 0, 0 },
                },

                IndexI = 2,
                IndexJ = 1,
                Value = 0,
                ExpectedEventMessageSquare = $"Element in Square matrix at index (2, 1) has been changed to 0",
                ExpectedEventMessageSymmetric = $"Element in Symmetric matrix at index (2, 1) has been changed to 0",
                ExpectedEventMessageDiagonal = $"Element in Diagonal matrix at index (2, 1) has been changed to 0",
            },
        };

        private static TestData<double>[] testdataExceptions = new TestData<double>[]
        {
            new TestData<double>
            {
                SqaureArray = new double[,]
                {
                    { 0, 1, 2, 3 },
                    { 4, 5, 6, 7 },
                    { 8, 9, 10, 11 },
                },

                SymmmetricArray = new double[,]
                {
                    { 0, 1, 2, 10 },
                    { 1, 5, 6, 7 },
                    { 2, 6, 10, 11 },
                    { 3, 7, 11, 15 },
                },

                DiagonalArray = new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 5, 0, 0 },
                    { 0, 0, 10, 0 },
                    { 0, 8, 0, 0 },
                },
            },
        };

        private static TestData<double>[] testdataElementChangeExceptions = new TestData<double>[]
        {
            new TestData<double>
            {
                SqaureArray = new double[,]
                {
                    { 0, 1, 2, 3 },
                    { 4, 5, 6, 7 },
                    { 8, 9, 10, 11 },
                    { 12, 13, 14, 15 },
                },

                SymmmetricArray = new double[,]
                {
                    { 0, 1, 2, 3 },
                    { 1, 5, 6, 7 },
                    { 2, 6, 10, 11 },
                    { 3, 7, 11, 15 },
                },

                DiagonalArray = new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 5, 0, 0 },
                    { 0, 0, 10, 0 },
                    { 0, 0, 0, 0 },
                },

                IndexI = 3,
                IndexJ = 2,
                Value = 10,
            },
        };

        private static TestData<double>[] testdataAddition = new TestData<double>[]
        {
            new TestData<double>
            {
                SqaureArray = new double[,]
                {
                    { 0, 1, 2, 3 },
                    { 4, 5, 6, 7 },
                    { 8, 9, 10, 11 },
                    { 12, 13, 14, 15 },
                },

                SymmmetricArray = new double[,]
                {
                    { 0, 1, 2, 3 },
                    { 1, 5, 6, 7 },
                    { 2, 6, 10, 11 },
                    { 3, 7, 11, 15 },
                },

                AdditionResult = new double[,]
                {
                    { 0, 2, 4, 6 },
                    { 5, 10, 12, 14 },
                    { 10, 15, 20, 22 },
                    { 15, 20, 25, 30 },
                },
            },
        };

        /// <summary>
        /// Method that extracts array of T from any matrix.
        /// </summary>
        /// <typeparam name="T">
        /// Generic data type of matrix and array.
        /// </typeparam>
        /// <param name="matrix">
        /// Source matrix array will be extracted from.
        /// </param>
        /// <returns>
        /// array of T.
        /// </returns>
        public static T[,] ExtractArray<T>(Matrix<T> matrix)
        {
            T[,] result = new T[matrix.Rows, matrix.Columns];

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    result[i, j] = matrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Tests successfull square matrix construction, verifies element change
        /// and event message.
        /// </summary>
        /// <param name="testData">
        /// Takes the array of TestData type.
        /// </param>
        [Test]
        [TestCaseSource("testdata")]
        public static void TestSquareMatrix(TestData<double> testData)
        {
            Matrix<double> matrix = new SquareMatrix<double>(testData.SqaureArray);
            matrix.ElementChange += testData.GetEvent;
            matrix[testData.IndexI, testData.IndexJ] = testData.Value;

            Assert.That(testData.EventMessage, Is.EqualTo(testData.ExpectedEventMessageSquare));
            Assert.That(matrix[testData.IndexI, testData.IndexJ], Is.EqualTo(testData.Value));
        }

        /// <summary>
        /// Tests successfull symmetric matrix construction, verifies element change
        /// and event message.
        /// </summary>
        /// <param name="testData">
        /// Takes the array of TestData type.
        /// </param>
        [Test]
        [TestCaseSource("testdata")]
        public static void TestSymmetricMatrix(TestData<double> testData)
        {
            Matrix<double> matrix = new SymmetricMatrix<double>(testData.SymmmetricArray);
            matrix.ElementChange += testData.GetEvent;
            matrix[testData.IndexI, testData.IndexJ] = testData.Value;

            Assert.That(testData.EventMessage, Is.EqualTo(testData.ExpectedEventMessageSymmetric));
            Assert.That(matrix[testData.IndexI, testData.IndexJ], Is.EqualTo(testData.Value));
        }

        /// <summary>
        /// Tests successfull diagonal matrix construction, verifies element change
        /// and event message.
        /// </summary>
        /// <param name="testData">
        /// Takes the array of TestData type.
        /// </param>
        [Test]
        [TestCaseSource("testdata")]
        public static void TestDiagonalMatrix(TestData<double> testData)
        {
            Matrix<double> matrix = new DiagonalMatrix<double>(testData.DiagonalArray);
            matrix.ElementChange += testData.GetEvent;
            matrix[testData.IndexI, testData.IndexJ] = testData.Value;

            Assert.That(testData.EventMessage, Is.EqualTo(testData.ExpectedEventMessageDiagonal));
            Assert.That(matrix[testData.IndexI, testData.IndexJ], Is.EqualTo(testData.Value));
        }

        /// <summary>
        /// Tests exceptions upon failed matrices construction (Square, Symmetric, Diagonal).
        /// </summary>
        /// <param name="testData">
        /// Takes the array of TestData type.
        /// </param>
        [Test]
        [TestCaseSource("testdataExceptions")]
        public static void TestConstructionException(TestData<double> testData)
        {
            Assert.That(() => new SquareMatrix<double>(testData.SqaureArray), Throws.TypeOf<InvalidOperationException>());
            Assert.That(() => new SymmetricMatrix<double>(testData.SymmmetricArray), Throws.TypeOf<InvalidOperationException>());
            Assert.That(() => new DiagonalMatrix<double>(testData.DiagonalArray), Throws.TypeOf<InvalidOperationException>());
        }

        /// <summary>
        /// Tests exception upon failed matrices element change (symmetric, diagonal).
        /// </summary>
        /// <param name="testData">
        /// Takes the array of TestData type.
        /// </param>
        [Test]
        [TestCaseSource("testdataElementChangeExceptions")]
        public static void TestElementChangeException(TestData<double> testData)
        {
            Matrix<double> symmetricMatrix = new SymmetricMatrix<double>(testData.SymmmetricArray);
            Matrix<double> diagonalMatrix = new DiagonalMatrix<double>(testData.DiagonalArray);

            Assert.That(() => symmetricMatrix[testData.IndexI, testData.IndexJ] = testData.Value, Throws.TypeOf<ArgumentException>());
            Assert.That(() => diagonalMatrix[testData.IndexI, testData.IndexJ] = testData.Value, Throws.TypeOf<ArgumentException>());
        }

        /// <summary>
        /// Tests the result of matrices addition.
        /// </summary>
        /// <param name="testData">
        /// Takes the array of TestData type.
        /// </param>
        [Test]
        [TestCaseSource("testdataAddition")]
        public static void TestMatrixAddition(TestData<double> testData)
        {
            Matrix<double> squareMatrix = new SquareMatrix<double>(testData.SqaureArray);
            Matrix<double> symmetricMatrix = new SymmetricMatrix<double>(testData.SymmmetricArray);
            Matrix<double> result = squareMatrix.Add(symmetricMatrix);
            double[,] resultArray = ExtractArray(result);

            Assert.That(resultArray, Is.EqualTo(testData.AdditionResult));
        }
    }
}
