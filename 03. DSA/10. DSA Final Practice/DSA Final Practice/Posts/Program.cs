using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class User
{
    public HashSet<string> subscribedUsers = new HashSet<string>();
    public HashSet<string> subscriptions = new HashSet<string>();
    public HashSet<string> posts = new HashSet<string>();
    public User(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }
}

class Program
{
    // public static HashSet<string> allPosts = new HashSet<string>();

    public static Dictionary<string, HashSet<string>> allPosts = new Dictionary<string, HashSet<string>>();


    public static HashSet<User> usersSet = new HashSet<User>();

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var result = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' ');

            string command = input[0];
            string firstName = input[1];

            switch (command)
            {
                case "add":
                    var user = new User(firstName); // check first if user exists?
                    usersSet.Add(user);                  // need to override equals??

                    break;

                case "subscribe":
                    string secondName = input[2];

                    var firstUser = usersSet.First(x => x.Name == firstName);
                    firstUser.subscribedUsers.Add(secondName);

                    var secondUser = usersSet.First(x => x.Name == secondName);
                    secondUser.subscriptions.Add(firstName);

                    result.AppendLine($"{firstName} subscribed to {secondName}");
                    break;

                case "post":
                    string text = input[2];

                    var userToAssignPost = usersSet.First(x => x.Name == firstName);
                    userToAssignPost.posts.Add(text);
                    // allPosts.Add(text);
                    allPosts[firstName].Add(text); 

                    result.AppendLine($"{firstName} created post {allPosts.Count}: {text}");
                    break;

                case "listposts":
                    result.AppendLine(ListPosts(firstName));
                    break;
            }

        }
        Console.WriteLine(result.ToString());

    }
    public static string ListPosts(string userName)
    {
        var sb = new StringBuilder();

        var user = usersSet.First(x => x.Name == userName);

        sb.AppendLine($"{userName}: {user.subscribedUsers.Count} subscriptions");

        int counter = user.subscribedUsers.Count;

        if (user.subscribedUsers.Count > 10)
        {
            counter = 10;
        }

     //   var currentSet = allPosts.Where(x => x.Key == userName || x.Key == )

        for (int i = counter - 1; i >= 0; i--)
        {
            sb.AppendLine($"- Post {i}: {user.posts}");
        }

        return sb.ToString();
    }
}
