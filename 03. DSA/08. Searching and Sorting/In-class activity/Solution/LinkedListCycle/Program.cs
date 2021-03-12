using System;
using System.Collections.Generic;

namespace LinkedListCycle
{
	class Program
	{
		public static void Main()
		{
			ListNode head = InitializeList(withCycle: true);

			Console.WriteLine("Expected True; Actual: " + DetectCycleWithSet(head));
			Console.WriteLine("Expected True; Actual: " + DetectCycleFastAndSlow2(head));

			head = InitializeList(withCycle: false);

			Console.WriteLine("Expected False; Actual: " + DetectCycleWithSet(head));
			Console.WriteLine("Expected False; Actual: " + DetectCycleFastAndSlow2(head));
		}

		private static bool DetectCycleFastAndSlow(ListNode head)
		{
			ListNode slow = head;
			ListNode fast = head;

			while (fast != null && fast.Next != null)
			{

				slow = slow.Next;
				fast = fast.Next.Next;

				if (fast == slow)
				{
					return true;
				}
			}

			return false;
		}

		private static bool DetectCycleFastAndSlow2(ListNode head)
		{
			ListNode slowHead = head;

			while (head != null && head.Next != slowHead)
			{
				slowHead = slowHead.Next;
				head = head.Next.Next;
			}

			return head != null;
		}

		private static bool DetectCycleWithSet(ListNode head)
		{
			var set = new HashSet<ListNode>();

			while (head != null)
			{
				if (set.Contains(head))
				{
					return true;
				}

				set.Add(head);
				head = head.Next;
			}

			return false;
		}

		private static bool DetectCycleWithSet2(ListNode head)
		{
			var nodesSet = new HashSet<ListNode>();

			while (head != null && nodesSet.Add(head))
			{
				head = head.Next;
			}

			return head != null;
		}

		private static ListNode InitializeList(bool withCycle)
		{
			ListNode head = new ListNode(1);
			ListNode temp = head;

			for (int i = 2; i <= 10; i++)
			{
				temp.Next = new ListNode(i);
				temp = temp.Next;
			}

			if (withCycle)
			{
				temp.Next = head;
			}

			return head;
		}

		private static void PrintList(ListNode head)
		{
			while (head != null)
			{
				Console.WriteLine(head.Value);
				head = head.Next;
			}
		}
	}
}
