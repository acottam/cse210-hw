using System;
using System.Collections.Generic;

// Videos class - manages videos and related information
public class Video
{
    // Private members 
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int length)
    {
        // Initialize members
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    // AddComment Method - Adds comment to a Video object
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // GetNumberOfComments Method - Returns count of comments for a Video object
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // DisplayVideoInfo Method - Returns formatted video information
    public void DisplayVideoInfo()
    {
        // Display Video Information
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        
        // Iterate through comments
        foreach (Comment comment in _comments)
        {
            // Output comment
            Console.WriteLine($"  - {comment.GetDisplayText()}");
        }
    }
}