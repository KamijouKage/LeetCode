using System;
using System.Collections.Generic;

namespace P84
{
    class Program
    {
        static void Main(string[] arags)
        {
            Solution solution = new Solution();
            int[] heights = new int[] { 2, 2, 2 };
            Console.WriteLine(solution.LargestRectangleArea(heights));
        }
    }

    public class Solution
    {
        public int LargestRectangleArea(int[] heights)
        {
            int maxArea = 0;
            Stack<int> indexStack = new Stack<int>();
            int heightsLength = heights.Length;
            for (int i = 0; i <= heightsLength; i++)
            {
                int currentHeight = i < heights.Length ? heights[i] : 0;
                if (indexStack.Count == 0 || currentHeight >= heights[indexStack.Peek()])
                {
                    indexStack.Push(i);
                }
                else
                {
                    int topIndex = indexStack.Pop();
                    int width = i;
                    if (indexStack.Count > 0)
                    {
                        if (heights[topIndex] == heights[indexStack.Peek()])
                        {
                            i--;
                            continue;
                        }
                        width = i - indexStack.Peek() - 1;
                    }
                    maxArea = Math.Max(maxArea, heights[topIndex] * width);
                    i--;
                }
            }
            return maxArea;
        }
    }
}