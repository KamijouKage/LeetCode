using System;
using System.Collections.Generic;

namespace P13
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "MCMXCIV";
            Console.Write(solution.RomanToInt(s));
        }
    }

    public class Solution
    {
        static private Dictionary<char, int> _table = new Dictionary<char, int>()
        {
            { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 }
        };

        public int RomanToInt(string s)
        {
            int result = 0;
            int sameCharStr = 0;
            int i;
            for (i = 0; i < s.Length - 1; i++)
            {
                if (s[i] != s[i + 1])
                {
                    result += _table[s[i]] * (i - sameCharStr + 1);
                    if (_table[s[i]] < _table[s[i + 1]])
                    {
                        result -= _table[s[i]] * 2;
                    }
                    sameCharStr = i + 1;
                }
            }
            return result + _table[s[i]] * (i + 1 - sameCharStr);
        }
    }
}