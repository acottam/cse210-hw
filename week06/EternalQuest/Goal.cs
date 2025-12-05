using System;
using System.Collections.Generic;

// Base Goal class
public abstract class Goal
{
    // Protected members
    protected string _name;
    protected string _description;
    protected int _points;
    protected int _totalTimesCompleted;
    protected int _totalPointsEarned;
    protected List<string> _completionDates;

    // Constructor
    public Goal(string name, string description, int points)
    {
        // Initialize attributes
        _name = name;
        _description = description;
        _points = points;
        _totalTimesCompleted = 0;
        _totalPointsEarned = 0;
        _completionDates = new List<string>();
    }

    // Abstract: RecordEvent method - records an event for the goal
    public abstract int RecordEvent();

    // RecordEventWithTracking method - records event and tracks statistics
    public int RecordEventWithTracking()
    {
        // Get points from derived class
        int pointsEarned = RecordEvent();
        
        // Update statistics
        _totalTimesCompleted++;
        _totalPointsEarned += pointsEarned;
        _completionDates.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        
        // Return points earned
        return pointsEarned;
    }

    // Abstract: IsComplete method - checks if goal is complete
    public abstract bool IsComplete();

    // Abstract: GetStringRepresentation method - returns string representation of the goal
    public abstract string GetStringRepresentation();
    
    // Abstract: GetDetailsString method - returns detailed string of the goal
    public abstract string GetDetailsString();

    // GetName method: returns the name of the goal
    public string GetName() => _name;

    // GetStatistics method: returns statistics string for the goal
    public string GetStatistics()
    {
        // Build statistics string
        string stats = $"\n{_name}:\n";
        stats += $"  Total times completed: {_totalTimesCompleted}\n";
        stats += $"  Total points earned: {_totalPointsEarned}\n";
        
        // Add completion dates
        if (_completionDates.Count > 0)
        {
            stats += "  Completion dates:\n";
            foreach (string date in _completionDates)
            {
                stats += $"    - {date}\n";
            }
        }
        else
        {
            stats += "  No completions yet\n";
        }
        
        return stats;
    }

    // SetStatistics method: sets statistics when loading from file
    protected void SetStatistics(int totalTimesCompleted, int totalPointsEarned, List<string> completionDates)
    {
        _totalTimesCompleted = totalTimesCompleted;
        _totalPointsEarned = totalPointsEarned;
        _completionDates = completionDates;
    }
}
