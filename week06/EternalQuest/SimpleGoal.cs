using System.Collections.Generic;

// SimpleGoal class: inherits from Goal class
public class SimpleGoal : Goal
{
    // Member Attributes
    private bool _isComplete;

    // Constructor (without isComplete)
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        // Initialize attributes
        _isComplete = false;
    }

    // Overloaded Constructor (for loading from file)
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        // Initialize attributes
        _isComplete = isComplete;
    }

    // Constructor with statistics (for loading from file)
    public SimpleGoal(string name, string description, int points, bool isComplete, int totalTimesCompleted, int totalPointsEarned, List<string> completionDates) : base(name, description, points)
    {
        // Initialize attributes
        _isComplete = isComplete;
        SetStatistics(totalTimesCompleted, totalPointsEarned, completionDates);
    }

    // Override Methods
    public override int RecordEvent()
    {
        // Mark goal as complete
        _isComplete = true;

        // Return points
        return _points;
    }

    // Override IsComplete method: returns if goal is complete
    public override bool IsComplete() => _isComplete;

    // Override GetStringRepresentation method: returns string representation of the goal
    public override string GetStringRepresentation()
    {
        // Get completion dates as string (using colon delimiter)
        string dates = string.Join(":", _completionDates);
        
        // Return string representation (using pipe delimiter)
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}|{_totalTimesCompleted}|{_totalPointsEarned}|{dates}";
    }

    // Override GetDetailsString method: returns detailed string of the goal
    public override string GetDetailsString()
    {
        // Return formatted string: [X] or [ ] based on completion
        string checkbox = _isComplete ? "[X]" : "[ ]";

        // Return details string
        return $"{checkbox} {_name} ({_description})";
    }
}
