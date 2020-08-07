using System;

namespace P2
{
    class Program
    {
        static void Main(string[] args)
        {
            // ListNode list1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            // ListNode list2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            ListNode list1 = new ListNode(5);
            ListNode list2 = new ListNode(5);
            Solution solution = new Solution();
            PrintListNode(solution.AddTwoNumbers(list1, list2));
        }

        static void PrintListNode(ListNode listNode)
        {
            ListNode it = listNode;
            while (it != null)
            {
                Console.Write(it.val + ", ");
                it = it.next;
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
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode();
            ListNode itCurrent = dummyHead;
            ListNode itL1 = l1;
            ListNode itL2 = l2;
            int sum = 0;
            while (itL1 != null || itL2 != null)
            {
                if (itL1 == null)
                {
                    sum += itL2.val;
                    itL2 = itL2.next;
                }
                else if (itL2 == null)
                {
                    sum += itL1.val;
                    itL1 = itL1.next;
                }
                else
                {
                    sum += (itL1.val + itL2.val);
                    itL1 = itL1.next;
                    itL2 = itL2.next;
                }
                itCurrent.next = new ListNode(sum % 10);
                itCurrent = itCurrent.next;
                sum = sum / 10;
            }
            if (sum >= 1)
            {
                itCurrent.next = new ListNode(sum);
            }
            return dummyHead.next;
        }
    }
}
