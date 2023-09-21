using GeometryCalculator;

Console.Write("Enter the type of the geometric figure ([r]ectangle, [c]ircle, [t]riangle, [e]llipse): ");
var figureType = Console.ReadLine()!;

// We have a circle OR a rectangle OR a triangle. Therefore, we use the
// questionmark after the type. This indicates that the variable can contain
// an instance of a class (e.g. circle) OR null (=nothing).
Circle? c = null;
Rectangle? r = null;
Triangle? t = null;
Ellipse? e = null;

switch (figureType)
{
    case "r":
        // Ask the user for rectangle arguments
        Console.Write("Enter the width of the rectangle: ");
        var width = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the height of the rectangle: ");
        var rectHeight = double.Parse(Console.ReadLine()!);

        // Create the rectangle
        r = new Rectangle(width, rectHeight);
        break;
    case "c":
        // Ask the user for circle arguments
        Console.Write("Enter the radius of the circle: ");
        var radius = double.Parse(Console.ReadLine()!);

        // Create the circle
        c = new Circle(radius);
        break;
    case "t":
        // Ask the user for triangle arguments
        Console.Write("Enter the base of the triangle: ");
        var baseLength = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the height of the triangle: ");
        var triangleHeight = double.Parse(Console.ReadLine()!);

        // Create the triangle
        t = new Triangle(baseLength, triangleHeight);
        break;
    case "e":
        // Ask the user for ellipse arguments
        Console.Write("Enter the longest radius of the ellipse: ");
        var longestRadius = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the shortest radius of the ellips: ");
        var shortestRadius = double.Parse(Console.ReadLine()!);

        // Create the triangle
        e = new Ellipse(longestRadius, shortestRadius);
        break;
    default:
        Console.WriteLine("Invalid figure type.");
        return;
}

Console.Write("Enter the factor: ");
var factor = double.Parse(Console.ReadLine()!);

switch (figureType)
{
    case "r" when r != null:
        {
            Console.WriteLine($"The original area of the rectangle is {r.Area}.");
            r.Scale(factor);
            Console.WriteLine($"The new area of the rectangle with width = {r.Width} and height = {r.Height} is {Math.Round(r.Area, 3)}.");
            break;
        }
    case "c" when c != null:
        {
            Console.WriteLine($"The original area of the circle is {c.Area}.");
            c.Scale(factor);
            Console.WriteLine($"The new area of the circle with radius = {c.Radius} is {Math.Round(c.Area, 3)}.");
            break;
        }
    case "t" when t != null:
        {
            Console.WriteLine($"The original area of the triangle is {t.Area}.");
            t.Scale(factor);
            Console.WriteLine($"The new area of the triangle with base = {t.BaseLength} and height = {t.Height} is {Math.Round(t.Area, 3)}.");
            break;
        }
    case "e" when e != null:
        {
            Console.WriteLine($"The original area of the ellipse is {e.Area}.");
            e.Scale(factor);
            Console.WriteLine($"The new area of the ellipse with longest radius = {e.LongestRadius} and shortest radius = {e.ShortestRadius} is {Math.Round(e.Area, 3)}.");
            break;
        }
    default:
        Console.WriteLine("Invalid figure type.");
        break;
}
