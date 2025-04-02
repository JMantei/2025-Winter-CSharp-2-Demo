using DotNET_Console_Application.Models;

namespace DotNET_Console_Application;



class Program
{
    static string GetString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine().Trim();
    }
    static void Main(string[] args)
    {
        string[] entities = ["Instructor", "Course", "Student"];
        int entityChoice;
        do
        {
            Console.Write("School Program\n1. Instructor\n2. Course\n3. Student\n4. Exit\n\tChoice: ");
            if (int.TryParse(Console.ReadLine().Trim(), out entityChoice))
            {
                entityChoice--;
                if (entityChoice >= 0 && entityChoice <= 2)
                {
                    int operationChoice;
                    do
                    {

                        Console.Write($"School Program - {entities[entityChoice]}\n1. Create\n2. Read\n3. Update\n4. Delete\n5. Exit\n\tChoice: ");
                        if (int.TryParse(Console.ReadLine().Trim(), out operationChoice))
                        {
                            if (operationChoice == 1)
                            {
                                if (entityChoice == 0)
                                {
                                    using (CodeFirstContext context = new CodeFirstContext())
                                    {
                                        context.Instructors.Add(new Instructor()
                                        {
                                            FirstName = GetString("Please enter the First Name: "),
                                            LastName = GetString("Please enter the Last Name: "),
                                        });
                                        context.SaveChanges();
                                    }
                                }
                                else if (entityChoice == 1)
                                {
                                    using (CodeFirstContext context = new CodeFirstContext())
                                    {
                                        context.Courses.Add(new Course()
                                        {
                                            Code = GetString("Please enter the Course Code: "),
                                            Name = GetString("Please enter the Name: "),
                                            // This should be a list then select, but for now we're going basic.
                                            InstructorID = int.Parse(GetString("Please enter the Instructor ID: "))
                                        });
                                        context.SaveChanges();
                                    }
                                }
                                else if (entityChoice == 2)
                                {
                                    using (CodeFirstContext context = new CodeFirstContext())
                                    {
                                        context.Students.Add(new Student()
                                        {
                                            FirstName = GetString("Please enter the First Name: "),
                                            LastName = GetString("Please enter the Last Name: "),
                                            CourseID = int.Parse(GetString("Please enter the Course ID: "))
                                        });
                                        context.SaveChanges();
                                    }
                                }

                            }
                            else if (operationChoice == 2)
                            {
                                if (entityChoice == 0)
                                {
                                    using (CodeFirstContext context = new CodeFirstContext())
                                    {
                                        foreach (Instructor instructor in context.Instructors.ToList())
                                        {
                                            Console.WriteLine($"{instructor.ID}. {instructor.FirstName} {instructor.LastName}");
                                        }
                                    }
                                }
                            }
                            else if (operationChoice == 3)
                            {
                                using (CodeFirstContext context = new CodeFirstContext())
                                {
                                    foreach (Instructor instructor in context.Instructors.ToList())
                                    {
                                        Console.WriteLine($"{instructor.ID}. {instructor.FirstName} {instructor.LastName}");
                                    }
                                    int targetID = int.Parse(GetString("Please enter the instructor ID to update: "));
                                    Instructor? target = context.Instructors.Find(targetID);
                                    if (target == null)
                                    {
                                        Console.WriteLine("Could not find that instructor, please try again.");
                                    }
                                    else
                                    {
                                        target.FirstName = GetString("Please enter the new First Name: ");
                                        target.LastName = GetString("Please enter the new Last Name: ");
                                        context.SaveChanges();
                                    }
                                }
                            }
                            else if (operationChoice == 4)
                            {
                                using (CodeFirstContext context = new CodeFirstContext())
                                {
                                    foreach (Instructor instructor in context.Instructors.ToList())
                                    {
                                        Console.WriteLine($"{instructor.ID}. {instructor.FirstName} {instructor.LastName}");
                                    }
                                    int targetID = int.Parse(GetString("Please enter the instructor ID to update: "));
                                    Instructor? target = context.Instructors.Find(targetID);
                                    if (target == null)
                                    {
                                        Console.WriteLine("Could not find that instructor, please try again.");
                                    }
                                    else
                                    {
                                        context.Remove(target);
                                        context.SaveChanges();
                                    }
                                }
                            }
                            else if (operationChoice != 5)
                            {
                                Console.WriteLine("Sorry, invalid selection. Try again.");
                            }
                        }
                    } while (operationChoice != 5);
                }
                else if (entityChoice != 3)
                {
                    Console.WriteLine("Sorry, invalid selection. Try again.");

                }
            }
            else
            {
                Console.WriteLine("Sorry, invalid selection. Try again.");
            }

        } while (entityChoice != 3);

    }
}
