using System;

namespace P5
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string input = "cbbd";
            Console.Write(solution.Manacher(input));
        }
    }

    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            bool[,] table = new bool[s.Length, s.Length];
            string result;
            if (s.Equals(""))
            {
                return "";
            }
            result = s.Substring(0, 1);
            for (int j = 0; j < s.Length; j++)
            {
                for (int i = 0; i <= j; i++)
                {
                    if (i == j)
                    {
                        table[i, j] = true;
                    }
                    else if (s[i] == s[j] && (table[i + 1, j - 1] || Math.Abs(i - j) == 1))
                    {
                        table[i, j] = true;
                        if (j - i + 1 > result.Length)
                        {
                            result = s.Substring(i, j - i + 1);
                        }
                    }
                }
            }
            return result;
        }

        public string Manacher(string s)
        {
            int sLength = s.Length;
            if (sLength < 2)
            {
                return s;
            }
            string markedString = "#";
            for (int i = 0; i < sLength; i++)
            {
                markedString += s[i] + "#";
            }
            int msl = markedString.Length;
            int[] radius = new int[msl];
            int center = 0;
            int right = 0;
            int mirrorLeft = 0;
            int maxRadius = 0;
            int maxIndex = 0;
            int iLeft;
            int iRight;
            for (int i = 1; (msl - i) * 2 > maxRadius; i++)
            {
                mirrorLeft = center * 2 - i;
                if (i < right && mirrorLeft - radius[mirrorLeft] > center - radius[center])
                {
                    radius[i] = radius[mirrorLeft];
                    continue;
                }
                iLeft = i - radius[i] - 1;
                iRight = i + radius[i] + 1;
                while (iLeft >= 0 && iRight < msl && markedString[iLeft] == markedString[iRight])
                {
                    radius[i]++;
                    iLeft--;
                    iRight++;
                }
                if (radius[i] > maxRadius)
                {
                    maxRadius = radius[i];
                    maxIndex = i;
                }
                if (i + radius[i] > right)
                {
                    center = i;
                    right = center + radius[center];
                }
            }
            return s.Substring((maxIndex - radius[maxIndex]) / 2, radius[maxIndex]);
        }
    }
}