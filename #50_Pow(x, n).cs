using System;
using System.Collections.Generic;

namespace P50
{
    class Program
    {
        static void Main(string[] rags)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.MyPow(2, 2));
        }
    }

    public class Solution
    {
        public double MyPow(double x, int n)
        {
            long longN = n;
            if (longN < 0)
            {
                x = 1 / x;
                longN = -longN;
            }
            double result = 1;
            for (long i = longN; i > 0; i /= 2)
            {
                if ((i % 2) == 1)
                {
                    result *= x;
                }
                x *= x;
            }
            return result;
        }
    }
}