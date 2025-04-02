using DotNET_Console_Application.Models;

namespace DotNET_Console_Application;



class Functions
{
  public static string GetString(string prompt)
  {
    Console.Write(prompt);
    return Console.ReadLine().Trim();
  }

  public static void AddInstructor()
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

  public static void AddCourse()
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

  public static void AddStudent()
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

  public static void DisplayInstructors()
  {
    using (CodeFirstContext context = new CodeFirstContext())
    {
      foreach (Instructor instructor in context.Instructors.ToList())
      {
        Console.WriteLine($"{instructor.ID}. {instructor.FirstName} {instructor.LastName}");
      }
    }
  }

  public static void DisplayCourses()
  {
    using (CodeFirstContext context = new CodeFirstContext())
    {
      foreach (Course course in context.Courses.ToList())
      {
        Instructor target = context.Instructors.Find(course.InstructorID)!;
        Console.WriteLine($"{course.ID}. {course.Name} ({course.Code}) taught by {target.FirstName} {target.LastName}");
      }
    }
  }

  public static void DisplayStudents()
  {
    using (CodeFirstContext context = new CodeFirstContext())
    {
      foreach (Student student in context.Students.ToList())
      {
        Console.WriteLine($"{student.FirstName} {student.LastName}");
      }
    }
  }
}