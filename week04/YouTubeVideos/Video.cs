using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Cryptography.X509Certificates;

class Video
{
    public string _title;
    public string _author;
    public int _lengthInSeconds;

    public List<Comment> comments = new List<Comment>();

    public int GetNumberOfComments()
    {
        return comments.Count;
    }
}
