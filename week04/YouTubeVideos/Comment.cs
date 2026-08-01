using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Cryptography.X509Certificates;

class Comment
{
    public string _nameOfCommentator;
    public string _textComment;
    public void DisplayComment()
    {
        Console.WriteLine($"{_nameOfCommentator}: {_textComment}");
    }
}