using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScripturesFromCsv("ScriptureQuotes.csv");
        Random random = new Random();
        
        while (true)
        {
            Scripture scripture = scriptures[random.Next(scriptures.Count)];
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");

                string input = Console.ReadLine();
                if (input?.ToLower() == "quit" || input?.ToLower() == "q")
                    return;

                scripture.HideRandomWords(3);
                
                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nGood job!");
                    break;
                }
            }
            
            Console.WriteLine("\nMemorize another scripture [Y/N]?");
            string response = Console.ReadLine();
            if (response?.ToLower() == "n" || response?.ToLower() == "no" || response?.ToLower() == "quit" || response?.ToLower() == "q")
                break;
        }
    }

    static List<Scripture> LoadScripturesFromCsv(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();
        string[] lines = File.ReadAllLines(filename);

        for (int i = 1; i < lines.Length; i++) // Skip header
        {
            string[] parts = ParseCsvLine(lines[i]);
            string book = parts[0].Trim('"');
            int chapter = int.Parse(parts[1]);
            int startVerse = int.Parse(parts[2]);
            int? endVerse = string.IsNullOrEmpty(parts[3]) ? null : int.Parse(parts[3]);
            string text = parts[4].Trim('"');

            Reference reference = endVerse.HasValue ?
                new Reference(book, chapter, startVerse, endVerse.Value) :
                new Reference(book, chapter, startVerse);

            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }

    static string[] ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        bool inQuotes = false;
        string currentField = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(currentField);
                currentField = "";
            }
            else
            {
                currentField += c;
            }
        }

        fields.Add(currentField);
        return fields.ToArray();
    }
}