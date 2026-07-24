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
                _date = parts[0],
                _prompt = parts[1],
                _response = parts[2]
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
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }
    }

    public void Search(string keyword)
    {
        bool found = false;
        foreach (Entry entry in _journalEntries)
        {
            if (entry._prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            entry._response.Contains(keyword, StringComparison.OrdinalIgnoreCase))
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
