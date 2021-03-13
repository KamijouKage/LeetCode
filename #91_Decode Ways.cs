using System;

namespace P91
{
    class Program
    {
        static void Main(string[] arags)
        {
        }
    }

    public class Solution
    {
        public int NumDecodings(string s)
        {
            if (s[0] == '0')
            {
                return 0;
            }
            int[] dp = new int[s.Length + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= s.Length; i++)
            {
                if (s[i - 1] != '0')
                {
                    dp[i] += dp[i - 1];
                }
                int combineCode = Convert.ToInt32(s.Substring(i - 2, 2));
                if (combineCode >= 10 && combineCode <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }
            return dp[s.Length];
        }
    }
}