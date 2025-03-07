namespace DotNET_Console_Application;

public class Rectangle
{
    public Rectangle(double length = 10, double width = 10)
    {
        Length = length;
        Width = width;
    }
    public double Length { get; set; }
    public double Width { get; set; }
    public Rectangle ContainWithSquare()
    {
        double edge = Math.Max(Length, Width);
        return new Rectangle(edge, edge);
    }

    public bool IsSquare => Length == Width;
    public double Area => Length * Width;
    public double Perimeter => 2 * (Length + Width);

    public override string ToString()
    {
        return $"A Rectangle with length {Length:0.00} and width {Width:0.00}, which has an area of {Area:0.00} and a perimeter of {Perimeter:0.00}.";
    }
}
