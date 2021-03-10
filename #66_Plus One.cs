using System;

namespace P66
{
    class Program
    {
        static void Main(string[] arags)
        {

        }
    }

    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            digits[digits.Length - 1]++;
            for (int i = digits.Length - 1; i > 0; i--)
            {
                if (digits[i] == 10)
                {
                    digits[i] = 0;
                    digits[i - 1]++;
                }
                else
                {
                    break;
                }
            }
            if (digits[0] == 10)
            {
                digits[0] = 0;
                int[] result = new int[digits.Length + 1];
                for (int i = result.Length - 1; i > 0; i--)
                {
                    result[i] = digits[i - 1];
                }
                result[0] = 1;
                return result;
            }
            return digits;
        }
    }
}