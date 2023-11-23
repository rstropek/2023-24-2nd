string filePath = "operations.txt";
var operations = File.ReadAllLines(filePath);
var warehouse = new Warehouse();
int moveCount = 0;

foreach (var operation in operations)
{
    var parts = operation.Split(' ');
    switch (parts[0].ToLower())
    {
        case "incoming":
            warehouse.Incoming(parts[1]); // Process incoming operation
            moveCount++; // Increment move count for each incoming operation
            break;

        case "shipping":
            // Process shipping operation. The shipping method returns the 
            // number of box movements.
            moveCount += warehouse.Shipping(parts[1]);
            break;
    }

    Console.WriteLine();
    Console.WriteLine(operation);
    Console.WriteLine(warehouse);
    Console.WriteLine($"Box movements: {moveCount}");
}

Console.WriteLine($"\nTotal box movements: {moveCount}");
