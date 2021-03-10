using System;

namespace P70
{
    class Program
    {
        static void Main(string[] arags)
        {

        }
    }

    public class Solution
    {
        public int ClimbStairs(int n)
        {
            int a = 1;
            int b = 2;
            int c = n;
            for (int i = 2; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }
    }
}