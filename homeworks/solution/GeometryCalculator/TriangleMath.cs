namespace GeometryCalculator;

public class TriangleMath
{
    public static double CalculateArea(double baseLength, double height)
    {
        return baseLength * height / 2;
    }

    public static (double baseLength, double height) CalculateScaledDimensions(double baselength, double height, double factor)
    {
        return (baselength * Math.Sqrt(factor), height * Math.Sqrt(factor));
    }
}
