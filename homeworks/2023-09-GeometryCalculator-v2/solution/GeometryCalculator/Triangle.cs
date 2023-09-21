namespace GeometryCalculator;

public class Triangle
{
    public Triangle(double baseLength, double height)
    {
        BaseLength = baseLength;
        Height = height;
    }

    public double BaseLength { get; set; }

    public double Height { get; set; }

    public double Area => BaseLength * Height / 2;

    public void Scale(double factor)
    {
        BaseLength *= Math.Sqrt(factor);
        Height *= Math.Sqrt(factor);
    }
}
