using System;
using System.Collections.Generic;

// VideoLibrary class - manages collection of videos
public class VideoLibrary
{
    // Private members 
    private List<Video> _videos;

    // Constructor
    public VideoLibrary()
    {
        // Initialize members
        _videos = new List<Video>();
    }

    // AddVideo Metho - Adds a Video 
    public void AddVideo(Video video)
    {
        _videos.Add(video);
    }

    // DisplayAllVideos Method - Outputs all videos
    public void DisplayAllVideos()
    {
        // Iterates through Videos
        foreach (Video video in _videos)
        {
            // Outputs Video
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            video.DisplayVideoInfo();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
