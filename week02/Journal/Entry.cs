using System;

public class Entry
{
    public string date;
    public string promptText;
    public string entryText;
    public string mood;
    public int wordCount;

    public void Display()
    {
        Console.WriteLine($"Date: {date} - Mood: {mood} - Words: {wordCount}");
        Console.WriteLine($"Prompt: {promptText}");
        Console.WriteLine(entryText);
    }
}