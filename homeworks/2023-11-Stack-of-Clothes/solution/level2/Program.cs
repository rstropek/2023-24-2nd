string filePath = "operations.txt";
var operations = File.ReadAllLines(filePath);
var warehouse = new Warehouse();
int totalMoveCount = 0;

foreach (var operation in operations)
{
    var parts = operation.Split(' ');
    switch (parts[0].ToLower())
    {
        case "incoming":
            warehouse.Incoming(parts[1]);
            break;

        case "shipping":
            totalMoveCount += warehouse.Shipping(parts[1]);
            break;
    }

    Console.WriteLine();
    Console.WriteLine(operation);
    Console.WriteLine(warehouse);
}

Console.WriteLine($"Total box movements: {totalMoveCount}");
