using System;
using System.IO;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        QuestionGenerator generator = new QuestionGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Journal Program! ");
            Console.WriteLine("Please select one of the following options: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Search a word");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    string prompt = generator.GetRandomQuestion();
                    Console.WriteLine(prompt);
                    Console.Write("Write your response: ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry
                    {
                        _Date = DateTime.Now.ToString("MM/dd/yyyy"),
                        _Prompt = prompt,
                        _Response = response
                    };
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.Display();
                    break;

                case "3":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFile(loadFile);
                    break;

                case "4":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.ExportJournal(saveFile);
                    break;

                case "5":
                    Console.Write("Type the word to search: ");
                    string keyword = Console.ReadLine();
                    journal.Search(keyword);
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Have a nice day!");
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        

        }
    }
}