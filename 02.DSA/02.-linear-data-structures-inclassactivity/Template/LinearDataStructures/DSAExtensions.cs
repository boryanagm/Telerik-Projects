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
        }
    }
}
