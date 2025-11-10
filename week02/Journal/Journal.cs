using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }
        
        Console.WriteLine($"Displaying {entries.Count} journal entries:\n");
        foreach (Entry entry in entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string file)
    {
        if (file.EndsWith(".csv"))
        {
            SaveToCsv(file);
        }
        else
        {
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                foreach (Entry entry in entries)
                {
                    outputFile.WriteLine($"{entry.date}~|~{entry.promptText}~|~{entry.entryText}~|~{entry.mood}~|~{entry.wordCount}");
                }
            }
        }
    }

    private void SaveToCsv(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine("Date,Mood,Word Count,Prompt,Entry");
            foreach (Entry entry in entries)
            {
                string escapedPrompt = "\"" + entry.promptText.Replace("\"", "\"\"") + "\"";
                string escapedEntry = "\"" + entry.entryText.Replace("\"", "\"\"") + "\"";
                outputFile.WriteLine($"{entry.date},{entry.mood},{entry.wordCount},{escapedPrompt},{escapedEntry}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            if (file.EndsWith(".csv") && line.StartsWith("Date,"))
                continue; // Skip CSV header
                
            string[] parts = line.Split("~|~");

            Entry entry = new Entry();
            entry.date = parts[0];
            entry.promptText = parts[1];
            entry.entryText = parts[2];
            entry.mood = parts.Length > 3 ? parts[3] : "Unknown";
            entry.wordCount = parts.Length > 4 ? int.Parse(parts[4]) : 0;

            entries.Add(entry);
        }
    }
}