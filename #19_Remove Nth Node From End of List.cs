using System;

namespace P19
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            ListNode listNode = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            solution.RemoveNthFromEnd(listNode, 2);
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
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode preTarget = null;
            ListNode target = head;
            ListNode it = head;
            for (int i = 0; i < n - 1; i++)
            {
                it = it.next;
            }
            while (it.next != null)
            {
                it = it.next;
                preTarget = target;
                target = target.next;
            }
            if (preTarget == null)
            {
                return head.next;
            }
            preTarget.next = target.next;
            return head;
        }
    }
}