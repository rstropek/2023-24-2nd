namespace GeometryCalculator;

public class Triangle : Shape
{
    public Triangle(double baseLength, double height)
    {
        BaseLength = baseLength;
        Height = height;
    }

    public double BaseLength { get; set; }

    public double Height { get; set; }

    public override double Area => BaseLength * Height / 2;

    public override void Scale(double factor)
    {
        BaseLength *= CalculateScaledFactor(factor);
        Height *= CalculateScaledFactor(factor);
    }

    public override string ToString()
    {
        return $"Triangle (base={BaseLength}, height={Height})";
    }
}
