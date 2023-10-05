using GeometryCalculator;

Console.Write("Enter the type of the geometric figure ([r]ectangle, [c]ircle, [t]riangle, [e]llipse): ");
var figureType = Console.ReadLine()!;

Shape shape;
switch (figureType)
{
    case "r":
        Console.Write("Enter the width of the rectangle: ");
        var width = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the height of the rectangle: ");
        var height = double.Parse(Console.ReadLine()!);
        shape = new Rectangle(width, height);
        break;
    case "c":
        Console.Write("Enter the radius of the circle: ");
        var radius = double.Parse(Console.ReadLine()!);
        shape = new Circle(radius);
        break;
    case "t":
        Console.Write("Enter the base of the triangle: ");
        var baselength = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the height of the triangle: ");
        height = double.Parse(Console.ReadLine()!);
        shape = new Triangle(baselength, height);
        break;
    case "e":
        Console.Write("Enter the longest radius: ");
        var longestRadius = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the shortest radius: ");
        var shortestRadius = double.Parse(Console.ReadLine()!);
        shape = new Ellipse(longestRadius, shortestRadius);
        break;
    default:
        Console.WriteLine("Invalid figure type.");
        return;
}

Console.Write("Enter the factor: ");
var factor = double.Parse(Console.ReadLine()!);

Console.WriteLine($"The original area of the {shape} is {shape.Area}.");
shape.Scale(factor);
Console.WriteLine($"The new area of the {shape} is {Math.Round(shape.Area, 3)}.");
