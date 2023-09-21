using GeometryCalculator;

Console.Write("Enter the type of the geometric figure ([r]ectangle, [c]ircle, [t]riangle, [e]llipse): ");
var figureType = Console.ReadLine()!;

double width = 0d, height = 0d, radius = 0d, baselength = 0d, longestRadius = 0d, shortestRadius = 0d;
switch (figureType)
{
    case "r":
        Console.Write("Enter the width of the rectangle: ");
        width = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the height of the rectangle: ");
        height = double.Parse(Console.ReadLine()!);
        break;
    case "c":
        Console.Write("Enter the radius of the circle: ");
        radius = double.Parse(Console.ReadLine()!);
        break;
    case "t":
        Console.Write("Enter the base of the triangle: ");
        baselength = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the height of the triangle: ");
        height = double.Parse(Console.ReadLine()!);
        break;
    case "e":
        Console.Write("Enter the longest radius: ");
        longestRadius = double.Parse(Console.ReadLine()!);
        Console.Write("Enter the shortest radius: ");
        shortestRadius = double.Parse(Console.ReadLine()!);
        break;
    default:
        Console.WriteLine("Invalid figure type.");
        return;
}

Console.Write("Enter the factor: ");
var factor = double.Parse(Console.ReadLine()!);

switch (figureType)
{
    case "r":
        {
            var rect = new Rectangle(width, height);
            Console.WriteLine($"The original area of the rectangle is {rect.Area}.");
            rect.Scale(factor);
            Console.WriteLine($"The new area of the rectangle with width = {rect.Width} and height = {rect.Height} is {Math.Round(rect.Area, 3)}.");
            break;
        }
    case "c":
        {
            var circle = new Circle(radius);
            Console.WriteLine($"The original area of the circle is {circle.Area}.");
            circle.Scale(factor);
            Console.WriteLine($"The new area of the circle with radius = {circle.Radius} is {Math.Round(circle.Area, 3)}.");
            break;
        }
    case "t":
        {
            var triangle = new Triangle(baselength, height);
            Console.WriteLine($"The original area of the triangle is {triangle.Area}.");
            triangle.Scale(factor);
            Console.WriteLine($"The new area of the triangle with base = {triangle.BaseLength} and height = {triangle.Height} is {Math.Round(triangle.Area, 3)}.");
            break;
        }
    case "e":
        {
            var ellipse = new Ellipse(longestRadius, shortestRadius);
            Console.WriteLine($"The original area of the ellipse is {ellipse.Area}.");
            ellipse.Scale(factor);
            Console.WriteLine($"The new area of the ellipse with longest radius = {ellipse.LongestRadius} and shortest radius = {ellipse.ShortestRadius} is {Math.Round(ellipse.Area, 3)}.");
            break;
        }
    default:
        Console.WriteLine("Invalid figure type.");
        break;
}
