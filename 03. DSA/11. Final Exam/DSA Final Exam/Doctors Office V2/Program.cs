using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    public static int linkedListCount = 0;
    static void Main()
    {
        //  var nameAsKey = new Dictionary<string, LinkedListNode<string>>();
        //  var indexAsKey = new Dictionary<int, LinkedListNode<string>>();
        //  int index = 0;

        var linkedList = new LinkedList<string>();
        var namesCount = new Dictionary<string, int>();

        var input = string.Empty;

        var result = new StringBuilder();
        int lastVisitedIndex = 0;
        var lastVisitedNode = linkedList.First;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] command = input.Split(' ');

            switch (command[0])
            {
                case "Append":
                    string nameToAppend = command[1];

                    linkedList.AddLast(nameToAppend);
                    linkedListCount++;

                    AddToDictionary(namesCount, nameToAppend);

                    result.AppendLine("OK");
                    break;

                case "Insert":
                    int position = int.Parse(command[1]);

                    if (position > linkedListCount)
                    {
                        result.AppendLine("Error");
                        continue;
                    }

                    string nameToInsert = command[2];

                    var temp = linkedList.First;

                    if (position == 0)
                    {
                        linkedList.AddFirst(nameToInsert);
                        linkedListCount++;
                    }
                    else if (position == linkedListCount)
                    {
                        linkedList.AddLast(nameToInsert);
                        linkedListCount++;
                    }
                    else
                    {
                        if (position > lastVisitedIndex)
                        {
                            temp = lastVisitedNode;
                            for (int i = 0; i < lastVisitedIndex - position; i++)
                            {
                                temp = temp.Next;
                            }
                            linkedList.AddAfter(temp, nameToInsert);
                            linkedListCount++;
                            lastVisitedIndex = position;


                        }
                        else
                        {
                            for (int i = 1; i < position; i++)
                            {
                                temp = temp.Next;
                            }
                            linkedList.AddAfter(temp, nameToInsert);
                            linkedListCount++;

                   // lastVisitedIndex = position;

                        }


                        //linkedList.AddAfter(temp, nameToInsert);
                        //linkedListCount++;
                    }
                    lastVisitedNode = temp;

                    AddToDictionary(namesCount, nameToInsert);

                    result.AppendLine("OK");
                    break;

                case "Find":
                    string nameToFind = command[1];

                    if (!namesCount.ContainsKey(nameToFind))
                    {
                        result.AppendLine("0");
                        continue;
                    }
                    string nameCount = namesCount[nameToFind].ToString();

                    result.AppendLine(nameCount);
                    break;

                case "Examine":
                    int count = int.Parse(command[1]);

                    if (count > linkedListCount)
                    {
                        result.AppendLine("Error");
                        continue;
                    }

                    var sb = new StringBuilder();

                    for (int i = 0; i < count; i++)
                    {
                        sb.Append(linkedList.First.Value + " ");
                        namesCount[linkedList.First.Value]--;
                        linkedList.RemoveFirst();
                        linkedListCount--;
                    }

                    string sbToString = sb.ToString().Trim();

                    result.AppendLine(sbToString);
                    break;
            }
        }

        Console.WriteLine(result);
    }

    public static void AddToDictionary(Dictionary<string, int> namesCount, string name)
    {
        if (!namesCount.ContainsKey(name))
        {
            namesCount[name] = 0;
        }

        namesCount[name]++;
    }
}
