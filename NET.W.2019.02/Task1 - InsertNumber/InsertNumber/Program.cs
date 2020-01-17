using System;

namespace InsertNumber
{
    /// <summary>
    /// Contains entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        public static void Main()
        {
            try
            {
                int x = Inserter.InsertNumber(873, -37, 2, 2);
                Console.WriteLine(x);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
