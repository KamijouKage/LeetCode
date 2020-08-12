using System;

namespace P21
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            ListNode a = new ListNode(1, new ListNode(4, new ListNode(5)));
            ListNode b = new ListNode(0, new ListNode(2, new ListNode(3)));
            ListNode c = solution.MergeTwoLists(a, b);
            while (c != null)
            {
                Console.Write(c.val + ", ");
                c = c.next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode();
            ListNode it = result;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    moveBtoAThenNext(ref it, ref l1);
                    continue;
                }
                moveBtoAThenNext(ref it, ref l2);
            }
            while (l1 != null)
            {
                moveBtoAThenNext(ref it, ref l1);
            }
            while (l2 != null)
            {
                moveBtoAThenNext(ref it, ref l2);
            }
            return result.next;
        }

        private void moveBtoAThenNext(ref ListNode a, ref ListNode b)
        {
            a.next = new ListNode(b.val);
            a = a.next;
            b = b.next;
        }
    }
}