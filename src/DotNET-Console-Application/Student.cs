namespace DotNET_Console_Application;

public class Student : Person
{

    public Student(string firstName = "John", string lastName = "Doe", int studentID = 101) : base(firstName, lastName)
    {
        StudentID = studentID;
    }

    public int StudentID { get; set; }
}