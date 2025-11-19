using System;
using System.Collections.Generic;

class Program
{
    // Main method
    static void Main(string[] args)
    {
        
        // Create Videos List
        List<Video> videos = new List<Video>();

        // Create Video #1
        Video video1 = new Video("How to Code in C#", "TechGuru123", 600);
        
        // Add Comments to Video #1
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Could you do more advanced topics?"));
        
        // Add Video #1 to List
        videos.Add(video1);


        // Create Video #2 
        Video video2 = new Video("Cooking Pasta 101", "ChefMaster", 480);
        
        // Add Comments to Video #2
        video2.AddComment(new Comment("Diana", "Looks delicious!"));
        video2.AddComment(new Comment("Eve", "I tried this recipe and it was amazing"));
        video2.AddComment(new Comment("Frank", "What type of pasta works best?"));
        video2.AddComment(new Comment("Grace", "My family loved this!"));
        
        // Add Video #2 to List
        videos.Add(video2);


        // Create Video #3 
        Video video3 = new Video("Guitar Lessons for Beginners", "MusicTeacher", 720);
        
        // Add Comments to Video #3
        video3.AddComment(new Comment("Henry", "Finally learning to play!"));
        video3.AddComment(new Comment("Ivy", "Clear instructions, thank you"));
        video3.AddComment(new Comment("Jack", "Can you show how to tune the guitar?"));
        
        // Add Video #3 to List
        videos.Add(video3);


        // Iterate through Videos
        foreach (Video video in videos)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

            // Display Video Information
            video.DisplayVideoInfo();

            // Empty Line
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}