using System;
using System.Collections.Generic;
using System.Text;

using LinearDataStructures.Common;

namespace LinearDataStructures.Extensions
{
    public static class DSAExtensions
    {
        public static bool AreListsEqual<T>(SinglyLinkedList<T> list1, SinglyLinkedList<T> list2)
        {
            Node<T> a = list1.Head;
            Node<T> b = list2.Head;

            if (list1.GetCount(a) != list2.GetCount(b))
            {
                return false;
            }

            while (a != null && b != null)
            {
                if (!a.Value.Equals(b.Value))
                {
                    return false;
                }

                a = a.Next;
                b = b.Next;
            }

            return true;

            /*
            Telerik Solution:

            var a = list1.Head;
			var b = list2.Head;

			while (a != null && b != null)
			{
				if (!a.Value.Equals(b.Value))
				{
					return false;
				}

				a = a.Next;
				b = b.Next;
			}

			return (a == null) && (b == null);

             */
        }

        public static Node<T> FindMiddleNode<T>(SinglyLinkedList<T> list)
        {
            Node<T> a = list.Head;

            int count = list.GetCount(a);

            for (int i = 0; i < count / 2; i++)
            {
                a = a.Next;
            }

            return a;

            /*
             Telerik Solution:

            Node<T> slowPointer = list.Head; // Turtle
			Node<T> fastPointer = list.Head; // Rabbit

			while (fastPointer != null && fastPointer.Next != null)
			{
				slowPointer = slowPointer.Next;
				fastPointer = fastPointer.Next.Next;
			}

			return slowPointer;

             */
        }

        public static SinglyLinkedList<T> MergeLists<T>(SinglyLinkedList<T> list1, SinglyLinkedList<T> list2) where T : IComparable
        {
            Node<T> a = list1.Head;
            Node<T> b = list2.Head;

            if (a == null)
            {
                return list2;
            }
            if (b == null)
            {
                return list1;
            }

            SinglyLinkedList<T> result = new SinglyLinkedList<T>();

            while (a != null && b != null)
            {
                if (a.Value.CompareTo(b.Value) < 0)
                {
                    result.AddFirst(a.Value);
                    a = a.Next;
                }
                else
                {
                    result.AddFirst(b.Value);
                    b = b.Next;
                }
            }

            while (a != null)
            {
                result.AddFirst(a.Value);
                a = a.Next;
            }

            while (b != null)
            {
                result.AddFirst(b.Value);
                b = b.Next;
            }

            SinglyLinkedList<T> mergedList = ReverseList<T>(result);

            return mergedList;

            /*
             Telerik Solution:

            var mergedList = new SinglyLinkedList<T>(new T[] { default });

			var current = mergedList.Head;

			var h1 = list1.Head;
			var h2 = list2.Head;

			while (h1 != null && h2 != null)
			{
				if (h1.Value.CompareTo(h2.Value) == -1)
				{
					current.Next = new Node<T>(h1.Value);
					h1 = h1.Next;
				}
				else
				{
					current.Next = new Node<T>(h2.Value);
					h2 = h2.Next;
				}

				current = current.Next;
			}

			current.Next = h1 ?? h2;

			mergedList.RemoveFirst();
			return mergedList;

             */
        }

        public static SinglyLinkedList<T> ReverseList<T>(SinglyLinkedList<T> list)
        {
            SinglyLinkedList<T> reversedList = new SinglyLinkedList<T>();

            Node<T> a = list.Head;

            while (a != null)
            {
                reversedList.AddFirst(a.Value);
                a = a.Next;
            }

            return reversedList;

            // Telerik solution is the same.
        }

        public static bool AreValidParentheses(string expression)
        {
            char left = '(';
            char right = ')';

            string onlyBrackets = string.Empty;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == left || expression[i] == right)
                {
                    onlyBrackets += expression[i];
                }
            }

            if (onlyBrackets.StartsWith(")"))
            {
                return false;
            }

            if (onlyBrackets.Length % 2 != 0)
            {
                return false;
            }

            Stack<char> stackForCheck = new Stack<char>();

            foreach (char c in onlyBrackets)
            {
                if (stackForCheck.Count > 0 && stackForCheck.Peek() == '(' && c == ')')
                {
                    stackForCheck.Pop();
                }
                else
                {
                    stackForCheck.Push(c);
                }
            }

            if (stackForCheck.Count == 0)
            {
                return true;
            }

            return false;

            /*
             Telerik Solution:

            var tracker = new SinglyLinkedList<char>();

			foreach (char current in expression)
			{
				if (current == '(')
				{
					tracker.AddFirst(current);
				}
				else if (current == ')')
				{
					if (tracker.Head == null)
					{
						return false;
					}
					else
					{
						tracker.RemoveFirst();
					}
				}
			}

			return tracker.Head == null;

             */
        }

        public static string RemoveBackspaces(string sequence, char backspaceChar)
        {
            Stack<char> stackForCheck = new Stack<char>();

            foreach (char c in sequence)
            {
                if (stackForCheck.Count > 0 && c == backspaceChar)
                {
                    stackForCheck.Pop();
                }
                else if (stackForCheck.Count == 0 && c == backspaceChar)
                {
                    continue;
                }
                else
                {
                    stackForCheck.Push(c);
                }
            }

            Stack<char> reversed = new Stack<char>();

            while (stackForCheck.Count != 0 )
            {
                reversed.Push(stackForCheck.Pop());
            }

            return string.Join("", reversed);

            /*
             Telerik Solution:

            var stack = new SinglyLinkedList<char>();

			foreach (char ch in sequence)
			{
				if (ch == backspace && stack.Head != null)
				{
					stack.RemoveFirst();
				}
				else if (ch != backspace)
				{
					stack.AddFirst(ch);
				}
			}

			var sb = new StringBuilder();
			var current = stack.Head;
			while (current != null)
			{
				sb.Insert(0, current.Value);
				current = current.Next;
			}

			return sb.ToString();

             */
        }
    }
}
