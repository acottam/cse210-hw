/*
*************************************************************
******* Showing Creativity and Exceeding Requirements *******
*************************************************************
This program exceeds core requirements by implementing a scripture
memorization tool that allows users to progressively hide words from
scriptures loaded from a CSV file. Key features include:
1. Scripture Loading: Reads scriptures from a CSV file with proper
   handling of quoted text and commas.
2. Random Word Hiding: Hides a specified number of random words
   each time the user presses enter.
3. Complete Hiding Detection: Notifies the user when all words
   are hidden.
4. User Interaction: Allows users to choose to memorize another
   scripture or quit the program.
*************************************************************
*/
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Number of words to hide
    private static int _wordsToHide = 3;

    // Main method
    static void Main(string[] args)
    {

        // Load scriptures from CSV
        List<Scripture> scriptures = LoadScripturesFromCsv("ScriptureQuotes.csv");

        // Random generator
        Random random = new Random();

        // Main loop
        while (true)
        {
            // Select a random scripture from the list
            Scripture scripture = scriptures[random.Next(scriptures.Count)];

            // Memorization loop
            while (true)
            {

                // Clear console
                Console.Clear();

                // Display current scripture state
                Console.WriteLine(scripture.GetDisplayText());

                // Prompt User for action
                Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");

                // Get user input
                string input = Console.ReadLine();

                // Check for quit command (allows 'quit' or 'q' - uses "?" in case input is null)
                if (input?.ToLower() == "quit" || input?.ToLower() == "q")
                    // Exit program
                    return;

                // Hide random words
                scripture.HideRandomWords(_wordsToHide);

                // Check if all words are hidden (handle completion) 
                if (scripture.IsCompletelyHidden())
                {
                    // Clear console
                    Console.Clear();

                    // Display final scripture state
                    Console.WriteLine(scripture.GetDisplayText());

                    // Congratulate user
                    Console.WriteLine("\nGood job!");

                    // Break out to choose another scripture
                    break;
                }
            }

            // Ask user if they want to memorize another scripture
            Console.WriteLine("\nMemorize another scripture [Y/N]?");

            // Get user response
            string response = Console.ReadLine();

            // Check response to continue or quit (case insensitive for 'n', 'no', 'quit', 'q' - Uses "?" in case input is null)
            if (response?.ToLower() == "n" || response?.ToLower() == "no" || response?.ToLower() == "quit" || response?.ToLower() == "q")

                // Exit program
                break;
        }
    }

    // Loads scriptures from a CSV file
    static List<Scripture> LoadScripturesFromCsv(string filename)
    {

        // List to hold scriptures
        List<Scripture> scriptures = new List<Scripture>();

        // Read all lines from the CSV file
        string[] lines = File.ReadAllLines(filename);

        // Parse each line into a Scripture object (skipping header by starting at index 1)
        for (int i = 1; i < lines.Length; i++)
        {
            // Parse CSV line (handling quoted text with commas)
            string[] parts = ParseCsvLine(lines[i]);

            // Reference (example: "John",3,16,,"For God so loved the world...")
            string book = parts[0].Trim('"');

            /// Chapter and Verses
            int chapter = int.Parse(parts[1]);

            // Start Verse
            int startVerse = int.Parse(parts[2]);

            // End Verse (optional: may be empty when single verse)
            int? endVerse = string.IsNullOrEmpty(parts[3]) ? null : int.Parse(parts[3]);

            // Scripture Text (trim double quotes)
            string text = parts[4].Trim('"');

            // Create Reference and Scripture objects
            Reference reference = endVerse.HasValue ?
                // Range of verses
                new Reference(book, chapter, startVerse, endVerse.Value) :
                // Single verse
                new Reference(book, chapter, startVerse);

            // Add Scripture to list
            scriptures.Add(new Scripture(reference, text));
        }

        // Return loaded scriptures
        return scriptures;
    }

    // Parses a CSV line into fields, handling quoted text with commas
    static string[] ParseCsvLine(string line)
    {

        // List to hold parsed fields
        List<string> fields = new List<string>();

        // State variables
        bool inQuotes = false;

        // Current field being built
        string currentField = "";

        // Iterate through each character in the line
        for (int i = 0; i < line.Length; i++)
        {
            // Current character
            char c = line[i];

            // Handle quotes and commas
            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            // Comma outside quotes indicates new field
            else if (c == ',' && !inQuotes)
            {
                fields.Add(currentField);
                currentField = "";
            }
            // Use char
            else
            {
                currentField += c;
            }
        }

        // Add last field
        fields.Add(currentField);
        
        // Return as array
        return fields.ToArray();
    }
}