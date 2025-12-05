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

    // Overloaded Constructor
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        // Initialize attributes
        _isComplete = isComplete;
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
        // Return formatted string
        return $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";
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
