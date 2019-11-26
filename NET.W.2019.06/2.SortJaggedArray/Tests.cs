using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SortJaggedArray.Tests
{
    [TestFixture]
    public class Tests
    {
        private static TestData[] testarraySUM = new TestData[]
            {
                new TestData
                (new int[][]
                    {
                        new int[] { 0, 4, 7, 1 },
                        new int[] { 10, 6, 11, 20, 0, 3 },
                        new int[] { -1, 9, 34, 9, 3, -44 },
                        new int[] { 45, 23, 3, 87 },
                    },

                    new int[][]
                    {
                        new int[] { -1, 9, 34, 9, 3, -44 },
                        new int[] { 0, 4, 7, 1 },
                        new int[] { 10, 6, 11, 20, 0, 3 },
                        new int[] { 45, 23, 3, 87 },
                    },
                    
                    SortClass.SortOrderOption.Ascend,

                    SortClass.SortOption.ByRowSum),

                new TestData
                (new int[][]
                    {
                        new int[] { 0, 4, 7, 1 },
                        new int[] { 10, 6, 11, 20, 0, 3 },
                        new int[] { -1, 9, 34, 9, 3, -44 },
                        new int[] { 45, 23, 3, 87 },
                    },

                    new int[][]
                    {
                        new int[] { 45, 23, 3, 87 },
                        new int[] { 10, 6, 11, 20, 0, 3 },
                        new int[] { 0, 4, 7, 1 },
                        new int[] { -1, 9, 34, 9, 3, -44 },
                    },

                    SortClass.SortOrderOption.Descend,

                    SortClass.SortOption.ByRowSum),
            };

        private static TestData[] testarrayMin = new TestData[]
            {
                new TestData
                (new int[][]
                    {
                        new int[] { -1, 4, 7, 1 },
                        new int[] { 10, 6, 11, 20, 0, 3 },
                        new int[] { -1, 9, 34, 9, 3, -44 },
                        new int[] { 45, 23, 3, 87 },
                    },

                    new int[][]
                    {
                        new int[] { -1, 9, 34, 9, 3, -44 },
                        new int[] { -1, 4, 7, 1 },
                        new int[] { 10, 6, 11, 20, 0, 3 },
                        new int[] { 45, 23, 3, 87 },
                    },

                    SortClass.SortOrderOption.Ascend,

                    SortClass.SortOption.ByMinInRow),

                new TestData
                (new int[][]
                    {
                        new int[] { 0, 4, 7, 1 },
                        new int[] { 10, 6, 11, 20, 0, 3 },
                        new int[] { -1, 9, 34, 9, 3, -44 },
                        new int[] { 45, 23, 3, 87 },
                    },

                    new int[][]
                    {
                        new int[] { 45, 23, 3, 87 },
                        new int[] { 10, 6, 11, 20, 0, 3 },
                        new int[] { 0, 4, 7, 1 },
                        new int[] { -1, 9, 34, 9, 3, -44 },
                    },

                    SortClass.SortOrderOption.Descend,

                    SortClass.SortOption.ByMinInRow),
            };

        private static TestData[] testarrayMax = new TestData[]
            {
                new TestData
                (new int[][]
                    {
                        new int[] { 0, 4, 7, 1 },
                        new int[] { 10, 6, 11, 20, 0, 3 },
                        new int[] { -1, 9, 34, 9, 3, -44 },
                        new int[] { 45, 23, 3, 87 },
                    },

                    new int[][]
                    {
                        new int[] { 0, 4, 7, 1 },
                        new int[] { 10, 6, 11, 20, 0, 3 },
                        new int[] { -1, 9, 34, 9, 3, -44 },                                                
                        new int[] { 45, 23, 3, 87 },
                    },

                    SortClass.SortOrderOption.Ascend,

                    SortClass.SortOption.ByMaxInRow),

                new TestData
                (new int[][]
                    {
                        new int[] { 0, 4, 7, 1 },
                        new int[] { 10, 6, 11, 20, 0, 3 },
                        new int[] { -1, 9, 34, 9, 3, -44 },
                        new int[] { 45, 23, 3, 87 },
                    },

                    new int[][]
                    {
                        new int[] { 45, 23, 3, 87 },
                        new int[] { -1, 9, 34, 9, 3, -44 },
                        new int[] { 10, 6, 11, 20, 0, 3 },
                        new int[] { 0, 4, 7, 1 },
                    },

                    SortClass.SortOrderOption.Descend,

                    SortClass.SortOption.ByMaxInRow),
            };

        [Test, TestCaseSource("testarraySUM")]
        public void TestSortBySumInRow(TestData testdata)
        {
            int[][] result = SortClass.JuggedArraySort(testdata.SourceArray, testdata.Option, testdata.OrderOption);
            Assert.That(result, Is.EqualTo(testdata.ExpectedArray));
        }

        [Test, TestCaseSource("testarrayMin")]
        public void TestSortByMinInRow(TestData testdata)
        {
            int[][] result = SortClass.JuggedArraySort(testdata.SourceArray, testdata.Option, testdata.OrderOption);
            Assert.That(result, Is.EqualTo(testdata.ExpectedArray));
        }

        [Test, TestCaseSource("testarrayMax")]
        public void TestSortByMaxInRow(TestData testdata)
        {
            int[][] result = SortClass.JuggedArraySort(testdata.SourceArray, testdata.Option, testdata.OrderOption);
            Assert.That(result, Is.EqualTo(testdata.ExpectedArray));
        }
    }
}
