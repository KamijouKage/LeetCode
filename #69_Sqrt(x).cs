using System;

namespace P69
{
    class Program
    {
        static void Main(string[] arags)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.MySqrt(546646453));
        }
    }

    public class Solution
    {
        public int MySqrt(int x)
        {
            int l = 1;
            int r = x / 2;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                long midSquare = (long)mid * mid;
                long midPlusOneSquare = (long)(mid + 1) * (mid + 1);
                if (midSquare <= x && midPlusOneSquare > x)
                {
                    return mid;
                }
                if (midSquare < x)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return 1;
        }
    }
}