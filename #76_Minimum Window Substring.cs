using System;
using System.Collections.Generic;

namespace P76
{
    class Program
    {
        static void Main(string[] arags)
        {
            Solution solution = new Solution();
            string s = "ADOBECODEBANC";
            string t = "ABC";
            Console.WriteLine(solution.MinWindow(s, t));
        }
    }

    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            int[] sCharFrequency = new int[128];
            int[] tCharFrequency = new int[128];
            int left = 0;
            int matchCount = 0;
            string minSubstring = "";
            for (int i = 0; i < t.Length; i++)
            {
                tCharFrequency[t[i]]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (tCharFrequency[s[i]] > 0)
                {
                    if (++sCharFrequency[s[i]] <= tCharFrequency[s[i]])
                    {
                        matchCount++;
                    }
                    if (matchCount == t.Length)
                    {
                        while (tCharFrequency[s[left]] == 0 || sCharFrequency[s[left]] > tCharFrequency[s[left]])
                        {
                            if (sCharFrequency[s[left]] > tCharFrequency[s[left]])
                            {
                                sCharFrequency[s[left]]--;
                            }
                            left++;
                        }
                        if (i - left + 1 < minSubstring.Length || minSubstring.Length == 0)
                        {
                            minSubstring = s.Substring(left, i - left + 1);
                        }
                    }
                }
            }
            return minSubstring;
        }
    }
}