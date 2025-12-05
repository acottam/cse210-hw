using System;
using System.Collections.Generic;
using System.IO;

// GoalManager: Manages goals, score, and user interactions
public class GoalManager
{
    // Member Attributes
    private List<Goal> _goals;
    private int _score;
    private string _currentFile;

    // Constructor
    public GoalManager()
    {
        // Initialize attributes
        _goals = new List<Goal>();
        _score = 0;
        _currentFile = "goals.txt";
    }

    // Start Method: Main loop for user interaction
    public void Start()
    {
        // Auto-load from default file on startup
        AutoLoad();

        // Main loop
        while (true)
        {
            // Display menu
            Console.WriteLine($"\nYou have {_score} points.\n");

            // Menu Options
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. View Goal Statistics");
            Console.WriteLine("  7. Quit");

            // Get user choice
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            // Handle user choice
            switch (choice)
            {
                // 1. Create New Goal
                case "1":
                    CreateGoal();
                    AutoSave();
                    break;
                // 2. List Goals
                case "2":
                    ListGoals();
                    break;
                // 3. Save Goals
                case "3":
                    SaveGoals();
                    break;
                // 4. Load Goals
                case "4":
                    LoadGoals();
                    AutoSave();
                    break;
                // 5. Record Event
                case "5":
                    RecordEvent();
                    AutoSave();
                    break;
                // 6. View Goal Statistics
                case "6":
                    ViewStatistics();
                    break;
                // 7. Quit
                case "7":
                    return;
            }
        }
    }

