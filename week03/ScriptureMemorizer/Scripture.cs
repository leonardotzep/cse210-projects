using System;
using System.Runtime.InteropServices;

class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture (Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                    .Select(W => new Word(W))
                    .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string verseText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} / {verseText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public Reference Reference
    {
        get {return _reference;}
    }
}