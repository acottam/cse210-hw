// ReflectionActivity class: inherits from Activity
public class ReflectionActivity : Activity
{
    // Private Member Attributes
    // List of prompts for reflection
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    // List of reflection questions
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Track used questions to avoid repeats
    private List<string> _usedQuestions = new List<string>();

    // Constructor: initializes the activity with a name and description
    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    // Run method: executes the reflection activity
    public void Run()
    {
        // Start the activity
        StartActivity();

        // Display a random prompt for the user to reflect on
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");

        // Wait for the user to press enter
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");

        // Show a countdown before starting the questions
        ShowCountdown(5);
        
        // Clear the console for the questions
        Console.Clear();

        // Calculate the end time based on the duration
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        
        // Loop until the current time reaches the end time
        while (DateTime.Now < endTime)
        {
            // Display a random question for reflection (no repeats)
            Console.Write($"\n> {GetRandomQuestionNoRepeat()} ");
            
            // Show a spinner - 10 seconds
            ShowSpinner(10);
        }
        
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

    // GetRandomQuestion method: selects a random question from the list
    private string GetRandomQuestion()
    {
        // Create a Random object
        Random random = new Random();
        
        // Return a random question
        return _questions[random.Next(_questions.Count)];
    }

    // GetRandomQuestionNoRepeat method: selects questions without repeating until all are used
    private string GetRandomQuestionNoRepeat()
    {
        // Reset used questions if all have been shown
        if (_usedQuestions.Count >= _questions.Count)
        {
            _usedQuestions.Clear();
        }

        // Find available questions
        List<string> availableQuestions = new List<string>();
        foreach (string question in _questions)
        {
            if (!_usedQuestions.Contains(question))
            {
                availableQuestions.Add(question);
            }
        }

        // Select random from available
        Random random = new Random();
        string selectedQuestion = availableQuestions[random.Next(availableQuestions.Count)];
        
        // Mark as used
        _usedQuestions.Add(selectedQuestion);
        
        return selectedQuestion;
    }
}
