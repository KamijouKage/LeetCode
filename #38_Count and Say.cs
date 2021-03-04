using System;
using System.Text;

namespace P38
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.CountAndSay(4));
        }
    }

    public class Solution
    {
        public string CountAndSay(int n)
        {
            string say = "1";
            for (int i = 1; i < n; i++)
            {
                StringBuilder newSay = new StringBuilder();
                char currentChar = say[0];
                int sameNumCounter = 0;
                for (int j = 0; j < say.Length; j++)
                {
                    if (currentChar == say[j])
                    {
                        sameNumCounter++;
                    }
                    else
                    {
                        newSay.Append(sameNumCounter.ToString());
                        newSay.Append(currentChar);
                        currentChar = say[j];
                        sameNumCounter = 1;
                    }
                }
                newSay.Append(sameNumCounter.ToString());
                newSay.Append(currentChar);
                say = newSay.ToString();
            }
            return say;
        }
    }
}