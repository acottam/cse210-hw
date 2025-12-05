using System.Collections.Generic;

// NegativeGoal class: Represents a negative goal that deducts points (for tracking bad habits)
public class NegativeGoal : Goal
{
    // Constructor
    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {
        // Do nothing
    }

    // Constructor with statistics (for loading from file)
    public NegativeGoal(string name, string description, int points, int totalTimesCompleted, int totalPointsEarned, List<string> completionDates) : base(name, description, points)
    {
        SetStatistics(totalTimesCompleted, totalPointsEarned, completionDates);
    }

    // Override RecordEvent method: Negative goals deduct points
    public override int RecordEvent()
    {
        // Return negative point value
        return -_points;
    }

    // IsComplete method: Negative goals are never complete
    public override bool IsComplete() => false;

    // GetStringRepresentation method: returns string representation of the goal
    public override string GetStringRepresentation()
    {
        // Return formatted string with statistics
        string dates = string.Join("|", _completionDates);
        return $"NegativeGoal:{_name},{_description},{_points},{_totalTimesCompleted},{_totalPointsEarned},{dates}";
    }

    // GetDetailsString method: returns detailed string of the goal
    public override string GetDetailsString()
    {
        // Negative goals show with [-] to indicate point deduction
        return $"[-] {_name} ({_description})";
    }
}
