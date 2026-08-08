using System;
using System.Data;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

class MainActivity
{
    private string _name;
    private string _description;
    protected int _duration;

    public MainActivity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }


    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get ready...");
        DisplaySpinner(3);
    }


    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed {_duration} seconds of the {_name} Activity.");
        DisplaySpinner(3);
    }


    public void DisplaySpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] spinner = {"|", "/", "-", "\\"};

        int index = 0;

        while(DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);
            System.Threading.Thread.Sleep(200);
            Console.Write("\b \b");
            index = (index + 1) % spinner.Length;
        }
    }


    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + "  ");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
