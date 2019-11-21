using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleToString
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.MinValue;
            Console.WriteLine(x.ConvertToString());

            Console.ReadKey();
        }
    }
}
