namespace DotNET_Console_Application;

class Program
{
    static int GetValidInt(string prompt)
    {
        int result = 0;
        bool valid = false;
        while (!valid)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out result))
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
        return result;
    }
    static void Main(string[] args)
    {
        string selection = "";
        List<Shape> shapes = new List<Shape>();
        do
        {
            Console.Write("--Shapes--\n1. Rectangle\n2. Circle\n3. Triangle\n4. Exit\n\tChoose: ");
            selection = Console.ReadLine().Trim();
            if (selection == "1")
            {
                shapes.Add(new Rectangle(GetValidInt("Please enter the rectangle's length: "), GetValidInt("Please enter the rectangle's width: ")));
            }
            else if (selection == "2")
            {
                shapes.Add(new Circle(GetValidInt("Please enter the circle's radius: ")));
            }
            else if (selection == "3")
            {
                shapes.Add(new Triangle(GetValidInt("Please enter the triangle's base: "), GetValidInt("Please enter the triangle's height: ")));
            }
            else
            {
                Console.WriteLine("Invalid selection, please try again...");
            }
            Console.WriteLine($"Total Perimeter: {shapes.Sum(x => x.Perimeter)}\nTotal Area: {shapes.Sum(x => x.Area)}\nTotal Area of Squares: {shapes.Sum(x => x.ContainWithSquare().Area)}");
        } while (selection != "4");
        Console.WriteLine("Cya!");
    }
}
