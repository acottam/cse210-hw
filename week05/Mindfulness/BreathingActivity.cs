// BreathingActivity class inherits from Activity class
public class BreathingActivity : Activity
{
    // Constructor: initializes the activity with a name and description
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Run method: executes the breathing activity
    public void Run()
    {
        // Start the activity
        StartActivity();

        // Calculate the end time based on the duration
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        // Loop until the current time reaches the end time
        while (DateTime.Now < endTime)
        {
            // Prompt the user to breathe in
            Console.Write("\n\nBreathe in...");

            // Show a countdown - 4 seconds
            ShowCountdown(4);

            // Prompt the user to breathe out
            Console.Write("\nNow breathe out...");
            
            // Show a countdown - 6 seconds
            ShowCountdown(6);
        }
        
        // End the activity
        EndActivity();
    }
}
