using System;
using System.Collections.Generic;

class Program
{
    // Main method
    static void Main(string[] args)
    {
        // Create a list to hold activities
        List<Activity> activities = new List<Activity>();

        // Add different types of activities - Running, Cycling, Swimming
        activities.Add(new Running("03 Dec 2025", 30, 3.0));
        activities.Add(new Cycling("04 Dec 2025", 45, 15.0));
        activities.Add(new Swimming("05 Dec 2025", 30, 20));

        // Display summaries for each activity (i.e., distance, speed, pace)
        foreach (Activity activity in activities)
        {
            // Display the summary of the activity
            Console.WriteLine(activity.GetSummary());
        }
    }
}
