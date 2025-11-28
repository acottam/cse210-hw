// Activity class (base class for mindfulness activities)
public class Activity
{
    // Member attributes
    protected string _name;
    protected string _description;
    protected int _duration;

    // Constructor
    public Activity(string name, string description)
    {
        // Initialize member attributes
        _name = name;
        _description = description;
    }

    // StartActivity method: displays welcome message, description, and prompts for duration
    public void StartActivity()
    {
        // Welcome message and description
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");

        // Prompt for duration
        _duration = int.Parse(Console.ReadLine());

        // Prepare for activity
        Console.WriteLine("\nGet ready...");
        
        // Show spinner
        ShowSpinner(3);
    }

    // EndActivity method: displays completion message and duration
    public void EndActivity()
    {
        // Completion message
        Console.WriteLine("\nWell done!!");

        // Show spinner
        ShowSpinner(3);

        // Display duration message
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        
        // Show spinner
        ShowSpinner(3);
    }

    // ShowSpinner method: displays a spinner animation for the specified duration
    protected void ShowSpinner(int seconds)
    {
        // Spinner characters
        List<string> spinnerChars = new List<string> { "|", "/", "-", "\\" };

        // Calculate end time
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        // Spinner loop
        int i = 0;
        
        // Loop until the time is up
        while (DateTime.Now < endTime)
        {
            // Display spinner character
            Console.Write(spinnerChars[i]);
            
            // Pause for 250 milliseconds
            Thread.Sleep(250);
            
            // Erase spinner character
            Console.Write("\b \b");
            
            // Update index (cycle through spinner characters and restart if needed)
            i = (i + 1) % spinnerChars.Count;
        }
    }

    // ShowCountdown method: displays a countdown from the specified number of seconds
    protected void ShowCountdown(int seconds)
    {
        // Countdown loop
        for (int i = seconds; i > 0; i--)
        {
            // Display countdown number
            Console.Write(i);

            // Pause for 1 second
            Thread.Sleep(1000);

            // Erase countdown number
            Console.Write("\b \b");
        }
    }

    // GetDuration method: returns the duration of the activity
    public int GetDuration()
    {
        return _duration;
    }
}
