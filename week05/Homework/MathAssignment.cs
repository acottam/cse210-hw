public class MathAssignment : Assignment 
{
    // Private members
    protected string _textbookSelection;
    protected string _problems;

    // Constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        // Initialize members
        _textbookSelection = textbookSection;
        _problems = problems;
    }

    // Get Homework List - Returns a list of homework problems 
    public string GetHomeworkList()
    {
        return $"Section {_textbookSelection} Problems {_problems}";
    }
}