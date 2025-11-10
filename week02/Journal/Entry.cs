using System;

// Entry Class
public class Entry
{
    // Vars
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;
    public int _wordCount;

    // Display Method
    public void Display()
    {
        // Display entry details
        Console.WriteLine($"Date: {_date} - Mood: {_mood} - Words: {_wordCount}");

        // Display prompt
        Console.WriteLine($"Prompt: {_promptText}");
        
        // Display entry text
        Console.WriteLine(_entryText);
    }
}