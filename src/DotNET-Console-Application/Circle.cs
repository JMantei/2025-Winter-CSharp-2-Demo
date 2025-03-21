namespace DotNET_Console_Application;

public class Circle : Shape
{
    public Circle(double radius = 10)
    {
        Radius = radius;
    }
    public double Radius { get; set; }

    public override double Area => Math.PI * Math.Pow(Radius, 2);

    public double Circumference => 2 * Math.PI * Radius;

    public override double Perimeter => Circumference;
    public double Diameter => 2 * Radius;

    public override Rectangle ContainWithSquare() => new Rectangle(Diameter, Diameter);

    public override string ToString()
    {
        return $"A Circle with radius {Radius:0.00}, which has a diameter of {Diameter:0.00}, an area of {Area:0.00} and a circumference of {Circumference:0.00}.";
    }
}