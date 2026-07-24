using System;
using System.IO;
using System.ComponentModel.DataAnnotations;

// I am adding a search option, so the user can search the info by
// typing either a date or a word ib the main program.


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
