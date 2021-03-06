using System;
using System.Collections.Generic;

namespace P46
{
    class Program
    {
        static void Main(string[] arags)
        {
            Solution solution = new Solution();
            int[] nums = new int[] { 1, 2, 3 };
            IList<IList<int>> result = solution.Permute(nums);
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }

    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> restElement = new List<int>();
            restElement.AddRange(nums);
            Generate(restElement, new List<int>(), result);
            return result;
        }

        private void Generate(List<int> restElement, List<int> current, IList<IList<int>> result)
        {
            for (int i = 0; i < restElement.Count; i++)
            {
                List<int> nextRestElement = new List<int>();
                nextRestElement.AddRange(restElement);
                nextRestElement.RemoveAt(i);
                List<int> next = new List<int>();
                next.AddRange(current);
                next.Add(restElement[i]);
                Generate(nextRestElement, next, result);
            }
            if (restElement.Count == 0)
            {
                result.Add(current);
            }
        }
    }
}