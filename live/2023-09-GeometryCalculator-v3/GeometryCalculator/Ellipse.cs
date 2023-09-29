namespace GeometryCalculator;

public class Ellipse : Shape
{
    public Ellipse(double longestRadius, double shortestRadius)
    {
        LongestRadius = longestRadius;
        ShortestRadius = shortestRadius;
    }

    public double LongestRadius { get; set; }

    public double ShortestRadius { get; set; }

    public override double Area => Math.PI * LongestRadius * ShortestRadius;

    public override void Scale(double factor)
    {
        LongestRadius *= CalculateScaledFactor(factor);
        ShortestRadius *= CalculateScaledFactor(factor);
    }

    public override string ToString()
    {
        return $"Ellipse (longest={LongestRadius}, shortest={ShortestRadius})";
    }
}
