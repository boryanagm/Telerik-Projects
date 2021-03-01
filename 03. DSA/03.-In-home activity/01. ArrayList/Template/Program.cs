using System;

namespace DSA.Linear
{
    class Program
    {
        static void Main()
        {
            var list = new ArrayList<int>();

            list.Add(12); 
            list.Add(15);
            list.Add(17);
            list.Add(1);
            list.Add(10);
            list.Add(17);

            int maxValue = int.MinValue;
            //int maxIndex = -1;

            for (int i = 0; i < list.Count; i++) 
            {
                if (list[i] >= maxValue)
                {
                    maxValue = list[i];
                   // maxIndex = i;
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == maxValue)
                {
                    list.RemoveAt(i);
                }
            }

            list.Insert(0, maxValue);

            foreach (int element in list)
            {
                Console.Write($" {element} ");
            }
        }
    }
}