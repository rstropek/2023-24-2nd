using GeometryCalculator;

Console.Write("Enter the type of the geometric figure ([r]ectangle, [c]ircle, [t]riangle): ");
var figureType = Console.ReadLine()!;

double width = 0d, height = 0d, radius = 0d, baselength = 0d;
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
            var area = RectangleMath.CalculateArea(width, height);
            Console.WriteLine($"The original area of the rectangle is {area}.");
            var (scaledWidth, scaledHeight) = RectangleMath.CalculateScaledDimensions(width, height, factor);
            Console.WriteLine($"The new area of the rectangle with width = {scaledWidth} and height = {scaledHeight} is {Math.Round(RectangleMath.CalculateArea(scaledWidth, scaledHeight), 3)}.");
            break;
        }
    case "c":
        {
            var area = CircleMath.CalculateArea(radius);
            Console.WriteLine($"The original area of the circle is {area}.");
            var scaledRadius = CircleMath.CalculateScaledDimensions(radius, factor);
            Console.WriteLine($"The new area of the circle with radius = {scaledRadius} is {Math.Round(CircleMath.CalculateArea(scaledRadius), 3)}.");
            break;
        }
    case "t":
        {
            var area = TriangleMath.CalculateArea(baselength, height);
            Console.WriteLine($"The original area of the triangle is {area}.");
            var (scaledBaselength, scaledHeight) = TriangleMath.CalculateScaledDimensions(baselength, height, factor);
            Console.WriteLine($"The new area of the triangle with base = {scaledBaselength} and height = {scaledHeight} is {Math.Round(TriangleMath.CalculateArea(scaledBaselength, scaledHeight), 3)}.");
            break;
        }
    default:
        Console.WriteLine("Invalid figure type.");
        break;
}
