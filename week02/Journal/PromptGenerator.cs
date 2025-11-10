using System;
using System.Collections.Generic;

// Prompt Generator Class
public class PromptGenerator
{
    // Vars
    public List<string> _prompts;

    // Constructor
    public PromptGenerator()
    {
        // Initialize list of prompts
        _prompts = new List<string>
        {
            "What made me smile today?",
            "What challenge did I overcome today?",
            "What am I most grateful for right now?",
            "What did I learn about myself today?",
            "How did I help someone else today?",
            "What goal did I make progress on today?",
            "What surprised me most about today?",
            "What would I tell my younger self about today?",
            "What moment today will I remember in 10 years?",
            "How did I grow as a person today?"
        };
    }

    // Method to get a random prompt
    public string GetRandomPrompt()
    {
        // Generate random index
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        // Return prompt at random index
        return _prompts[index];
    }
}