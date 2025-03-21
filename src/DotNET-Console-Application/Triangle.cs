namespace DotNET_Console_Application;

public class Triangle : Shape
{
    public Triangle(double bottom = 10, double height = 10)
    {
        Bottom = bottom;
        Height = height;
    }
    public double Bottom { get; set; }
    public double Height { get; set; }

    public override Rectangle ContainWithSquare() => new Rectangle(Math.Max(Bottom, Height), Math.Max(Bottom, Height));

    public override double Area => Bottom * Height / 2;

    public double Leg => Math.Sqrt(Math.Pow(Bottom / 2, 2) + Math.Pow(Height, 2));

    public override double Perimeter => 2 * Leg + Bottom;

    public override string ToString()
    {
        return $"A Rectangle with height {Height:0.00} and base {Bottom:0.00}, which has an area of {Area:0.00}.";
    }
}