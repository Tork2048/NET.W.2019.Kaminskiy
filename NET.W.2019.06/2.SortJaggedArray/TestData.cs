using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortJaggedArray.Tests
{
    public class TestData
    {
        public TestData(int[][] source, int[][] result, SortClass.SortOrderOption orderoption, SortClass.SortOption option)
        {
            SourceArray = source;
            ExpectedArray = result;
            OrderOption = orderoption;
            Option = option;
        }

        public int[][] SourceArray { get; set; }

        public int[][] ExpectedArray { get; set; }
        
        public SortClass.SortOrderOption OrderOption { get; set; }

        public SortClass.SortOption Option { get; set; }
    }
}
