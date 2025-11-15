using System;
using System.Collections.Generic;
using System.Linq;

// Scripture class - manages a scripture reference and its words
public class Scripture
{
    // Private members
    private Reference _reference;
    private List<Word> _words;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        
        // Initialize members
        _reference = reference;
        _words = new List<Word>();

        // Split text into words, handling multiple spaces and empty entries
        string[] wordArray = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Create Word objects for each word and add to list
        foreach (string word in wordArray)
        {
            // Add new Word object to list
            _words.Add(new Word(word));
        }
    }

    // HideRandomWorsds method - hides a specified number of random words
    public void HideRandomWords(int numberToHide)
    {
        // If number to hide is less than or equal to zero, do nothing
        if (numberToHide <= 0) return;

        // Randomly hide words
        Random random = new Random();
        
        // Get list of currently visible words
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        // Don't try to hide more words than are available
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);
        
        // Hide random words
        for (int i = 0; i < wordsToHide; i++)
        {
            // Random index
            int randomIndex = random.Next(visibleWords.Count);

            // Hide the word at that index
            visibleWords[randomIndex].Hide();
            
            // Remove from visible list to avoid hiding the same word again
            visibleWords.RemoveAt(randomIndex);
        }
    }

    // GetDisplayText method - returns the scripture text with hidden words represented
    public string GetDisplayText()
    {
        // Get reference text
        string reference = _reference.GetDisplayText();

        // Get words display text 
        string words = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        
        // Return combined text
        return $"{reference} {words}";
    }

    // IsCompletelyHidden method - checks if all words are hidden
    public bool IsCompletelyHidden()
    {
        // Return true if all words are hidden
        return _words.All(w => w.IsHidden());
    }
}