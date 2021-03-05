using System;

namespace P44
{
    class Program
    {
        static void Main(string[] arags)
        {
            Solution solution = new Solution();
            string s = "aa";
            string p = "*";
            Console.WriteLine(solution.IsMatch(s, p));
        }
    }

    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            bool[,] dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;
            for (int i = 1; i <= p.Length; i++)
            {
                if (p[i - 1] == '*')
                {
                    dp[0, i] = true;
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= p.Length; j++)
                {
                    if (p[j - 1] == '*')
                    {
                        dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j - 1] && (s[i - 1] == p[j - 1] || p[j - 1] == '?');
                    }
                }
            }
            return dp[s.Length, p.Length];
        }
    }
}