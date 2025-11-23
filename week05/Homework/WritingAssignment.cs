public class WritingAssignment : Assignment 
{
    // Private members
    protected string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        // Initialize members
        _title = title;
    }

    // Get Writing Information - Returns formatted writing information 
    public string GetWritingInformation()
    {
        // Get the student's name
        string studentName = GetStudentName();

        // Get the topic
        string topic = GetTopic();

         // Return formatted writing information
        return $"Title: {_title}\nTopic: {topic}\nStudent Name: {studentName}"; 
    }
}