    // CreateGoal Method: Handles creation of new goals
    private void CreateGoal()
    {
        // Display goal types
        Console.WriteLine("\nThe types of Goals are:");

        // List goal types
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal");

        // Get goal type from user
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        // Get game goal
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        // Get short description
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        // Get points associated with goal
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        // 1. Simple Goal
        if (type == "1")
        {
            // Add new SimpleGoal to goals list
            _goals.Add(new SimpleGoal(name, description, points));
        }
        // 2. Eternal Goal
        else if (type == "2")
        {
            // Add new EternalGoal to goals list
            _goals.Add(new EternalGoal(name, description, points));
        }
        // 3. Checklist Goal    
        else if (type == "3")
        {
            // Get How many times to accomplish
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            
            // Get bonus points (if accomplished that many times)
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            
            // Add new ChecklistGoal to goals list
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        // 4. Negative Goal
        else if (type == "4")
        {
            // Add new NegativeGoal to goals list
            _goals.Add(new NegativeGoal(name, description, points));
        }
    }

    // ListGoals Method: Displays all current goals
    private void ListGoals()
    {
        // Display current goals
        Console.WriteLine("\nThe goals are:");

        // List each goal with details
        for (int i = 0; i < _goals.Count; i++)
        {
            // Display goal details
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // RecordEvent Method: Records an event for a selected goal
    private void RecordEvent()
    {
        // List current goals
        ListGoals();

        // Get goal accomplished from user
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        // Record event and update score
        if (index >= 0 && index < _goals.Count)
        {
            // Points earned (with tracking)
            int pointsEarned = _goals[index].RecordEventWithTracking();

            // Update total score
            _score += pointsEarned;

            // Congratulations or negative message based on points
            if (pointsEarned < 0)
            {
                Console.WriteLine($"Shoot! You have lost {pointsEarned} points!");
            }
            else
            {
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            }
            Console.WriteLine($"You now have {_score} points.");
        }
    }

    // SaveGoals Method: Saves current goals and score to a file
    private void SaveGoals()
    {
        // Get filename from user (or use default)
        Console.Write("What is the filename for the goal file? (Press Enter for default: goals.txt) ");
        string filename = Console.ReadLine();
        
        // Use default if empty
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "goals.txt";
        }
        
        // Update current file
        _currentFile = filename;

        // Write score and goals to file
        using (StreamWriter writer = new StreamWriter(_currentFile))
        {
            // Write score
            writer.WriteLine(_score);
            
            // Write each goal
            foreach (Goal goal in _goals)
            {
                // Write goal string representation
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    // ViewStatistics Method: Displays statistics for all goals
    private void ViewStatistics()
    {
        // Display statistics header
        Console.WriteLine("\nGoal Statistics:");

        // Display statistics for each goal
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetStatistics());
        }
    }

    // AutoSave Method: Automatically saves goals to current file
    private void AutoSave()
    {
        // Write score and goals to current file
        using (StreamWriter writer = new StreamWriter(_currentFile))
        {
            // Write score
            writer.WriteLine(_score);
            
            // Write each goal
            foreach (Goal goal in _goals)
            {
                // Write goal string representation
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    // AutoLoad Method: Automatically loads goals from default file on startup
    private void AutoLoad()
    {
        // Check if default file exists
        if (File.Exists(_currentFile))
        {
            // Load from default file
            LoadFromFile(_currentFile);
        }
    }

    // LoadGoals Method: Loads goals and score from a file
    private void LoadGoals()
    {
        // Get filename from user (or use default)
        Console.Write("What is the filename for the goal file? (Press Enter for default: goals.txt) ");
        string filename = Console.ReadLine();
        
        // Use default if empty
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "goals.txt";
        }
        
        // Check if file exists
        if (File.Exists(filename))
        {
            // Update current file
            _currentFile = filename;
            
            // Load from file
            LoadFromFile(filename);
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    // LoadFromFile Method: Helper method to load goals from a specific file
    private void LoadFromFile(string filename)
    {
        // Read lines from file
        string[] lines = File.ReadAllLines(filename);

        // First line is score
        _score = int.Parse(lines[0]);

        // Clear current goals
        _goals.Clear();
        
        // Read each goal from file
        for (int i = 1; i < lines.Length; i++)
        {
            // Split line into type and data
            string[] parts = lines[i].Split(':');

            // Get goal
            string type = parts[0];
            
            // Get goal data
            string[] data = parts[1].Split(',');

            // SimpleGoal
            if (type == "SimpleGoal")
            {
                // Parse statistics
                List<string> dates = data.Length > 6 && !string.IsNullOrEmpty(data[6]) ? new List<string>(data[6].Split('|')) : new List<string>();
                int totalTimes = data.Length > 4 ? int.Parse(data[4]) : 0;
                int totalPoints = data.Length > 5 ? int.Parse(data[5]) : 0;
                
                // Add new SimpleGoal to goals list
                _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3]), totalTimes, totalPoints, dates));
            }
            // EternalGoal
            else if (type == "EternalGoal")
            {
                // Parse statistics
                List<string> dates = data.Length > 5 && !string.IsNullOrEmpty(data[5]) ? new List<string>(data[5].Split('|')) : new List<string>();
                int totalTimes = data.Length > 3 ? int.Parse(data[3]) : 0;
                int totalPoints = data.Length > 4 ? int.Parse(data[4]) : 0;
                
                // Add new EternalGoal to goals list
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2]), totalTimes, totalPoints, dates));
            }
            // ChecklistGoal
            else if (type == "ChecklistGoal")
            {
                // Parse statistics
                List<string> dates = data.Length > 8 && !string.IsNullOrEmpty(data[8]) ? new List<string>(data[8].Split('|')) : new List<string>();
                int totalTimes = data.Length > 6 ? int.Parse(data[6]) : 0;
                int totalPoints = data.Length > 7 ? int.Parse(data[7]) : 0;
                
                // Add new ChecklistGoal to goals list
                _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), totalTimes, totalPoints, dates));
            }
            // NegativeGoal
            else if (type == "NegativeGoal")
            {
                // Parse statistics
                List<string> dates = data.Length > 5 && !string.IsNullOrEmpty(data[5]) ? new List<string>(data[5].Split('|')) : new List<string>();
                int totalTimes = data.Length > 3 ? int.Parse(data[3]) : 0;
                int totalPoints = data.Length > 4 ? int.Parse(data[4]) : 0;
                
                // Add new NegativeGoal to goals list
                _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2]), totalTimes, totalPoints, dates));
            }
        }
    }
}
