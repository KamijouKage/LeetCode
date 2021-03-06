using System;
using System.Collections.Generic;

namespace P49
{
    class Program
    {
        static void Main(string[] arags)
        {
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            Solution solution = new Solution();
            IList<IList<string>> result = new List<IList<string>>();
            result = solution.GroupAnagrams(strs);
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }

    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] str = strs[i].ToCharArray();
                Array.Sort(str);
                string key = new string(str);
                if (map.ContainsKey(key))
                {
                    map[key].Add(strs[i]);
                }
                else
                {
                    map.Add(key, new List<string>() { strs[i] });
                }
            }
            foreach (var item in map.Values)
            {
                result.Add(item);
            }
            return result;
        }
    }
}