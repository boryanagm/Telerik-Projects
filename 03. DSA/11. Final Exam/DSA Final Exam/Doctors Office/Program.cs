using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    public static int linkedListCount = 0;
    static void Main()
    {
        //   var nameAsKey = new Dictionary<string, LinkedListNode<string>>();
        // var indexAsKey = new Dictionary<int, LinkedListNode<string>>();
        //   int index = 0;

        var linkedList = new LinkedList<string>();
        var namesCount = new Dictionary<string, int>();
        var allPatients = new List<string>();

        var input = string.Empty;

        var result = new StringBuilder();

        while ((input = Console.ReadLine()) != "End")
        {
            string[] command = input.Split(' ');

            switch (command[0])
            {
                case "Append":
                    string nameToAppend = command[1];

                    //    nameAsKey.Add(nameToAppend, linkedList.AddLast(nameToAppend));
                    //  indexAsKey.Add(index, linkedList.AddLast(nameToAppend));
                    //  index++;
                    //   linkedList.AddLast(nameToAppend);
                    //  linkedListCount++;
                    allPatients.Add(nameToAppend);

                    AddToDictionary(namesCount, nameToAppend);

                    result.AppendLine("OK");
                    break;

                case "Insert":
                    int position = int.Parse(command[1]);

                    if (position > allPatients.Count) // position > linkedListCount + 1
                    {
                        result.AppendLine("Error");
                        continue;
                    }
                    string nameToInsert = command[2];

                    allPatients.Insert(position, nameToInsert);
                    //if (position == 0)
                    //{
                    //    //  linkedList.AddFirst(nameToInsert);
                    //    // linkedListCount++;
                    //    allPatients.Insert(0, nameToInsert);
                    //}
                    //else if (position >= allPatients.Count)
                    //{
                    //    linkedList.AddLast(nameToInsert);
                    //    linkedListCount++;
                    //}



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

                    if (count > allPatients.Count)
                    {
                        result.AppendLine("Error");
                        continue;
                    }
                    //if (count > linkedListCount)
                    //{
                    //    result.AppendLine("Error");
                    //    continue;
                    //}

                    var sb = new StringBuilder();
                    int deletedCount = 0;
                    for (int i = 0; i < count; i++)
                    {
                        if (deletedCount == count)
                        {
                            break;
                        }
                        sb.Append(allPatients[i] + " ");
                        namesCount[allPatients[i]]--;
                        allPatients.RemoveAt(i);
                        i--;
                        deletedCount++;
                    }
                    //for (int i = 0; i < count; i++)
                    //{
                    //    sb.Append(linkedList.First.Value + " ");
                    //    namesCount[linkedList.First.Value]--;
                    //    linkedList.RemoveFirst();
                    //    linkedListCount--;
                    //}

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
