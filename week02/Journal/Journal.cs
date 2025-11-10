using System;
using System.Collections.Generic;
using System.IO;

// Journal Class
public class Journal
{
    // Vars
    public List<Entry> _entries;

    // Constructor
    public Journal()
    {
        // Initialize entries list
        _entries = new List<Entry>();
    }

    // Add Entry Method
    public void AddEntry(Entry newEntry)
    {
        // Add entry to entries list
        _entries.Add(newEntry);
    }

    // Display All Entries Method
    public void DisplayAll()
    {
        // No entries found
        if (_entries.Count == 0)
        {
            // Message to user about no entries
            Console.WriteLine("No journal entries found.");

            // Exit method
            return;
        }

        // Display all entries
        Console.WriteLine($"Displaying {_entries.Count} journal entries:\n");

        // Iterate through entries and display each
        foreach (Entry entry in _entries)
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
                foreach (Entry entry in _entries)
                {
                    // Write entry data to file with delimiter
                    outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}~|~{entry._mood}~|~{entry._wordCount}");
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
            foreach (Entry entry in _entries)
            {
                // Escape commas in prompt and entry text
                string escapedPrompt = "\"" + entry._promptText.Replace("\"", "\"\"") + "\"";

                // Escape commas in entry text
                string escapedEntry = "\"" + entry._entryText.Replace("\"", "\"\"") + "\"";

                // Write entry data to CSV file
                outputFile.WriteLine($"{entry._date},{entry._mood},{entry._wordCount},{escapedPrompt},{escapedEntry}");
            }
        }
    }

    // Load from File Method
    public void LoadFromFile(string file)
    {
        LoadFromFile(file, false);
    }
    
    // Load from File Method with silent option
    public void LoadFromFile(string file, bool silent)
    {
        // Check if file exists
        if (!File.Exists(file))
        {
            if (!silent)
                Console.WriteLine($"File '{file}' not found.");
            return;
        }

        // Read all lines from file
        string[] lines = File.ReadAllLines(file);

        // Iterate through lines and create entries
        foreach (string line in lines)
        {
            // If file is CSV, skip header line
            if (file.EndsWith(".csv") && line.StartsWith("Date,"))
                continue; // Skip CSV header

            // Handle CSV format differently
            if (file.EndsWith(".csv"))
            {
                // Parse CSV line with quoted fields
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
                fields.Add(currentField); // Add last field
                
                if (fields.Count >= 5)
                {
                    // Create new Entry and populate fields for CSV
                    Entry entry = new Entry();
                    entry._date = fields[0];
                    entry._mood = fields[1];
                    entry._wordCount = int.Parse(fields[2]);
                    entry._promptText = fields[3];
                    entry._entryText = fields[4];
                    _entries.Add(entry);
                }
            }
            else
            {
                // Split line into parts using delimiter for text files
                string[] parts = line.Split("~|~");
                
                if (parts.Length >= 5)
                {
                    // Create new Entry and populate fields
                    Entry entry = new Entry();
                    
                    // Assign values from parts array to entry fields
                    entry._date = parts[0];
                    entry._promptText = parts[1];
                    entry._entryText = parts[2];
                    entry._mood = parts[3];
                    entry._wordCount = int.Parse(parts[4]);

                    // Add entry to entries list
                    _entries.Add(entry);
                }
            }
        }
        
        if (!silent)
            Console.WriteLine($"Loaded {_entries.Count} entries from {file}");
    }
}