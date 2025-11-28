// ListingActivity class: Inherits from Activity
public class ListingActivity : Activity
{
    // Member Attributes
    // Count of items listed by the user
    private int _count;
    
    // A list of prompts for the listing activity
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Constructor: Initializes the ListingActivity with a name and description
    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    // Run method: Executes the listing activity
    public void Run()
    {
        // Start the activity
        StartActivity();
        
        // Display a random prompt for the user to list items about
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        
        // Show a countdown - 5 seconds
        ShowCountdown(5);
        Console.WriteLine();

        // Get list from user
        GetListFromUser();

        // Display the total number of items listed by the user
        Console.WriteLine($"You listed {_count} items!");
        
        // End the activity
        EndActivity();
    }

    // GetRandomPrompt method: selects a random prompt from the list
    private string GetRandomPrompt()
    {
        // Create a Random object
        Random random = new Random();
        
        // Return a random prompt
        return _prompts[random.Next(_prompts.Count)];
    }

    // GetListFromUser method: prompts user for list items until time expires
    private void GetListFromUser()
    {
        // Initialize count
        _count = 0;
        
        // Calculate the end time based on the duration
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        // Loop until the current time reaches the end time
        while (DateTime.Now < endTime)
        {
            // Prompt the user for input
            Console.Write("> ");

            // Read user input
            Console.ReadLine();

            // Increment the count of entries
            _count++;
        }
    }
}
