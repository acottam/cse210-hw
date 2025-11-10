using System;
public class Job
{
    private string _company;
    private string _jobTitle;
    private string _startYear;
    private string _endYear;

    // Constructor
    public Job(string company, string jobTitle, string startYear, string endYear)
    {
        _company = company;
        _jobTitle = jobTitle;
        _startYear = startYear;
        _endYear = endYear;
    }

    // Method to display job details
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} at {_company} ({_startYear} - {_endYear})");
    }
}
