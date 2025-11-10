using System;
using System.Collections.Generic;
using System.IO;

// Journal Class
public class Journal
{
    // Vars
    public List<Entry> entries;

    // Constructor
    public Journal()
    {
        // Initialize entries list
        entries = new List<Entry>();
    }

    // Add Entry Method
    public void AddEntry(Entry newEntry)
    {
        // Add entry to entries list
        entries.Add(newEntry);
    }

    // Display All Entries Method
    public void DisplayAll()
    {
        // No entries found
        if (entries.Count == 0)
        {
            // Message to user about no entries
            Console.WriteLine("No journal entries found.");

            // Exit method
            return;
        }

        // Display all entries
        Console.WriteLine($"Displaying {entries.Count} journal entries:\n");

        // Iterate through entries and display each
        foreach (Entry entry in entries)
        {
            // Display each entry
            entry.Display();

            // Blank line between entries
            Console.WriteLine();
        }
    }

    // Save to File Method
    public void SaveToFile(string file)
    {
        // Check file extension for CSV
        if (file.EndsWith(".csv"))
        {
            // Use CSV saving method
            SaveToCsv(file);
        }
        // Standard text file saving
        else
        {
            // Use StreamWriter to write to file
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                // Iterate through entries and write each to file
                foreach (Entry entry in entries)
                {
                    // Write entry data to file with delimiter
                    outputFile.WriteLine($"{entry.date}~|~{entry.promptText}~|~{entry.entryText}~|~{entry.mood}~|~{entry.wordCount}");
                }
            }
        }
    }

    // Save to CSV Method
    private void SaveToCsv(string file)
    {
        // Use StreamWriter to write to CSV file
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            // Write CSV header
            outputFile.WriteLine("Date,Mood,Word Count,Prompt,Entry");

            // Iterate through entries and write each to CSV file
            foreach (Entry entry in entries)
            {
                // Escape commas in prompt and entry text
                string escapedPrompt = "\"" + entry.promptText.Replace("\"", "\"\"") + "\"";

                // Escape commas in entry text
                string escapedEntry = "\"" + entry.entryText.Replace("\"", "\"\"") + "\"";

                // Write entry data to CSV file
                outputFile.WriteLine($"{entry.date},{entry.mood},{entry.wordCount},{escapedPrompt},{escapedEntry}");
            }
        }
    }

    // Load from File Method
    public void LoadFromFile(string file)
    {
        // Read all lines from file
        string[] lines = File.ReadAllLines(file);

        // Iterate through lines and create entries
        foreach (string line in lines)
        {
            // If file is CSV, skip header line
            if (file.EndsWith(".csv") && line.StartsWith("Date,"))
                continue; // Skip CSV header

            // Split line into parts using delimiter
            string[] parts = line.Split("~|~");

            // Create new Entry and populate fields
            Entry entry = new Entry();
            
            // Assign values from parts array to entry fields
            entry.date = parts[0];
            entry.promptText = parts[1];
            entry.entryText = parts[2];
            entry.mood = parts.Length > 3 ? parts[3] : "Unknown";
            entry.wordCount = parts.Length > 4 ? int.Parse(parts[4]) : 0;

            // Add entry to entries list
            entries.Add(entry);
        }
    }
}