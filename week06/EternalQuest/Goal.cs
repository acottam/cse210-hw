// Base Goal class
public abstract class Goal
{
    // Protected members
    protected string _name;
    protected string _description;
    protected int _points;

    // Constructor
    public Goal(string name, string description, int points)
    {
        // Initialize attributes
        _name = name;
        _description = description;
        _points = points;
    }

    // Abstract: RecordEvent method - records an event for the goal
    public abstract int RecordEvent();

    // Abstract: IsComplete method - checks if goal is complete
    public abstract bool IsComplete();

    // Abstract: GetStringRepresentation method - returns string representation of the goal
    public abstract string GetStringRepresentation();
    
    // Abstract: GetDetailsString method - returns detailed string of the goal
    public abstract string GetDetailsString();

    // GetName method: returns the name of the goal
    public string GetName() => _name;
}
