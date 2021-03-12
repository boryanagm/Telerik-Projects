using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerRanking
{
    public class Player
    {
        public Player(string name, string type, int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return this.Name + "(" + this.Age + ")";
        }
    }
    public class PlayComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            int result = x.Name.CompareTo(y.Name);
            if (result == 0) result = -1 * (x.Age.CompareTo(y.Age));
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            var allPlayers = new List<Player>();
            var playersByType = new Dictionary<string, SortedSet<Player>>();
            var input = "";
            var Sorted = new List<int>();
            var playerCount = 0;
            while (input != "end")
            {
                input = Console.ReadLine();
                var com = input.Split();
                var comp = new PlayComparer();
                if (com[0] == "add")
                {
                    var player = new Player(com[1], com[2], int.Parse(com[3]));
                    sb.AppendLine($"Added pokemon {player.Name} to position {com[4]}");
                    Sorted.Insert(int.Parse(com[4]) - 1, playerCount);
                    allPlayers.Add(player);
                    playerCount++;
                    if (playersByType.ContainsKey(player.Type))
                    {
                        if (playersByType[player.Type].Count > 4)
                        {
                            if (comp.Compare(player, playersByType[player.Type].Max) < 0)
                            {
                                playersByType[player.Type].Remove(playersByType[player.Type].Max);
                                playersByType[player.Type].Add(player);
                            }
                        }
                        else playersByType[player.Type].Add(player);
                    }
                    else playersByType.Add(player.Type, new SortedSet<Player>(comp) { player });
                }
                else if (com[0] == "find")
                {
                    var type = com[1];
                    sb.Append($"Type {type}: ");
                    if (playersByType.ContainsKey(type))
                    {
                        foreach (var item in playersByType[type])
                            sb.Append(item.ToString() + "; ");
                        sb.Remove(sb.Length - 2, 2);
                    }
                    sb.AppendLine();
                }
                else if (com[0] == "ranklist")
                {
                    var start = int.Parse(com[1]);
                    var end = int.Parse(com[2]);
                    for (int i = start - 1; i < end; i++)
                    {
                        sb.Append($"{i + 1}. {allPlayers[Sorted[i]].ToString()}; ");
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.AppendLine();
                }
            }
            Console.Write(sb.ToString());
        }
    }
}
