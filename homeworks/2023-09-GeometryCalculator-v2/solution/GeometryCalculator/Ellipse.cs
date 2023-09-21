namespace GeometryCalculator;

public class Ellipse
{
    public Ellipse(double longestRadius, double shortestRadius)
    {
        LongestRadius = longestRadius;
        ShortestRadius = shortestRadius;
    }

    public double LongestRadius { get; set; }

    public double ShortestRadius { get; set; }

    public double Area => Math.PI * LongestRadius * ShortestRadius;

    public void Scale(double factor)
    {
        LongestRadius *= Math.Sqrt(factor);
        ShortestRadius *= Math.Sqrt(factor);
    }
}
