using System;
using System.Data;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

class StretchingActivity : MainActivity
{
    public StretchingActivity(string name, string description)
        :base(name, description)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Stretch your arms up...");
            ShowCountDown(5);

            Console.WriteLine("Now stretch to the sides...");
            ShowCountDown(5);

            Console.WriteLine("Finally, stretch forward...");
            ShowCountDown(5);
        }

        DisplayEndingMessage();
    }
}
