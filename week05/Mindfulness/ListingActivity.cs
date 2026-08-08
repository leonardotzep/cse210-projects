using System;
using System.Data;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;




class ListingActivity : MainActivity
{
    private int _count;
    List<string> _prompts = new List<string>();


    public ListingActivity(string name, string description)
        :base(name, description)
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }


    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses you can to the following prompt: ");
        Console.WriteLine($"--- {prompt} ---");

        DisplaySpinner(3);

        Console.WriteLine($"You may begin in:");
        ShowCountDown(5);

        GetListFromUser();
        DisplayEndingMessage();
    }


    public string GetRandomPrompt()
    {
        Random randprompt = new Random();
        int index = randprompt.Next(_prompts.Count);
        return _prompts[index];
    }


    public void GetListFromUser()
    {
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            responses.Add(input);
        }

        _count = responses.Count;
        Console.WriteLine($"You listed {_count} items!");
    }
}
