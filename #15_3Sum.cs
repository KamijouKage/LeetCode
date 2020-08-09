using System;
using System.Collections.Generic;

namespace P15
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = new int[] { 0, 0, 0 };
            Console.Write(solution.ThreeSum(nums).ToString());
        }
    }

    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> sortedNums = new List<int>();
            sortedNums.AddRange(nums);
            sortedNums.Sort();
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = sortedNums.Count - 1; i >= 0; i--)
            {
                if (!map.ContainsKey(sortedNums[i]))
                {
                    map.Add(sortedNums[i], i);
                }
            }
            for (int i = 0; i < sortedNums.Count; i++)
            {
                if (sortedNums[i] > 0)
                {
                    break;
                }
                if (i > 0 && sortedNums[i] == sortedNums[i - 1])
                {
                    continue;
                }
                for (int j = i + 1; j < sortedNums.Count; j++)
                {
                    if (j > i + 1 && sortedNums[j] == sortedNums[j - 1])
                    {
                        continue;
                    }
                    int complement = -sortedNums[i] - sortedNums[j];
                    int complementIndex = map.ContainsKey(complement) ? map[complement] : -1;
                    if (complementIndex >= 0 && complementIndex > j)
                    {
                        result.Add(new List<int>() { sortedNums[i], sortedNums[j], complement });
                    }
                }
            }
            return result;
        }
    }
}