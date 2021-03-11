using System;

namespace P75
{
    class Program
    {
        static void Main(string[] arags)
        {

        }
    }

    public class Solution
    {
        public void SortColors(int[] nums)
        {
            int[] colorsCounter = new int[3];
            int currentColorFirstIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                colorsCounter[nums[i]]++;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < colorsCounter[i]; j++)
                {
                    nums[currentColorFirstIndex + j] = i;
                }
                currentColorFirstIndex += colorsCounter[i];
            }
        }
    }
}