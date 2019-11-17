using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertBits
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int x = InsertNumber(873, -37, 2, 2);
                Console.WriteLine(x);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadKey();
        }

        /// <summary>
        /// Method inserts y value bits to i..j bit range of the x value
        /// </summary>
        /// <param name="x">
        /// First value, int
        /// </param>
        /// <param name="y">
        /// Second value, int
        /// </param>
        /// <param name="i">
        /// lower bit position
        /// </param>
        /// <param name="j">
        /// higher bit position (j>=i)
        /// </param>
        /// <returns>
        /// modified x;
        /// </returns>

        public static int InsertNumber(int x, int y, int i, int j)
        {
            
            if (i > j || j > 31)
            {
                throw new ArgumentException();                
            }

            //Algorithm uses shifts. It appears that expression value<<32 has no effect whatsoever - value remains the same (compiler bug?). 
            //Value <<31; Value<<1 works as expected
            //integers are converted to unsigned for convenience. 
            //If most significant bit of signed integer becomes 1 - value becomes negative and right shift fills bits with ones instead of zeroes.
            //explicit conversion (uint)value does not affect bit structure of the value, only its type.


            //The goal is to nulify bits in i..j range of the first value(x). 
            //x is devided into 2 parts.
            //First part preserves bits to the right of i:
            uint right_x = (uint)x << 31 - i; right_x <<= 1; 
            right_x >>= 31 - i; right_x >>= 1;
            //Console.WriteLine(right_x);

            //Second part preserves bits to the left of j
            uint left_x = (uint)x >> j; left_x >>= 1; 
            left_x <<= (j); left_x <<= 1;
            //Console.WriteLine(left_x);
            //Console.WriteLine((int)left_x);

            //Nulify all bits of y except for i..j range
            uint range_y = (uint)y<<i;
            range_y <<= 31 - j;            
            range_y >>= 31 - j;
            //Console.WriteLine(range_y);
                        
            //All parts are united with | operation and converted back to signed integer
            x = (int)(right_x | left_x | range_y);

            return x;
        }
    }
}
