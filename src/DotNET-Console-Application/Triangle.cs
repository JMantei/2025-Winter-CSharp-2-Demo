namespace DotNET_Console_Application;

public class Triangle
{
    public Triangle(double bottom = 10, double height = 10)
    {
        Bottom = bottom;
        Height = height;
    }
    public double Bottom { get; set; }
    public double Height { get; set; }

    public Rectangle ContainWithRectangle() => new Rectangle(Bottom, Height);

    public double Area => Bottom * Height / 2;
    public override string ToString()
    {
        return $"A Rectangle with height {Height:0.00} and base {Bottom:0.00}, which has an area of {Area:0.00}.";
    }
}