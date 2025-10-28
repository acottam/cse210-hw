using System;

class Program
{
    static void Main(string[] args)
    {
        // Get user grade percentage
        Console.Write("What is your grade percentage? ");
        string gradePercentage = Console.ReadLine();
        
        // Cast as float 
        float grade = float.Parse(gradePercentage);

        string letterGrade = "";
        string sign = "";

        // Compute Letter Grade
        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }
        
        // Compute Sign
        if (letterGrade != "F")
        {
            int lastDigit = (int)grade % 10;
            if (lastDigit >= 7)
                sign = "+";
            else if (lastDigit < 3)
                sign = "-";
        }

        // Output Letter Grade
        Console.WriteLine($"Your letter grade is: {letterGrade}{sign}");

        // Passed
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("You did not pass the course. Better luck next time.");
        }
        
    }
}