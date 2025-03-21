namespace DotNET_Console_Application;

public class Person
{
    public Person(string firstName, string lastName, string location, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Location = location;
        EMail = email;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Location { get; set; }
    public string EMail { get; set; }
    public override string ToString()
    {
        return $"User Details:\nName: {FirstName} {LastName}\nLocation: {Location}\nEmail: {EMail}";
    }
}