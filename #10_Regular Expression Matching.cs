using System;

namespace P10
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string[] a = new string[] {"aa", "aa", "ab", "aab", "mississippi", "aaa"};
            string[] b = new string[] {"a", "a*", ".*", "c*a*b", "mis*is*p*.", "ab*ac*a"};
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(solution.IsMatch(a[i], b[i]));   
            }
        }
    }

    public class Solution 
    {
        public bool IsMatch(string s, string p) 
        {
            bool[,] dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;
            for (int i = 2; i <= p.Length; i++)
            {
                dp[0, i] = p[i - 1] == '*' && dp[0, i - 2]; 
            }
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= p.Length; j++)
                {
                    if (p[j - 1] == '*')
                    {
                        dp[i, j] = dp[i, j - 2] || (dp[i - 1, j] && (p[j - 2] == s[i - 1] || p[j - 2] == '.'));
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j - 1] && (p[j - 1] == s[i - 1] || p[j - 1] == '.');
                    }
                }
            }
            return dp[s.Length, p.Length];    
        }
    }
}