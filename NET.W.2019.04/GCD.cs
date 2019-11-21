using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            int time;
            int result = GCD_Calculation.GetGCD(GCD_Calculation.Alg_option.Stein, out time, 715, 627, 6259, 858,8679,28259);
            Console.WriteLine(result);
            Console.WriteLine($"Calculation time - {time} nanoseconds");
            Console.ReadKey();
        }
    }
}
