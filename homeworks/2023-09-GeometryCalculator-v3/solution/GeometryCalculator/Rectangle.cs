namespace GeometryCalculator;

public class Rectangle : Shape
{
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Width { get; set; }

    public double Height { get; set; }

    public override double Area => Width * Height;

    public override void Scale(double factor)
    {
        Width *= Math.Sqrt(factor);
        Height *= Math.Sqrt(factor);
    }

    public override string ToString() => $"Rectangle (width = {Width}, height = {Height})";
}
