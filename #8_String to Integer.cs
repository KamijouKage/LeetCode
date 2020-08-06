using System;

namespace P8
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.MyAtoi("42"));
            Console.WriteLine(solution.MyAtoi("  -42"));
            Console.WriteLine(solution.MyAtoi("42 aaa"));
            Console.WriteLine(solution.MyAtoi("aa 42"));
            Console.WriteLine(solution.MyAtoi("-99999999999"));
            Console.WriteLine(solution.MyAtoi("+1"));
            Console.WriteLine(solution.MyAtoi("+-1"));
            Console.WriteLine(solution.MyAtoi("   +0 123"));
            Console.WriteLine(solution.MyAtoi("2147483648"));
            Console.WriteLine(solution.MyAtoi("+ 1"));
        }
    }

    public class Solution
    {
        public int MyAtoi(string str)
        {
            string num = "";
            char sign = '+';
            int i;
            int j;
            for (i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    continue;
                else
                    break;
            }
            if (i == str.Length)
                return 0;
            if (str[i] == '+' || str[i] == '-')
            {
                sign = str[i++];
            }
            for (j = i; j < str.Length; j++)
            {
                if (!char.IsDigit(str[j]))
                    break;
            }
            num = str.Substring(i, j - i);
            if (num.Length == 0)
                return 0;
            try
            {
                num = sign + num;
                return Convert.ToInt32(num);
            }
            catch (System.OverflowException)
            {
                return (sign == '-')? int.MinValue : int.MaxValue;
            }
        }
    }
}