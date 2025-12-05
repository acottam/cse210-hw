using System.Collections.Generic;

// EternalGoal class: Represents an eternal goal that can be completed multiple times
public class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        // Do nothing
    }

    // Constructor with statistics (for loading from file)
    public EternalGoal(string name, string description, int points, int totalTimesCompleted, int totalPointsEarned, List<string> completionDates) : base(name, description, points)
    {
        SetStatistics(totalTimesCompleted, totalPointsEarned, completionDates);
    }

    // Override RecordEvent method: Eternal goals can be recorded multiple times
    public override int RecordEvent()
    {
        // Return point value
        return _points;
    }

    // IsComplete method: Eternal goals are never complete
    public override bool IsComplete() => false;

    // GetStringRepresentation method: returns string representation of the goal
    public override string GetStringRepresentation()
    {
        // Return formatted string with statistics
        string dates = string.Join("|", _completionDates);
        return $"EternalGoal:{_name},{_description},{_points},{_totalTimesCompleted},{_totalPointsEarned},{dates}";
    }

    // GetDetailsString method: returns detailed string of the goal
    public override string GetDetailsString()
    {
        // Eternal goals are never complete, so always return unchecked box
        return $"[ ] {_name} ({_description})";
    }
}
