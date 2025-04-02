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
                                Console.WriteLine($"Create a {entities[entityChoice]}");
                            }
                            else if (operationChoice == 2)
                            {
                                Console.WriteLine($"Read a {entities[entityChoice]}");
                            }
                            else if (operationChoice == 3)
                            {
                                Console.WriteLine($"Update a {entities[entityChoice]}");
                            }
                            else if (operationChoice == 4)
                            {
                                Console.WriteLine($"Delete a {entities[entityChoice]}");
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
