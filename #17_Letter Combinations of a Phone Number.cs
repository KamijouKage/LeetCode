using System;
using System.Collections.Generic;

namespace P17
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string digits = "23";
            IList<string> result = solution.LetterCombinations(digits);
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i] + ", ");
            }
        }
    }

    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0)
            {
                return new List<string>();
            }
            Dictionary<char, string> map = new Dictionary<char, string>()
            {
                { '2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl" }, { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" }
            };
            List<string> result = new List<string>();
            string mapValue = map[digits[0]];
            for (int i = 0; i < mapValue.Length; i++)
            {
                result.Add(char.ToString(mapValue[i]));
            }
            for (int i = 1; i < digits.Length; i++)
            {
                mapValue = map[digits[i]];
                int thisResultCount = result.Count;
                for (int j = 0; j < thisResultCount; j++)
                {
                    string temp = result[0];
                    result.RemoveAt(0);
                    for (int k = 0; k < mapValue.Length; k++)
                    {
                        result.Add(temp + mapValue[k]);
                    }
                }
            }
            return result;
        }
    }
}