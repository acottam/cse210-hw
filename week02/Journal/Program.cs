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
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int userChoice = -1;

        while (userChoice != 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string userResponse = Console.ReadLine();
            userChoice = int.Parse(userResponse);

            if (userChoice == 1)
            {
                Entry entry = new Entry();
                entry.date = DateTime.Now.ToShortDateString();
                entry.promptText = promptGenerator.GetRandomPrompt();
                
                Console.WriteLine(entry.promptText);
                Console.Write("> ");
                entry.entryText = Console.ReadLine();
                
                Console.Write("How are you feeling today? (happy/sad/excited/calm/stressed): ");
                entry.mood = Console.ReadLine();
                
                entry.wordCount = entry.entryText.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                
                theJournal.AddEntry(entry);
                Console.WriteLine($"Entry saved! Word count: {entry.wordCount}");
            }
            else if (userChoice == 2)
            {
                theJournal.DisplayAll();
            }
            else if (userChoice == 3)
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
            }
            else if (userChoice == 4)
            {
                Console.Write("What is the filename? (use .csv for Excel format): ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
            }
        }
    }
}