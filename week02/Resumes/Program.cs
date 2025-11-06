using System;

class Program
{
    static void Main(string[] args)
    {
        List<Job> jobs = new List<Job>();
        
        // Create two Job objects
        Job job1 = new Job("Perficient", "Senior Solutions Architect", "2025", "present");
        Job job2 = new Job("Capgemini", "Managing Delivery Architect", "2022", "2025");

        // Add the Job objects to the list
        jobs.Add(job1);
        jobs.Add(job2);

        // Create a Resume object and add the jobs
        Resume myResume = new Resume("Adam Cottam", jobs);

        // Display heading
        Console.WriteLine("Work Experience:");

        // Display the resume
        myResume.Display();
    }
}