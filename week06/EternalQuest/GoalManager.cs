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
    private string _projectRoot;

    // Constructor
    public GoalManager()
    {
        // Initialize attributes
        _goals = new List<Goal>();
        _score = 0;
        
        // Get project root directory (where Program.cs is located)
        _projectRoot = Directory.GetCurrentDirectory();
        while (!File.Exists(Path.Combine(_projectRoot, "Program.cs")) && Directory.GetParent(_projectRoot) != null)
        {
            _projectRoot = Directory.GetParent(_projectRoot).FullName;
        }
        
        // Set default file path in project root
        _currentFile = Path.Combine(_projectRoot, "goals.txt");
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
                    AutoSave();
                    return;
            }
        }
    }

    // CreateGoal Method: Handles creation of new goals
    private void CreateGoal()
    {
        // Clear screen
        Console.Clear();

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

        // Pause to let user read
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }

    // RecordEvent Method: Records an event for a selected goal
    private void RecordEvent()
    {
        // Clear screen
        Console.Clear();

        // Display current goals
        Console.WriteLine("\nThe goals are:");

        // List each goal with details
        for (int i = 0; i < _goals.Count; i++)
        {
            // Display goal details
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

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

            // Clear screen before showing result
            Console.Clear();

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
            
            // Pause to let user read
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    // SaveGoals Method: Saves current goals and score to a file
    private void SaveGoals()
    {
        // Clear screen
        Console.Clear();

        // Get filename from user (or use default)
        Console.Write("What is the filename for the goal file? (Press Enter for default: goals.txt) ");
        string filename = Console.ReadLine();
        
        // Use default if empty
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = Path.Combine(_projectRoot, "goals.txt");
        }
        else if (!Path.IsPathRooted(filename))
        {
            // If relative path, use project root
            filename = Path.Combine(_projectRoot, filename);
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
        // Clear screen
        Console.Clear();

        // Display statistics header
        Console.WriteLine("\nGoal Statistics:");

        // Display statistics for each goal
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetStatistics());
        }

        // Pause to let user read
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
        Console.Clear();
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
        // Clear screen
        Console.Clear();

        // Get filename from user (or use default)
        Console.Write("What is the filename for the goal file? (Press Enter for default: goals.txt) ");
        string filename = Console.ReadLine();
        
        // Use default if empty
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = Path.Combine(_projectRoot, "goals.txt");
        }
        else if (!Path.IsPathRooted(filename))
        {
            // If relative path, use project root
            filename = Path.Combine(_projectRoot, filename);
        }
        
        // Check if file exists
        if (File.Exists(filename))
        {
            // Load from file
            LoadFromFile(filename);
            
            // Set current file to default goals.txt
            _currentFile = Path.Combine(_projectRoot, "goals.txt");
            
            // Auto-save to goals.txt
            AutoSave();
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
            // Split line into type and data (using pipe delimiter)
            string[] parts = lines[i].Split('|');

            // Get goal type
            string type = parts[0];

            // SimpleGoal
            if (type == "SimpleGoal")
            {
                // Parse statistics
                List<string> dates = parts.Length > 7 && !string.IsNullOrEmpty(parts[7]) ? new List<string>(parts[7].Split(':')) : new List<string>();
                int totalTimes = parts.Length > 5 ? int.Parse(parts[5]) : 0;
                int totalPoints = parts.Length > 6 ? int.Parse(parts[6]) : 0;
                
                // Add new SimpleGoal to goals list
                _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]), totalTimes, totalPoints, dates));
            }
            // EternalGoal
            else if (type == "EternalGoal")
            {
                // Parse statistics
                List<string> dates = parts.Length > 6 && !string.IsNullOrEmpty(parts[6]) ? new List<string>(parts[6].Split(':')) : new List<string>();
                int totalTimes = parts.Length > 4 ? int.Parse(parts[4]) : 0;
                int totalPoints = parts.Length > 5 ? int.Parse(parts[5]) : 0;
                
                // Add new EternalGoal to goals list
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), totalTimes, totalPoints, dates));
            }
            // ChecklistGoal
            else if (type == "ChecklistGoal")
            {
                // Parse statistics
                List<string> dates = parts.Length > 9 && !string.IsNullOrEmpty(parts[9]) ? new List<string>(parts[9].Split(':')) : new List<string>();
                int totalTimes = parts.Length > 7 ? int.Parse(parts[7]) : 0;
                int totalPoints = parts.Length > 8 ? int.Parse(parts[8]) : 0;
                
                // Add new ChecklistGoal to goals list
                _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), totalTimes, totalPoints, dates));
            }
            // NegativeGoal
            else if (type == "NegativeGoal")
            {
                // Parse statistics
                List<string> dates = parts.Length > 6 && !string.IsNullOrEmpty(parts[6]) ? new List<string>(parts[6].Split(':')) : new List<string>();
                int totalTimes = parts.Length > 4 ? int.Parse(parts[4]) : 0;
                int totalPoints = parts.Length > 5 ? int.Parse(parts[5]) : 0;
                
                // Add new NegativeGoal to goals list
                _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3]), totalTimes, totalPoints, dates));
            }
        }
    }
}
