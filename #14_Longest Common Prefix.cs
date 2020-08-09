using System;

namespace P14
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string[] strs = new string[] { "asdfa", "asdf", "asdfflow", "asdfflight" };
            Console.Write(solution.LongestCommonPrefix(strs));
        }
    }

    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            int length = 0;
            if (strs.Length == 0)
            {
                return "";
            }
            if (strs.Length == 1)
            {
                return strs[0];
            }
            while (true)
            {
                try
                {
                    char thisChar = strs[0][length];
                    for (int i = 1; i < strs.Length; i++)
                    {
                        if (thisChar != strs[i][length])
                        {
                            return strs[0].Substring(0, length);
                        }
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    return strs[0].Substring(0, length);
                }
                length++;
            }
        }
    }
}