using System;

// Base Activity class - common properties and methods
public abstract class Activity
{
    // Member attributes
    private string _date;
    private int _minutes;
    private string _activityType;

    // Constructor
    public Activity(string date, int minutes, string activityType)
    {
        // Initialize attributes
        _date = date;
        _minutes = minutes;
        _activityType = activityType;
    }

    // Abstract: GetDistance - to be overridden in derived classes
    public abstract double GetDistance();

    // Abstract: GetSpeed - to be overridden in derived classes
    public abstract double GetSpeed();

    // Abstract: GetPace - to be overridden in derived classes
    public abstract double GetPace();

    // GetSummary - calls virtual methods to produce summary
    public string GetSummary()
    {
        // Return a summary using polymorphic method calls
        return $"{_date} {_activityType} ({_minutes} min)- Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
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
