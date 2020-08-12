using System;
using System.Collections.Generic;

namespace P22
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            IList<string> result = solution.GenerateParenthesis(3);
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }

    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> result = new List<string>();
            Generate(ref result, "", n, n);
            return result;
        }

        private void Generate(ref IList<string> result, string current, int l, int r)
        {
            if (l == 0 && r == 0)
            {
                result.Add(current);
            }
            if (l > 0)
            {
                Generate(ref result, current + "(", l - 1, r);
            }
            if (r > l)
            {
                Generate(ref result, current + ")", l, r - 1);
            }
        }
    }
}