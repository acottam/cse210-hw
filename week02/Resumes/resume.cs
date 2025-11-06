using System;

public class Resume
{
    public string _fullName;

    // Make sure to initialize your list to a new List before you use it.
    public List<Job> _jobs = new List<Job>();

    // Constructor
    public Resume(string fullName, List<Job> jobs)
    {
        _fullName = fullName;
        _jobs = jobs;
    }   

    // Method to display resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_fullName}");
        Console.WriteLine("Jobs:");

        // Notice the use of the custom data type "Job" in this loop
        foreach (Job job in _jobs)
        {
            // This calls the Display method on each job
            job.Display();
        }
    }
}