using System;

// Cycling class - derived from Activity
public class Cycling : Activity
{
    // Member attributes
    private double _speed;

    // Constructor
    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        // Initialize attributes
        _speed = speed;
    }

    // Override: GetDistance - calculate distance based on speed
    public override double GetDistance()
    {
        // Distance = Speed * Time
        return (_speed * GetMinutes()) / 60;
    }

    // Override: GetSpeed - return speed
    public override double GetSpeed()
    {
        // Speed in mph
        return _speed;
    }

    // Override: GetPace - calculate pace
    public override double GetPace()
    {
        // Pace in min per mile
        return 60 / _speed;
    }

    // Override: GetSummary - provide a summary of the cycling activity
    public override string GetSummary()
    {
        // Return formatted summary string
        return $"{GetDate()} Stationary Bicycles ({GetMinutes()} min)- Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
