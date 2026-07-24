using System;
using System.IO;
using System.ComponentModel.DataAnnotations;

class Entry
{
    public string _date {get; set; }
    public string _prompt {get; set; }
    public string _response {get; set; }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}\n");
    }
}
