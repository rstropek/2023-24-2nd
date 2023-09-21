namespace GeometryCalculator;

public static class CircleMath
{
    public static double CalculateArea(double radius)
    {
        return Math.PI * radius * radius;
    }

    public static double CalculateScaledDimensions(double radius, double factor)
    {
        return radius * Math.Sqrt(factor);
    }
}
