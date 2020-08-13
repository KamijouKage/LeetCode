using System;

namespace P29
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.Write(solution.Divide(int.MaxValue, 3));
        }
    }

    public class Solution
    {
        public int Divide(int dividend, int divisor)
        {
            if (dividend == divisor)
            {
                return 1;
            }
            if (dividend == 0 || divisor == int.MinValue)
            {
                return 0;
            }
            bool isPositive = (dividend < 0 && divisor < 0) || (dividend > 0 && divisor > 0);
            int result = 0;
            int count = 0;
            divisor = Math.Abs(divisor);
            if (dividend == int.MinValue)
            {
                dividend += divisor;
                result++;
            }
            dividend = Math.Abs(dividend);
            while (dividend >= divisor)
            {
                int temp = divisor;
                int mul = 1;
                while (dividend >= (temp << 1) && (temp << 1 > 0))
                {
                    temp <<= 1;
                    mul <<= 1;
                }
                count += mul;
                dividend -= temp;
            }
            if (result == 1 && count == int.MaxValue)
            {
                return isPositive ? int.MaxValue : int.MinValue;
            }
            return isPositive ? (result + count) : -(result + count);
        }
    }
}