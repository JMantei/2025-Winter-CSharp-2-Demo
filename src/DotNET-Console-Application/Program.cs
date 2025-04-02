using DotNET_Console_Application.Models;
using static DotNET_Console_Application.Functions;

namespace DotNET_Console_Application;

class Program
{
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
                  AddInstructor();
                }
                else if (entityChoice == 1)
                {
                  AddCourse();
                }
                else if (entityChoice == 2)
                {
                  AddStudent();
                }

              }
              else if (operationChoice == 2)
              {
                if (entityChoice == 0)
                {
                  DisplayInstructors();
                }
                else if (entityChoice == 1)
                {
                  DisplayCourses();
                }
                else if (entityChoice == 2)
                {
                  DisplayStudents();
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
