using System;

// Reference class - 
public class Reference
{
    // Private members
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructor
    public Reference(string book, int chapter, int verse)
    {
        // Initialize members
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    // Constructor 
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        // Initialize members
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // GetDisplayText method - 
    public string GetDisplayText()
    {
        // If verse is the end verse
        if (_verse == _endVerse)
            // Single Verse
            return $"{_book} {_chapter}:{_verse}";
        else
            // Multiple Verses 
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}