using System;

/// <summary>
/// Represents a single word that can be hidden or shown
/// </summary>
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    /// <summary>
    /// Hides the word
    /// </summary>
    public void Hide()
    {
        _isHidden = true;
    }

    /// <summary>
    /// Shows the word
    /// </summary>
    public void Show()
    {
        _isHidden = false;
    }

    /// <summary>
    /// Returns whether the word is currently hidden
    /// </summary>
    public bool IsHidden()
    {
        return _isHidden;
    }

    /// <summary>
    /// Returns the display text - either the word or underscores with punctuation preserved
    /// </summary>
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string result = "";
            foreach (char c in _text)
            {
                if (char.IsLetter(c))
                    result += "_";
                else
                    result += c; // Preserve punctuation
            }
            return result;
        }
        else
            return _text;
    }
}