using System;
using System.IO;
using System.ComponentModel.DataAnnotations;

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
