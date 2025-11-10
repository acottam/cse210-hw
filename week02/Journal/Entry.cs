using System;

// Entry Class
public class Entry
{
    // Vars
    public string date;
    public string promptText;
    public string entryText;
    public string mood;
    public int wordCount;

    // Display Method
    public void Display()
    {
        // Display entry details
        Console.WriteLine($"Date: {date} - Mood: {mood} - Words: {wordCount}");

        // Display prompt
        Console.WriteLine($"Prompt: {promptText}");
        
        // Display entry text
        Console.WriteLine(entryText);
    }
}