using System;

// Base Activity class - common properties and methods
public class Activity
{
    // Member attributes
    private string _date;
    private int _minutes;

    // Constructor
    public Activity(string date, int minutes)
    {
        // Initialize attributes
        _date = date;
        _minutes = minutes;
    }

    // Virtual: GetDistance - to be overridden in derived classes
    public virtual double GetDistance()
    {
        return 0;
    }

    // Virtual: GetSpeed - to be overridden in derived classes
    public virtual double GetSpeed()
    {
        return 0;
    }

    // Virtual: GetPace - to be overridden in derived classes
    public virtual double GetPace()
    {
        return 0;
    }

    // Virtual: GetSummary - to be overridden in derived classes
    public virtual string GetSummary()
    {
        // Return a generic summary
        return $"{_date} ({_minutes} min)- Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }

    // Protected: GetDate - to access date in derived classes
    protected string GetDate()
    {
        // return Date
        return _date;
    }

    // Protected: GetMinutes - to access minutes in derived classes
    protected int GetMinutes()
    {
        // return Minutes
        return _minutes;
    }
}
