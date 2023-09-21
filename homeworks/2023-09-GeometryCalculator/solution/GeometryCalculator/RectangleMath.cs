namespace GeometryCalculator;

public static class RectangleMath
{
    public static double CalculateArea(double width, double height)
    {
        return width * height;
    }

    public static (double width, double height) CalculateScaledDimensions(double width, double height, double factor)
    {
        return (width * Math.Sqrt(factor), height * Math.Sqrt(factor));
    }
}
