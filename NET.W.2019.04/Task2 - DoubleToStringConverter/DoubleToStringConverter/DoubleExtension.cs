using System;
using System.Linq;

namespace DoubleToString
{
    /// <summary>
    /// class that proves extension method for double type that converts 8 bytes of double value into string.
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Double Extension method that converts 8 bytes of double type into a string.
        /// </summary>
        /// <param name="value">
        /// double number.
        /// </param>
        /// <returns>
        /// string that contains bits of the double value.
        /// </returns>
        public static unsafe string ConvertToString(this double value)
        {
            // the most rational way is to grab 8 bytes directly from memory and convert pointer into ulong
            // code is unsafe
            ulong* bits = (ulong*)(&value);
            string str = string.Empty;

            for (int i = 0; i < 64; i++)
            {
                ulong temp = *bits & 1; // 8 bytes are put into string bit by bit.
                if (temp == 1)
                {
                    str += "1";
                }
                else
                {
                    str += "0";
                }

                *bits >>= 1;
            }

            str = new string(str.Reverse().ToArray()); // put bits inside a string in correct order.
            return str;
        }
    }
}
