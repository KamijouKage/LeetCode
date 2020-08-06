using System;
using System.Collections.Generic;

namespace P7
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.Write(solution.Reverse(-123));
        }
    }

    public class Solution 
    {
        public int Reverse(int x) 
        {
            int result = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x = x / 10;
                if (result > int.MaxValue / 10 || (result == int.MaxValue/10 && pop > 7))
                    return 0;
                if (result < int.MinValue / 10 || (result == int.MinValue/10 && pop < -8))
                    return 0;
                result = result * 10 + pop;
            }
            return result;
        }
    }
}