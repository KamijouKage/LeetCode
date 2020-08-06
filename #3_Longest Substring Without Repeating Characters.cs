using System;

namespace P3
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string input = "bbtablud";
            Console.Write(solution.LengthOfLongestSubstring(input));
        }
    }

    public class Solution 
    {
        public int LengthOfLongestSubstring(string input) 
        {
            int longestLength = 1;
            int windowStr = 0;
            if (input.Length == 0)
            {
                return 0;
            }
            for (int windowEnd = 0; windowEnd < input.Length - 1; windowEnd++)
            {
                int nowLength = windowEnd - windowStr + 1;
                string subString = input.Substring(windowStr, nowLength);
                if (subString.Contains(input[windowEnd + 1]))
                {
                    windowStr += subString.IndexOf(input[windowEnd + 1]) + 1;
                }
                else
                {
                    longestLength = Math.Max(longestLength, nowLength + 1);
                }
            }
            return longestLength;
        }
    }
}