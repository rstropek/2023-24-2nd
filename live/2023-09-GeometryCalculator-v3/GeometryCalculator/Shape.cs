// BASE CLASS for Circle, Rectangle, etc.

// abstract = Only for inheritance, cannot be used directly!
public abstract class Shape
{
    public abstract double Area { get; }

    public abstract void Scale(double factor);

    // protected = only for decendent classes
    protected double CalculateScaledFactor(double factor)
    {
        return Math.Sqrt(factor);
    }
}