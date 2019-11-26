using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Polynom x1 = new Polynom();
            Polynom x2 = new Polynom();
            Polynom x3 = x1 * x2;
            string str = x3.ToString();
            for (int i = 0; i < x3.K.Length; i++)
            {
                Console.Write($"{x3.K[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine(str);
            Console.ReadKey();            
        }
    }
}
