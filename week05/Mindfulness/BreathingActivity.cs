using System;
using System.Data;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

class BreathingActivity : MainActivity
{
    public BreathingActivity(string name, string description)
        :base(name, description)
    {
    }


    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(4);

            Console.WriteLine("Now breathe out...");
            ShowCountDown(6);
        }

        DisplayEndingMessage();
    }
}
