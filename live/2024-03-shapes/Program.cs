Console.BackgroundColor = ConsoleColor.Black;
Console.CursorVisible = false;
Console.Clear();

var stroke = new Color(ConsoleColor.White, ConsoleColor.Red, ' ');

var shapes = new List<Shape>
{
     // new Line(new(3, 3), new(6, 4), stroke),
     // new Line(new(6, 6), new(9, 9), stroke),
    // new Polygon([new(0, 0), new(15, 0), new(15, 12), new(0, 12)], false, stroke),
    // new Polygon([new(20, 0), new(25, 5), new(20, 10), new(15, 5)], false, stroke),
    new Circle(new(30, 10), 10, 10, stroke),
};
shapes.Add(new Rectangle(shapes[0].GetBoundingRect(), new Color(ConsoleColor.White, ConsoleColor.Black, '*')));

foreach (var shape in shapes)
{
    shape.Draw();
}

Console.ReadKey();
Console.CursorVisible = true;

Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
Console.Clear();

record struct Point2D(int X, int Y);
record struct Rect2D(Point2D TopLeft, Point2D BottomRight);
record struct Color(ConsoleColor Foreground, ConsoleColor Background, char Symbol);

abstract class Shape(Color stroke)
{
    protected Color Stroke { get; } = stroke;

    public abstract void Draw();

    public abstract Rect2D GetBoundingRect();
}

class Line : Shape
{
    public Point2D[] Points { get; }
    private readonly Point2D start;
    private readonly Point2D end;

    public Line(Point2D start, Point2D end, Color stroke) : base(stroke)
    {
        this.start = start;
        this.end = end;

        // Draw all the intermediate points.
        int dx = end.X - start.X;
        int dy = end.Y - start.Y;
        int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
        float xIncrement = (float)dx / steps;
        float yIncrement = (float)dy / steps;

        Points = new Point2D[steps + 1];
        Points[0] = start;
        float x = start.X;
        float y = start.Y;
        for (int i = 1; i <= steps; i++)
        {
            x += xIncrement;
            y += yIncrement;
            Points[i] = new Point2D((int)Math.Round(x), (int)Math.Round(y));
        }
    }

    public override void Draw()
    {
        Console.BackgroundColor = Stroke.Background;
        Console.ForegroundColor = Stroke.Foreground;
        foreach (var point in Points)
        {
            if (point.X < 0 || point.X >= Console.WindowWidth || point.Y < 0 || point.Y >= Console.WindowHeight)
            {
                continue;
            }

            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(Stroke.Symbol);
        }
    }

    public override Rect2D GetBoundingRect()
    {
        int minX = Math.Min(start.X, end.X);
        int minY = Math.Min(start.Y, end.Y);
        int maxX = Math.Max(start.X, end.X);
        int maxY = Math.Max(start.Y, end.Y);

        return new Rect2D(new Point2D(minX, minY), new Point2D(maxX, maxY));
    }
}

class Polygon : Shape
{
    private Line[] Lines { get; }
    public Polygon(Point2D[] points, bool isOpen, Color stroke) : base(stroke)
    {
        Lines = new Line[points.Length - (isOpen ? 1 : 0)];
        for (int i = 0; i < points.Length - 1; i++)
        {
            Lines[i] = new Line(points[i], points[i + 1], stroke);
        }

        if (!isOpen)
        {
            Lines[^1] = new Line(points[^1], points[0], stroke);
        }
    }

    public override void Draw()
    {
        foreach (var line in Lines)
        {
            line.Draw();
        }
    }

    public override Rect2D GetBoundingRect()
    {
        int minX = int.MaxValue;
        int minY = int.MaxValue;
        int maxX = int.MinValue;
        int maxY = int.MinValue;

        foreach (var line in Lines)
        {
            var rect = line.GetBoundingRect();
            minX = Math.Min(minX, rect.TopLeft.X);
            minY = Math.Min(minY, rect.TopLeft.Y);
            maxX = Math.Max(maxX, rect.BottomRight.X);
            maxY = Math.Max(maxY, rect.BottomRight.Y);
        }

        return new Rect2D(new Point2D(minX, minY), new Point2D(maxX, maxY));
    }
}

class Rectangle(Point2D topLeft, Point2D bottomRight, Color stroke)
    : Polygon([topLeft, new(bottomRight.X, topLeft.Y),
        bottomRight, new(topLeft.X, bottomRight.Y)], false, stroke)
{
    public Rectangle(Rect2D rect, Color stroke) : this(rect.TopLeft, rect.BottomRight, stroke)
    {
    }
}

class Triangle(Point2D a, Point2D b, Point2D c, Color stroke) : Polygon([a, b, c], false, stroke)
{
}

// class Circle : Shape
// {
//     private readonly Polygon approximatedCircle;

//     public Circle(Point2D center, int radius, int tessalation, Color stroke) : base(stroke)
//     {
//         var points = new Point2D[tessalation];

//         for (int i = 0; i < tessalation; i++)
//         {
//             double angle = 2 * Math.PI * i / tessalation - Math.PI / 2;
//             points[i] = new Point2D(
//                 center.X + (int)Math.Round(radius * Math.Cos(angle)),
//                 center.Y + (int)Math.Round(radius * Math.Sin(angle))
//             );
//         }

//         approximatedCircle = new Polygon(points, false, stroke);
//     }

//     public override void Draw() => approximatedCircle.Draw();

//     public override Rect2D GetBoundingRect() => approximatedCircle.GetBoundingRect();
// }

class Ellipse : Shape
{
    private readonly Polygon approximatedEllipse;

    public Ellipse(Point2D center, int radiusX, int radiusY, int tessalation, Color stroke) : base(stroke)
    {
        var points = new Point2D[tessalation];

        for (int i = 0; i < tessalation; i++)
        {
            double angle = 2 * Math.PI * i / tessalation - Math.PI / 2;
            points[i] = new Point2D(
                center.X + (int)Math.Round(radiusX * Math.Cos(angle)),
                center.Y + (int)Math.Round(radiusY * Math.Sin(angle))
            );
        }

        approximatedEllipse = new Polygon(points, false, stroke);
    }

    public override void Draw() => approximatedEllipse.Draw();

    public override Rect2D GetBoundingRect() => approximatedEllipse.GetBoundingRect();
}

class Circle(Point2D center, int radius, int tessalation, Color stroke)
    : Ellipse(center, radius, radius, tessalation, stroke)
{
}
