using System;
using System.Data;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

class ReflectionActivity : MainActivity
{
    private List<string> _prompts;
    private List<string> _questions;


    public ReflectionActivity(string name, string description)
        :base(name, description)
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }


    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();

        DisplayEndingMessage();
    }


    public string GetRandomPrompt()
    {
        Random randprompt = new Random();
        int index = randprompt.Next(_prompts.Count);
        return _prompts[index];
    }


    public string GetRandomQuestion()
    {
        Random randquestion = new Random();
        int index = randquestion.Next(_questions.Count);
        return _questions[index];
    }


    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();   
    }


    public void DisplayQuestions()
    {
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience. ");
        DisplaySpinner(3);

        Console.WriteLine("You may begin in:");
        ShowCountDown(5);


        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        List<string> shuffledQuestions = _questions.OrderBy(q => Guid.NewGuid()).ToList();
        
        int index = 0;
        while (DateTime.Now < endTime && index < shuffledQuestions.Count)
        {
            string question = shuffledQuestions[index];
            Console.WriteLine($"{question}");
            DisplaySpinner(5);
            index++;
        }       
    }
}
