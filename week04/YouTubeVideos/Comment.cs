using System;

// Comment class - Mananages comments and their display
public class Comment
{
    // Private members
    private string _name;
    private string _text;

    // Constructor
    public Comment(string name, string text)
    {
        // Initialize members
        _name = name;
        _text = text;
    }

    // GetDisplayText Method - Returns Comment name and text
    public string GetDisplayText()
    {
        return $"{_name}: {_text}";
    }
}