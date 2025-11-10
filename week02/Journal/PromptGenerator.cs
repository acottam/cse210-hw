using System;
using System.Collections.Generic;

// Prompt Generator Class
public class PromptGenerator
{
    // Vars
    public List<string> prompts;

    // Constructor
    public PromptGenerator()
    {
        // Initialize list of prompts
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    // Method to get a random prompt
    public string GetRandomPrompt()
    {
        // Generate random index
        Random random = new Random();
        int index = random.Next(prompts.Count);

        // Return prompt at random index
        return prompts[index];
    }
}