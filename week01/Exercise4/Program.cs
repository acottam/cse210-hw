using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // List
        List<int> numbers = new List<int>();
        
        // Instructions
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        // vars
        int userNumber = -1;

        // Loop and allow user to enter number
        while (userNumber != 0)
        {
            // User INput
            Console.Write("Enter number (0 to quit): ");
            userNumber = int.Parse(Console.ReadLine());

            // Add number (if zero escape)
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }       

        int sum = 0;        
        int largest = 0;
        int smallest = 10000;
        List<int> sortedNumbers = new List<int>();

        // Iterate through Numbers List
        foreach (int num in numbers)
        {
            Console.WriteLine(num);

            // Find sum
            sum += num;

            // Find largest number
            if (num > largest)
            {
                largest = num;
            }

            // Find smallest positive number
            if (num > 0 && num < smallest)
            {
                smallest = num;
            }

        }   

        // The sum is:
        Console.WriteLine($"The sum is: {sum}");

        // The average is (3 decimal points):
        Console.WriteLine($"The average is: {Math.Round((float)sum / numbers.Count, 3)}");

        // The largest number is:
        Console.WriteLine($"The largest number is: {largest}");

        // The smallest positive number is:
        Console.WriteLine($"The smallest positive number is: {smallest}");

        // Sort the numbers list
        sortedNumbers = numbers.OrderBy(x => x).ToList();

        // Print sorted list
        Console.WriteLine("The sorted list is: ");
        foreach (int num in sortedNumbers)
        {
            Console.WriteLine(num);
        }

    }
}