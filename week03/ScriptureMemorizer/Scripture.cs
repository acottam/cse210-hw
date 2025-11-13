using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a scripture with reference and text that can hide words for memorization
/// </summary>
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    /// <summary>
    /// Creates a new scripture with the given reference and text
    /// </summary>
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        // Split text into words, handling multiple spaces and empty entries
        string[] wordArray = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    /// <summary>
    /// Hides a specified number of random words that are currently visible
    /// </summary>
    public void HideRandomWords(int numberToHide)
    {
        if (numberToHide <= 0) return;
        
        Random random = new Random();
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        // Don't try to hide more words than are available
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);
        
        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
        }
    }

    /// <summary>
    /// Returns the complete scripture text with reference, showing hidden words as underscores
    /// </summary>
    public string GetDisplayText()
    {
        string reference = _reference.GetDisplayText();
        string words = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{reference} {words}";
    }

    /// <summary>
    /// Checks if all words in the scripture are hidden
    /// </summary>
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}