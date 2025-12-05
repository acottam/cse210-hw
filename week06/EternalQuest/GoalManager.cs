using System;
using System.Collections.Generic;
using System.IO;

// GoalManager: Manages goals, score, and user interactions
public class GoalManager
{
    // Member Attributes
    private List<Goal> _goals;
    private int _score;

    // Constructor
    public GoalManager()
    {
        // Initialize attributes
        _goals = new List<Goal>();
        _score = 0;
    }

    // Start Method: Main loop for user interaction
    public void Start()
    {
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
            Console.WriteLine("  6. Quit");

            // Get user choice
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            // Handle user choice
            switch (choice)
            {
                // 1. Create New Goal
                case "1":
                    CreateGoal();
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
                    break;
                // 6. Quit
                case "6":
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
            // Points earned
            int pointsEarned = _goals[index].RecordEvent();

            // Update total score
            _score += pointsEarned;

            // Congratulations message: points earned and total score
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
    }

    // SaveGoals Method: Saves current goals and score to a file
    private void SaveGoals()
    {
        // Get filename from user
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        // Write score and goals to file
        using (StreamWriter writer = new StreamWriter(filename))
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

    // LoadGoals Method: Loads goals and score from a file
    private void LoadGoals()
    {
        // Get filename from user
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        
        // Read score and goals from file
        if (File.Exists(filename))
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
                    // Add new SimpleGoal to goals list
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                }
                // EternalGoal
                else if (type == "EternalGoal")
                {
                    // Add new EternalGoal to goals list
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                }
                // ChecklistGoal
                else if (type == "ChecklistGoal")
                {
                    // Add new ChecklistGoal to goals list
                    _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
                }
            }
        }
    }
}
