namespace DotNET_Console_Application;

class Program
{
    static void Main(string[] args)
    {
        List<Person> persons = new List<Person>() {
            new Student(lastName: "Shmoe"),
            new Instructor(firstName: "Bob", instructorID: 205)
        };
        foreach (Person person in persons)
        {
            // This can get you out of some predicaments but it is DANGEROUS because we have no way of knowing what other subclasses might exist of Person.
            int personID = person.GetType() == typeof(Instructor) ? ((Instructor)person).InstructorID : ((Student)person).StudentID;
            Console.WriteLine($"({personID}) {person.FirstName} {person.LastName}");
            person.FirstName = "        Jane  ";
            Console.WriteLine($"{person.FirstName} {person.LastName}");
            Console.WriteLine(person.FullName);
            Console.WriteLine(person.HungerLevel);
            person.Eat(12f);
            Console.WriteLine(person.HungerLevel);
        }

    }
}
