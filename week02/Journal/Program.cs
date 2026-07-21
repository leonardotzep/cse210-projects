using System;
using System.IO;
using System.ComponentModel.DataAnnotations;

// I am adding a search option, so the user can search the info by
// typing either a date or a word.


class Journal
{
    private List<Entry> _journalEntries = new List<Entry>();
    
    public void AddEntry(Entry newEntry)
    {
        _journalEntries.Add(newEntry);
    }

    public void Display()
    {
        foreach (Entry entry in _journalEntries)
        {
            entry.Display();
        }
    }

    public void LoadFile(string filename)
    {
        _journalEntries.Clear();
        string [] lines = File.ReadAllLines(filename);
        foreach(string line in lines)
        {
            string[] parts = line.Split("|");
            Entry entry = new Entry
            {
                _Date = parts[0],
                _Prompt = parts[1],
                _Response = parts[2]
            };
            _journalEntries.Add(entry);
        }
    }

    public void ExportJournal(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach(Entry entry in _journalEntries)
            {
                outputFile.WriteLine($"{entry._Date}|{entry._Prompt}|{entry._Response}");
            }
        }
    }

    public void Search(string keyword)
    {
        bool found = false;
        foreach (Entry entry in _journalEntries)
        {
            if (entry._Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            entry._Response.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                entry.Display();
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("That word was not found.");
        }
    }
}





class Entry
{
    public string _Date {get; set; }
    public string _Prompt {get; set; }
    public string _Response {get; set; }

    public void Display()
    {
        Console.WriteLine($"Date: {_Date} - Prompt: {_Prompt}");
        Console.WriteLine($"Response: {_Response}\n");
    }
}


class QuestionGenerator
{
    private List<string> _questions = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
    };

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }
}


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