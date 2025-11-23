public class Assignment
{
    // Private members
    protected string _studentName;
    protected string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        // Initialize members
        _studentName = studentName;
        _topic = topic;
    }

    // Get Summary Method - Returns topic
    public string GetSummary()
    {
        // Returns Formatted Summary
        return $"{_studentName} - {_topic}";
    }
    
    // Get Student Name Method - Returns Student Name
    public string GetStudentName()
    {
        // Returns Student Name
        return _studentName;
    }
    
    // Get Topic Method - Returns Topic
    public string GetTopic()
    {
        // Returns Topic
        return _topic;
    }
}