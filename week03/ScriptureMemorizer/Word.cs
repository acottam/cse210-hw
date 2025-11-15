using System;

// Word class
public class Word
{
    // Private members
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        // Initialize members
        _text = text;
        _isHidden = false;
    }

    // Hide method - Hides the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Show Method - Shows the word
    public void Show()
    {
        _isHidden = false;
    }

    // IsHidden - Returns whether the word is currently hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // GetDisplayText - Returns text (including "_" where hidden)
    public string GetDisplayText()
    {
        // If Hidden
        if (_isHidden)
        {
            string result = "";

            // Iterate through and replace chars with "_"
            foreach (char c in _text)
            {
                // If it's a character
                if (char.IsLetter(c))
                    result += "_";
                // It's puctuation - Preserve
                else
                    result += c;
            }
            
            // Return result string
            return result;
        }
        // Not Hidden
        else
            // return entire string
            return _text;
    }
}