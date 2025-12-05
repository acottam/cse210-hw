using System.Collections.Generic;

// ChecklistGoal class: Inherits from Goal, represents a checklist goal
public class ChecklistGoal : Goal
{
    // Member Attributes
    private int _target;
    private int _bonus;
    private int _timesCompleted;

    // Constructor (without timesCompleted)
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        // Initialize attributes
        _target = target;
        _bonus = bonus;
        _timesCompleted = 0;
    }

    // Overloaded Constructor (for loading from file)
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int timesCompleted) : base(name, description, points)
    {
        // Initialize attributes
        _target = target;
        _bonus = bonus;
        _timesCompleted = timesCompleted;
    }

    // Constructor with statistics (for loading from file)
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int timesCompleted, int totalTimesCompleted, int totalPointsEarned, List<string> completionDates) : base(name, description, points)
    {
        // Initialize attributes
        _target = target;
        _bonus = bonus;
        _timesCompleted = timesCompleted;
        SetStatistics(totalTimesCompleted, totalPointsEarned, completionDates);
    }

    // Override RecordEvent method: increments times completed and returns points (with bonus if target reached)
    public override int RecordEvent()
    {
        // Increment times completed
        _timesCompleted++;

        // Return points with bonus if target reached
        if (_timesCompleted >= _target)
        {
            // Return points plus bonus
            return _points + _bonus;
        }

        // Return regular points
        return _points;
    }

    // Override IsComplete method: checks if goal is complete
    public override bool IsComplete() => _timesCompleted >= _target;

    // Override GetStringRepresentation method: returns string representation of the goal
    public override string GetStringRepresentation()
    {
        // Return formatted string with statistics (using pipe delimiter)
        string dates = string.Join(":", _completionDates);
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_target}|{_bonus}|{_timesCompleted}|{_totalTimesCompleted}|{_totalPointsEarned}|{dates}";
    }

    // Override GetDetailsString method: returns detailed string of the goal
    public override string GetDetailsString()
    {
        // Return formatted string with checkbox and progress
        string checkbox = IsComplete() ? "[X]" : "[ ]";

        // Return details string
        return $"{checkbox} {_name} ({_description}) -- Currently completed: {_timesCompleted}/{_target}";
    }
}
