using System;

// Cycling class - derived from Activity
public class Cycling : Activity
{
    // Member attributes
    private double _speed;

    // Constructor
    public Cycling(string date, int minutes, double speed) : base(date, minutes, "Stationary Bicycles")
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
}
