using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            double x = FindNthRoot(-338, 3, 0.0001);
            Console.WriteLine(x);
            Console.ReadKey();
        }
        /// <summary>
        /// Calculates Nth root using Newton's method with given precision
        /// </summary>

        public static double FindNthRoot(double A, double n, double precision)
        {
            if (n<=0 || precision >= 1 ||precision<=0||(A < 0) && (n % 2 == 0))
            {
                Console.WriteLine("invalid arguments");
                return A;
            }
            if (n == 1)
            {
                return A;
            }

            double x0 = A / n;
            double x1 = ((A / Math.Pow(x0, n - 1)) + x0 * (n - 1)) / n;
            while (Math.Abs(x1 - x0) > precision/10)
            {
                x0 = x1;
                x1 = ((A / Math.Pow(x0, n - 1)) + x0 * (n - 1)) / n;
                //Console.WriteLine(x1);
            }

            int d = 0;
            while (precision < 1)
            {
                precision *= 10;
                d++;
            }
            return Math.Round(x1, d);
            
        }
    }
}
