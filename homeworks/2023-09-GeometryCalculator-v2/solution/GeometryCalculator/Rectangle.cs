namespace GeometryCalculator;

public class Rectangle
{
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Area => Width * Height;

    public void Scale(double factor)
    {
        Width *= Math.Sqrt(factor);
        Height *= Math.Sqrt(factor);
    }
}
