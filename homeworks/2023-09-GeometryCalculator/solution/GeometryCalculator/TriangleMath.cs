namespace GeometryCalculator;

public static class TriangleMath
{
    public static double CalculateArea(double baseLength, double height)
    {
        return baseLength * height / 2;
    }

    public static (double baseLength, double height) CalculateScaledDimensions(double baseLength, double height, double factor)
    {
        return (baseLength * Math.Sqrt(factor), height * Math.Sqrt(factor));
    }
}
