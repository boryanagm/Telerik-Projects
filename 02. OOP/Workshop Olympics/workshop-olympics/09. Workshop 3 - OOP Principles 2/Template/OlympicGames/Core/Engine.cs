using System;

using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core
{
    public class Engine : IEngine
    {
        private const string Delimiter = "####################";
        private readonly ICommandParser parser;

        static Engine() 
        {
            Instance = new Engine();    
        }

        private Engine()
        {
            this.parser = new CommandParser();
        }

        public void Run()
        {
            while (true)
            {
                // Read -> Process -> Print -> Repeat
                string input = this.Read();
                string result = this.Process(input);
                this.Print(result);
            }
        }

        public static IEngine Instance { get; }

        private string Read()
        {
            return Console.ReadLine();
        }

        private string Process(string commandLine)
        {
            if (commandLine == "end")
                Environment.Exit(0);

            try
            {
                var command = this.parser.ParseCommand(commandLine);
                return $"{command.Execute()}{Environment.NewLine}{Delimiter}";
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }

                return $"ERROR: {e.Message}";
            }
        }

        private void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
