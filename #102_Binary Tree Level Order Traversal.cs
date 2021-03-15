using System;
using System.Collections.Generic;

namespace P102
{
    class Program
    {
        static void Main()
        {
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Queue<TreeNode> quene = new Queue<TreeNode>();
            if (root == null)
            {
                return result;
            }
            quene.Enqueue(root);
            while (quene.Count > 0)
            {
                List<int> thisLevelElement = new List<int>();
                int queneCount = quene.Count;
                for (int i = 0; i < queneCount; i++)
                {
                    TreeNode node = quene.Dequeue();
                    thisLevelElement.Add(node.val);
                    if (node.left != null)
                    {
                        quene.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        quene.Enqueue(node.right);
                    }
                }
                result.Add(thisLevelElement);
            }
            return result;
        }
    }
}