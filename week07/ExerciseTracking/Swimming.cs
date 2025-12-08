using System;

// Swimming class - derived from Activity
public class Swimming : Activity
{
    // Member attributes
    private int _laps;

    // Constructor
    public Swimming(string date, int minutes, int laps) : base(date, minutes, "Swimming")
    {
        // Initialize attributes
        _laps = laps;
    }

    // Override: GetDistance - calculate distance based on laps
    public override double GetDistance()
    {
        // Each lap is 50 meters; convert to miles
        return _laps * 50 / 1000.0 * 0.62;
    }

    // Override: GetSpeed - calculate speed
    public override double GetSpeed()
    {
        // Speed in mph
        return (GetDistance() / GetMinutes()) * 60;
    }

    // Override: GetPace - calculate pace
    public override double GetPace()
    {
        // Pace in min per mile
        return GetMinutes() / GetDistance();
    }
}
