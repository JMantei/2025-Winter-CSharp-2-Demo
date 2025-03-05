namespace DotNET_Console_Application;

public class Instructor : Person
{

    public Instructor(string firstName = "John", string lastName = "Doe", int instructorID = 101) : base(firstName, lastName)
    {
        InstructorID = instructorID;
    }

    public int InstructorID { get; set; }

    public override void Eat(float amount)
    {
        HungerLevel -= amount * 0.9f;
    }
}