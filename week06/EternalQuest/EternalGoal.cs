// EternalGoal class: Represents an eternal goal that can be completed multiple times
public class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        // Do nothing
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
        // Return formatted string
        return $"EternalGoal:{_name},{_description},{_points}";
    }

    // GetDetailsString method: returns detailed string of the goal
    public override string GetDetailsString()
    {
        // Eternal goals are never complete, so always return unchecked box
        return $"[ ] {_name} ({_description})";
    }
}
