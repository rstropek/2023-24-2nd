namespace GeometryCalculator;

public abstract class Shape
{
    public abstract double Area { get; }

    public abstract void Scale(double factor);
}
