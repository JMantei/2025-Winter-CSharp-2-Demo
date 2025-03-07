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
        Rectangle myRectangle = new Rectangle(GetValidInt("Please enter the rectangle's length: "), GetValidInt("Please enter the rectangle's width: "));
        Circle myCircle = new Circle(GetValidInt("Please enter the circle's radius: "));
        Triangle myTriangle = new Triangle(GetValidInt("Please enter the triangle's base: "), GetValidInt("Please enter the triangle's height: "));

        Console.WriteLine(myRectangle);
        Console.WriteLine(myCircle);
        Console.WriteLine(myTriangle);
    }
}
