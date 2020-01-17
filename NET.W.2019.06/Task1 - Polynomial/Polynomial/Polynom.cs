using System;

namespace Polynomial
{
    /// <summary>
    /// Unchangeable class that represents Polynomial.
    /// Polynomial contains only 1 variable.
    /// Factors are stored in one-dimensional array in the following way:
    /// K[0]x^0+K[1]x^1+...+K[n]x^n.
    /// </summary>
    public class Polynom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynom"/> class.
        /// </summary>
        /// <param name="array">
        /// Array of factors.
        /// </param>
        public Polynom(params double[] array)
        {
            this.ArrayOfFactors = GetRidOfZeroes(array);
        }

        /// <summary>
        /// Gets the array of polynomial factors.
        /// </summary>
        /// <value>
        /// The array of polynomial factors.
        /// </value>
        public double[] ArrayOfFactors { get; }

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
        /// Method returns Polynomial in the form of string expression.
        /// </summary>
        /// <returns>
        /// string expression.
        /// </returns>
        public override string ToString()
        {
            bool first = true;
            string expression = string.Empty;
            for (int i = this.ArrayOfFactors.Length - 1; i >= 0; i--)
            {
                if (this.ArrayOfFactors[i] != 0)
                {
                    if (this.ArrayOfFactors[i] < 0)
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

                    if (((this.ArrayOfFactors[i] != 1) && (this.ArrayOfFactors[i] != -1)) || (i == 0))
                    {
                        expression += Convert.ToString(this.ArrayOfFactors[i]);
                    }
                    else
                    {
                        if (this.ArrayOfFactors[i] == -1)
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

        /// <summary>
        /// Overriden Equils method.
        /// </summary>
        /// <param name="obj">
        /// Object to compare to.
        /// </param>
        /// <returns>
        /// Bool.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Polynom)
            {
                return Compare(this, (Polynom)obj);
            }

            return false;
        }

        /// <summary>
        /// Overriden GetHashCode.
        /// </summary>
        /// <returns>
        /// integer hashcode.
        /// </returns>
        public override int GetHashCode()
        {
            return this.ArrayOfFactors.Length - 1;
        }

        /// <summary>
        /// Static method that take 2 polynomials and performs an addition.
        /// </summary>
        /// <param name="firstPolynom">
        /// Polynomial 1.
        /// </param>
        /// <param name="secondPolynom">
        /// Polynomial 2.
        /// </param>
        /// <returns>
        /// Result of addition.
        /// </returns>
        private static Polynom Add(Polynom firstPolynom, Polynom secondPolynom)
        {
            if (firstPolynom.ArrayOfFactors.Length < secondPolynom.ArrayOfFactors.Length)
            {
                Polynom p_temp = firstPolynom;
                firstPolynom = secondPolynom;
                secondPolynom = p_temp;
            }

            double[] temp_result = new double[firstPolynom.ArrayOfFactors.Length];

            for (int i = 0; i < firstPolynom.ArrayOfFactors.Length; i++)
            {
                if (i < secondPolynom.ArrayOfFactors.Length)
                {
                    temp_result[i] = firstPolynom.ArrayOfFactors[i] + secondPolynom.ArrayOfFactors[i];
                }
                else
                {
                    temp_result[i] = firstPolynom.ArrayOfFactors[i];
                }
            }

            return new Polynom(GetRidOfZeroes(temp_result));
        }

        /// <summary>
        /// Static method cuts off zero factors from the end of the array.
        /// </summary>
        /// <param name="array">
        /// Array of factors.
        /// </param>
        /// <returns>
        /// Array of factors with no zeroes at the end.
        /// </returns>
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
        /// Static method multiplies 2 polynomials.
        /// </summary>
        /// <param name="firstPolynom">
        /// first polynomial.
        /// </param>
        /// <param name="secondPolynom">
        /// second polynomial.
        /// </param>
        /// <returns>
        /// Result of multiplication.
        /// </returns>
        private static Polynom Multiply(Polynom firstPolynom, Polynom secondPolynom)
        {
            double[] result_array = new double[firstPolynom.ArrayOfFactors.Length + secondPolynom.ArrayOfFactors.Length];
            for (int i = secondPolynom.ArrayOfFactors.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < firstPolynom.ArrayOfFactors.Length; j++)
                {
                    result_array[i + j] += firstPolynom.ArrayOfFactors[j] * secondPolynom.ArrayOfFactors[i];
                }
            }

            return new Polynom(result_array);
        }

        /// <summary>
        /// Subtraction.
        /// </summary>
        /// <param name="firstPolynom">
        /// first polynomial.
        /// </param>
        /// <param name="secondPolynom">
        /// second polynomial.
        /// </param>
        /// <returns>
        /// Result of subtraction.
        /// </returns>
        private static Polynom Subtract(Polynom firstPolynom, Polynom secondPolynom)
        {
            double[] new_array = new double[secondPolynom.ArrayOfFactors.Length];
            for (int i = 0; i < secondPolynom.ArrayOfFactors.Length; i++)
            {
                new_array[i] = secondPolynom.ArrayOfFactors[i] * (-1);
            }

            return Add(firstPolynom, new Polynom(new_array));
        }

        private static bool Compare(Polynom p1, Polynom p2)
        {
            if (p1.ArrayOfFactors.Length == p2.ArrayOfFactors.Length)
            {
                for (int i = 0; i < p1.ArrayOfFactors.Length; i++)
                {
                    if (p1.ArrayOfFactors[i] != p2.ArrayOfFactors[i])
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
