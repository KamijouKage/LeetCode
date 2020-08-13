using System;

namespace P28
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            if (needle.Equals(""))
            {
                return 0;
            }
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack.Substring(i, needle.Length).Equals(needle))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}