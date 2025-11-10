/*
CREATIVITY AND EXCEEDING REQUIREMENTS:
This program exceeds core requirements by addressing common journaling problems:

1. MOOD TRACKING: Captures emotional state with each entry to help users identify patterns
2. WORD COUNT: Automatically counts words to encourage consistent writing habits
3. CSV EXPORT: Saves to Excel-compatible format with proper quote/comma escaping for data analysis
4. EMPTY JOURNAL HANDLING: Provides helpful feedback when no entries exist
5. ENHANCED DISPLAY: Shows entry count and mood/word statistics for better user experience

These features address real barriers to consistent journaling by making entries more meaningful
and providing data insights that motivate continued use.
*/

using System;

class Program
{
    // Main method
    static void Main(string[] args)
    {
        // Create Journal
        Journal theJournal = new Journal();
        
        // Create Prompt Generator
        PromptGenerator promptGenerator = new PromptGenerator();

        // Vars
        int userChoice = -1;

        // Menu Loop (5 to Quit)
        while (userChoice != 5)
        {
            // Menu Options
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            // Handle User Input
            string userResponse = Console.ReadLine();
            
            // Parse Input into Integer
            userChoice = int.Parse(userResponse);

            // 1. Write a new entry
            if (userChoice == 1)
            {
                // Create Entry
                Entry entry = new Entry();

                // Entry Date
                entry.date = DateTime.Now.ToShortDateString();
                
                // Entry Prompt (randomly generated from list of prompts)
                entry.promptText = promptGenerator.GetRandomPrompt();

                // Display Prompt
                Console.WriteLine(entry.promptText);
                Console.Write("> ");
                
                // Get User input for entry
                entry.entryText = Console.ReadLine();

                // Get User input for mood
                Console.Write("How are you feeling today? (happy/sad/excited/calm/stressed): ");
                entry.mood = Console.ReadLine();

                // Calculate Word Count
                entry.wordCount = entry.entryText.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

                // Add Entry to Journal
                theJournal.AddEntry(entry);

                // Confirm Entry Saved
                Console.WriteLine($"Entry saved! Word count: {entry.wordCount}");
            }
            // 2. Display all entries
            else if (userChoice == 2)
            {
                // Display all journal entries
                theJournal.DisplayAll();
            }
            // 3. Load journal from file
            else if (userChoice == 3)
            {
                // Prompt for filename
                Console.Write("Enter a filename (example: journal.csv)? ");

                // Read filename from user
                string filename = Console.ReadLine();
                
                // Load journal from file
                theJournal.LoadFromFile(filename);
            }
            // 4. Save journal to file
            else if (userChoice == 4)
            {
                // Prompt for filename
                Console.Write("What is the filename? (use .csv for Excel format): ");

                // Read filename from user
                string filename = Console.ReadLine();
                
                // Save journal to file
                theJournal.SaveToFile(filename);
            }
        }
    }
}