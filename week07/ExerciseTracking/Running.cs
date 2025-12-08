using System;

// Running class - derived from Activity
public class Running : Activity
{
    // Member attributes
    private double _distance;

    // Constructor
    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        // Initialize attributes
        _distance = distance;
    }

    // Override: GetDistance - return distance
    public override double GetDistance()
    {
        // Distance in miles
        return _distance;
    }

    // Override: GetSpeed - calculate speed
    public override double GetSpeed()
    {
        // Speed in mph
        return (_distance / GetMinutes()) * 60;
    }

    // Override: GetPace - calculate pace
    public override double GetPace()
    {
        // Pace in min per mile
        return GetMinutes() / _distance;
    }

    // Override: GetSummary - provide a summary of the running activity
    public override string GetSummary()
    {
        // Return formatted summary string
        return $"{GetDate()} Running ({GetMinutes()} min)- Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
