/*
*************************************************************
******* Showing Creativity and Exceeding Requirements *******
*************************************************************
This program exceeds core requirements by addressing common journaling problems:
1. Mood Tracking: Captures emotional state with each entry to help users identify patterns
2. Word Counter: Automatically counts words to encourage consistent writing habits
3. Save to CSV Format: Saves to Excel-compatible format with proper quote/comma escaping for data analysis
4. Empty Journal Handling: Provides helpful feedback when no entries exist
5. Enhanced Display: Shows entry count and mood/word statistics for better user experience
*************************************************************
*/
using System;

class Program
{
    // Program directory for file operations
    public static string ProgramDirectory = "/Users/acottam/Learning/Pathways/CSE210/cse210-hw/week02/Journal";
    
    // Main method
    static void Main(string[] args)
    {
        // Create Journal
        Journal theJournal = new Journal();

        // Auto-load existing journal if file exists (silent)
        string journalPath = System.IO.Path.Combine(ProgramDirectory, "Journals.csv");
        if (!System.IO.File.Exists(journalPath))
        {
            // Create empty Journals.csv if it doesn't exist
            theJournal.SaveToFile(journalPath);
        }
        theJournal.LoadFromFile(journalPath, true);

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
                entry._date = DateTime.Now.ToShortDateString();

                // Entry Prompt (randomly generated from list of prompts)
                entry._promptText = promptGenerator.GetRandomPrompt();

                // Display Prompt
                Console.WriteLine(entry._promptText);
                Console.Write("> ");

                // Get User input for entry
                entry._entryText = Console.ReadLine();

                // Get User input for mood
                Console.Write("How are you feeling today? (happy/sad/excited/calm/stressed): ");
                entry._mood = Console.ReadLine();

                // Calculate Word Count
                entry._wordCount = entry._entryText.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

                // Add Entry to Journal
                theJournal.AddEntry(entry);

                // Confirm Entry Saved
                Console.WriteLine($"Entry saved! Word count: {entry._wordCount}");
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
                Console.Write("Enter a filename (press Enter for Journals.csv): ");

                // Read filename from user
                string filename = Console.ReadLine();
                if (string.IsNullOrEmpty(filename))
                    filename = "Journals.csv";
                string fullPath = System.IO.Path.Combine(ProgramDirectory, filename);

                // Load journal from file
                theJournal.LoadFromFile(fullPath);
            }
            // 4. Save journal to file
            else if (userChoice == 4)
            {
                // Prompt for filename
                Console.Write("What is the filename? (press Enter for Journals.csv): ");

                // Read filename from user
                string filename = Console.ReadLine();
                if (string.IsNullOrEmpty(filename))
                    filename = "Journals.csv";
                string fullPath = System.IO.Path.Combine(ProgramDirectory, filename);

                // Save journal to file
                theJournal.SaveToFile(fullPath);
            }
        }
        
        // Auto-save all entries to Journals.csv on quit
        string defaultJournalPath = System.IO.Path.Combine(ProgramDirectory, "Journals.csv");
        theJournal.SaveToFile(defaultJournalPath);
    }
}