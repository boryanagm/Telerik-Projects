using System;

class Program
{
    static void Main()
    {
        LinkedList<int> testList = new LinkedList<int>();

        Console.WriteLine("Test AddFirst method:");

        testList.AddFirst(5);
        testList.AddFirst(4);
        testList.AddFirst(3);
        testList.AddFirst(2);

        Console.WriteLine($"List count: {testList.Count}");
        Console.WriteLine($"Head: {testList.Head.Value}");
        Console.WriteLine($"Tail: {testList.Tail.Value}");
        Console.WriteLine(string.Join(" ", testList));
        Console.WriteLine();

        LinkedListNode<int> testNode = new LinkedListNode<int>(5);

        Console.WriteLine("Test InsertAfter method:");

        testList.InsertAfter(testNode, 200);
        testList.InsertAfter(testNode, 300);
        testList.InsertAfter(testNode, 400);

        Console.WriteLine($"List count: {testList.Count}");
        Console.WriteLine($"Head: {testList.Head.Value}");
        Console.WriteLine($"Tail: {testList.Tail.Value}");
        Console.WriteLine(string.Join(" ", testList));
        Console.WriteLine();

        Console.WriteLine("Test InsertBefore method:");

        testList.InsertBefore(testNode, 555);
        testList.InsertBefore(testNode, 111);

        Console.WriteLine($"List count: {testList.Count}");
        Console.WriteLine($"Head: {testList.Head.Value}");
        Console.WriteLine($"Tail: {testList.Tail.Value}");
        Console.WriteLine(string.Join(" ", testList));
        Console.WriteLine();

        Console.WriteLine("Test AddLast method:");

        testList.AddLast(22);
        testList.AddLast(33);

        Console.WriteLine($"List count: {testList.Count}");
        Console.WriteLine($"Head: {testList.Head.Value}");
        Console.WriteLine($"Tail: {testList.Tail.Value}");
        Console.WriteLine(string.Join(" ", testList));
        Console.WriteLine();

        Console.WriteLine("Test RemoveFirst method:");

        testList.RemoveFirst();

        Console.WriteLine($"List count: {testList.Count}");
        Console.WriteLine($"Head: {testList.Head.Value}");
        Console.WriteLine($"Tail: {testList.Tail.Value}");
        Console.WriteLine(string.Join(" ", testList));
        Console.WriteLine();

        Console.WriteLine("Test RemoveLast method:");

        testList.RemoveLast();

        Console.WriteLine($"List count: {testList.Count}");
        Console.WriteLine($"Head: {testList.Head.Value}");
        Console.WriteLine($"Tail: {testList.Tail.Value}");
        Console.WriteLine(string.Join(" ", testList));
        Console.WriteLine();

        Console.WriteLine("Test Contains method:");

        if (testList.Contains(4))
        {
            testList.AddFirst(4);
        }

        Console.WriteLine($"List count: {testList.Count}");
        Console.WriteLine($"Head: {testList.Head.Value}");
        Console.WriteLine($"Tail: {testList.Tail.Value}");
        Console.WriteLine(string.Join(" ", testList));
        Console.WriteLine();

        Console.WriteLine("Test Find method:");

        var findNode2 = testList.Find(4);
        Console.WriteLine(findNode2.Value);
        Console.WriteLine();

        Console.WriteLine("Test Clear method:");

        Console.WriteLine("Clear list.");
        testList.Clear();
        Console.WriteLine($"List count: {testList.Count}");
    }
}
