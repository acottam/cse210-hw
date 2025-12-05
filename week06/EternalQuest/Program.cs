using System;

// Enhancements:
// 1. NegativeGoal - Deducts points when recorded (for tracking bad habits to avoid)
// 2. Goal Statistics - Tracks completion dates, total times completed, and points earned per goal
// 3. Auto-save/Auto-load - Automatically saves after each action and loads from goals.txt on startup

class Program
{
    // Main method
    static void Main(string[] args)
    {
        // Create GoalManager
        GoalManager manager = new GoalManager();
        
        // Start Goal Manager
        manager.Start();
    }
}