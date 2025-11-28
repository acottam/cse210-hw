// Exceeding Requirements:
// 1. Activity tracking - Program tracks and displays how many times each activity has been completed
// 2. Enhanced random selection - Prompts/questions don't repeat until all have been shown
// 3. Session summary - Displays total time spent in mindfulness activities

class Program
{
    // Track activity completion counts
    static int _breathingCount = 0;
    static int _reflectionCount = 0;
    static int _listingCount = 0;
    static int _totalSeconds = 0;

    // Main method
    static void Main(string[] args)
    {
        // Menu loop
        while (true)
        {
            // Display menu
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine($"\nActivity Summary: Breathing({_breathingCount}) Reflection({_reflectionCount}) Listing({_listingCount}) - Total: {_totalSeconds}s");
            Console.Write("Select a choice from the menu: ");
            
            // Get user choice
            string choice = Console.ReadLine();

            // 1. Breathing Activity
            if (choice == "1")
            {
                // Clear console
                Console.Clear();

                // Instantiate BreathingActivity
                BreathingActivity breathing = new BreathingActivity();
                
                // Run Breathing Activity
                breathing.Run();
                
                // Track completion
                _breathingCount++;
                _totalSeconds += breathing.GetDuration();
            }
            // 2. Reflecting Activity
            else if (choice == "2")
            {
                // Clear console
                Console.Clear();

                // Instaniate ReflectionActivity
                ReflectionActivity reflection = new ReflectionActivity();
                
                // Run Reflection Activity
                reflection.Run();
                
                // Track completion
                _reflectionCount++;
                _totalSeconds += reflection.GetDuration();
            }
            // 3. Listing Activity
            else if (choice == "3")
            {
                // Clear console
                Console.Clear();

                // Instantiate ListingActivity
                ListingActivity listing = new ListingActivity();
                
                // Run Listing Activity
                listing.Run();
                
                // Track completion
                _listingCount++;
                _totalSeconds += listing.GetDuration();
            }
            // 4. Quit
            else if (choice == "4")
            {
                // Display final summary
                Console.WriteLine($"\nTotal mindfulness time: {_totalSeconds} seconds. Great work!");
                
                // Exit program
                break;
            }
        }
    }
}
