using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        List <Video> videos = new List<Video>();

        Video video1 = new Video();
        video1._title = "Reading book of 1Nephi";
        video1._author = "User1";
        video1._lengthInSeconds = 400;        
        video1.comments.Add(new Comment {_nameOfCommentator = "Anna", _textComment = "It has a great teaching."});
        video1.comments.Add(new Comment {_nameOfCommentator = "Luis", _textComment = "I liked this video and it helped me a lot."});
        video1.comments.Add(new Comment {_nameOfCommentator = "Diego", _textComment = "Very good video."});
        videos.Add(video1);

        Video video2 = new Video();
        video2._title = "Restoration video";
        video2._author = "User2";
        video2._lengthInSeconds = 350;
        video2.comments.Add(new Comment {_nameOfCommentator = "Carlos", _textComment = "I love it and I watch it every day."});
        video2.comments.Add(new Comment {_nameOfCommentator = "Mr. Martinez", _textComment = "I shared it with my neighbors and they liked it."});
        video2.comments.Add(new Comment {_nameOfCommentator = "Emma", _textComment = "My kids love this video."});
        videos.Add(video2);

        Video video3 = new Video();
        video3._title = "Cooking Sandwiches";
        video3._author = "User3";
        video3._lengthInSeconds = 270;
        video3.comments.Add(new Comment {_nameOfCommentator = "Rose", _textComment = "What a good tutorial! I will save this video."});
        video3.comments.Add(new Comment {_nameOfCommentator = "Martin", _textComment = "It looks so delicious!"});
        video3.comments.Add(new Comment {_nameOfCommentator = "Jose", _textComment = "I will cook this with my family this week."});
        videos.Add(video3);

        foreach (Video v in videos)
        {
            Console.WriteLine($"Title: {v._title}");
            Console.WriteLine($"Author: {v._author}");
            Console.WriteLine($"Duration: {v._lengthInSeconds}");
            Console.WriteLine($"Quantity of comments: {v.GetNumberOfComments()}");

            foreach (Comment c in v.comments)
            {
                c.DisplayComment();
            }
            Console.WriteLine("----------------------");
        }
    }
}
