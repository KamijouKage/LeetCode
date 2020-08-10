using System;
using System.Collections.Generic;

namespace P20
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string[] s = new string[] { "()", "()[]{}", "(]", "([)]", "{[]}" };
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(solution.IsValid(s[i]));
            }
        }
    }

    public class Solution
    {
        public bool IsValid(string s)
        {
            if (s.Length == 0)
            {
                return true;
            }
            Stack<char> stack = new Stack<char>();
            stack.Push(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                if (stack.Count > 0 && IsBracketsMatching(stack.Peek(), s[i]))
                {
                    stack.Pop();
                    continue;
                }
                stack.Push(s[i]);
            }
            return stack.Count == 0;
        }

        private bool IsBracketsMatching(char l, char r)
        {
            switch (l)
            {
                case '(':
                    return r == ')';
                case '{':
                    return r == '}';
                case '[':
                    return r == ']';
                default:
                    return false;
            }
        }
    }
}