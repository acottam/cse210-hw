using System;

class Program
{
    // Main method
    static void Main(string[] args)
    {
        // Display welcome message
        DisplayWelcome();
        
        // Prompt user for their name
        string userName = PromptUserName();

        // Prompt user for their favorite number
        int favoriteNumber = PromptUserNumber();

        // Square the favorite number
        int squaredNumber = SquareNumber(favoriteNumber);

        // Display the results
        DisplayResults(userName, squaredNumber);
    }

    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to prompt get user's name 
    static string PromptUserName()
    {
        // Prompt user for their name
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        
        // Return the user name
        return userName;
    }

    // Function to prompt user for their favorite number
    static int PromptUserNumber()
    {
        // Prompt user for their favorite number
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine());
        
        // Return the favorite number
        return favoriteNumber;
    }
    
    // Function to square a number
    static int SquareNumber(int number)
    {
        // Compute the square number
        int squared = number * number;
        
        // Return the result
        return squared;
    }
    
    // Function to display the final results
    static void DisplayResults(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is: {squaredNumber}");
    }   
}