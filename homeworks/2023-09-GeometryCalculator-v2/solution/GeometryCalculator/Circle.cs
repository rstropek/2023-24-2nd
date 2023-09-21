namespace GeometryCalculator;

// Classes COMBINE DATA (e.g. radius) with LOGIC (e.g. area calculation, scaling)
// that works with the data of the class.
public class Circle
{
    // This is a "Constructor".
    // Read more at https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors
    public Circle(double radius)
    {
        Radius = radius;
    }

    // This is a "Property" (in this case a read/write property because of setter and getter).
    // Read more at https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
    public double Radius { get; set; }

    // This is also a "Property", but a read-only property because its value is dynamically calculated.
    public double Area => Math.PI * Radius * Radius;

    // This is a "Method", but a method that is bound to a circle. Therefore,
    // we call it a "Member Method" of the class.
    public void Scale(double factor)
    {
        Radius *= Math.Sqrt(factor);
    }
}
