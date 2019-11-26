using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    /// <summary>
    /// Unchangeable class that represents Polynomial.
    /// Polynomial contains only 1 variable.
    /// Factors are stored in one-dimensional array in the following way:
    /// K[0]x^0+K[1]x^1+...+K[n]x^n
    /// </summary>
    public class Polynom
    {
        public Polynom(params double[] array)
        {            
            this.K = GetRidOfZeroes(array);    
        }

        public double[] K { get; }

        public static Polynom operator +(Polynom p1, Polynom p2)
        {
            return Add(p1, p2);
        }

        public static Polynom operator -(Polynom p1, Polynom p2)
        {
            return Subtract(p1, p2);
        }

        public static Polynom operator *(Polynom p1, Polynom p2)
        {
            return Multiply(p1, p2);
        }

        public static bool operator ==(Polynom p1, Polynom p2)
        {
            return Compare(p1, p2);
        }

        public static bool operator !=(Polynom p1, Polynom p2)
        {
            return !Compare(p1, p2);
        }

        /// <summary>
        /// Method returns Polynomial in the form of string expression
        /// </summary>
        /// <returns>
        /// string expression
        /// </returns>
        public override string ToString()
        {
            bool first = true;
            string expression = string.Empty;
            for (int i = K.Length - 1; i >= 0; i--)
            {
                if (K[i] != 0)
                {
                    if (K[i] < 0)
                    {
                        first = false;
                    }
                    else
                    {
                        if (!first)
                        {
                            expression += "+";
                        }
                        else
                        {
                            first = false;
                        }
                    }

                    if (((K[i] != 1) && (K[i] != -1)) || (i == 0))
                    {
                        expression += Convert.ToString(K[i]);
                    }
                    else
                    {
                        if (K[i] == -1)
                        {
                            expression += "-";
                        }
                    }

                    if (i != 0)
                    {
                        expression += "x";
                        if (i > 1)
                        {
                            expression = expression + "^" + Convert.ToString(i);
                        }
                    }
                }

                if (expression == string.Empty)
                {
                    expression = "0";
                }
            }

            return expression;
        }

        public override bool Equals(object obj)
        {
            if (obj is Polynom)
            {
                return Compare(this, (Polynom)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.K.Length - 1;
        }

        /// <summary>
        /// Static method that take 2 polynomials and performs an addition
        /// </summary>
        /// <param name="p1">
        /// Polynomial 1
        /// </param>
        /// <param name="p2">
        /// Polynomial 2
        /// </param>
        /// <returns>
        /// Result of addition
        /// </returns>
        private static Polynom Add(Polynom p1, Polynom p2)
        {
            if (p1.K.Length < p2.K.Length)
            {
                Polynom p_temp = p1;
                p1 = p2;
                p2 = p_temp;
            }

            double[] temp_result = new double[p1.K.Length];

            for (int i = 0; i < p1.K.Length; i++)
            {
                if (i < p2.K.Length)
                {
                    temp_result[i] = p1.K[i] + p2.K[i];
                }
                else
                {
                    temp_result[i] = p1.K[i];
                }
            }

            return new Polynom(GetRidOfZeroes(temp_result));
        }

        /// <summary>
        /// Static method cuts off zero factors from the end of the array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static double[] GetRidOfZeroes(double[] array)
        {
            int length = array.Length;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if ((array[i] == 0) && (i > 0))
                {
                    length--;
                }
                else
                {
                    break;
                }
            }

            double[] result = new double[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = array[i];
            }

            return result;
        }

        /// <summary>
        /// Static method multiplies 2 polynomials
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>
        /// Result of multiplication
        /// </returns>
        private static Polynom Multiply(Polynom p1, Polynom p2)
        {
            double[] result_array = new double[p1.K.Length + p2.K.Length];
            for (int i = p2.K.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < p1.K.Length; j++)
                {
                    result_array[i + j] += p1.K[j] * p2.K[i];
                }
            }

            return new Polynom(result_array);
        }

        /// <summary>
        /// Subtraction
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private static Polynom Subtract(Polynom p1, Polynom p2)
        {
            double[] new_array = new double[p2.K.Length];
            for (int i = 0; i < p2.K.Length; i++)
            {
                new_array[i] = p2.K[i] * (-1);
            }

            return Add(p1, new Polynom(new_array));
        }

        private static bool Compare(Polynom p1, Polynom p2)
        {
            if (p1.K.Length == p2.K.Length)
            {
                for (int i = 0; i < p1.K.Length; i++)
                {
                    if (p1.K[i] != p2.K[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
