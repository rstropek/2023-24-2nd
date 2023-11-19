using System.Text;

var garage = new Garage();

Console.WriteLine("What do you want to do?");
Console.WriteLine("1) Enter a car entry");
Console.WriteLine("2) Enter a car exit");
Console.WriteLine("3) Generate report");
Console.WriteLine("4) Exit");

while (true) // Infinite loop for continuous operation
{
    Console.Write("\nYour selection: ");
    var selection = Console.ReadLine()!;

    switch (selection)
    {
        case "1": EnterCarEntry(garage); break;
        case "2": EnterCarExit(garage); break;
        case "3": Console.WriteLine(garage.GenerateReport()); break;
        case "4": Console.WriteLine("Good bye!"); return;
        default: Console.WriteLine("Invalid selection. Please try again."); break;
    }
}

void EnterCarEntry(Garage garage)
{
    Console.Write("Enter parking spot number: ");
    int spotNumber = int.Parse(Console.ReadLine()!);
    if (garage.IsOccupied(spotNumber))
    {
        Console.WriteLine("Parking spot is occupied");
        return;
    }

    Console.Write("Enter license plate: ");
    string licensePlate = Console.ReadLine()!;
    Console.Write("Enter entry date/time (e.g. 2023-09-02T08:05:00): ");
    DateTime entryTime = DateTime.Parse(Console.ReadLine()!);

    if (garage.TryOccupy(spotNumber, licensePlate, entryTime))
    {
        Console.WriteLine("Car entry recorded.");
    }
}

void EnterCarExit(Garage garage)
{
    Console.Write("Enter parking spot number: ");
    int spotNumber = int.Parse(Console.ReadLine()!);
    if (!garage.IsOccupied(spotNumber))
    {
        Console.WriteLine("Parking spot is not occupied");
        return;
    }

    Console.Write("Enter exit date/time (e.g. 2023-09-02T11:15:00): ");
    DateTime exitTime = DateTime.Parse(Console.ReadLine()!);

    if (garage.TryExit(spotNumber, exitTime, out decimal costs))
    {
        Console.WriteLine($"Costs are {costs}€");
    }
}

public class ParkingSpot
{
    // Properties with 'get' accessors only, making them immutable after construction
    public string LicensePlate { get; }
    public DateTime EntryDate { get; }

    // Constructor to initialize properties
    public ParkingSpot(string licensePlate, DateTime entryDate)
    {
        LicensePlate = licensePlate;
        EntryDate = entryDate;
    }
}

public class Garage
{
    // Array declaration - fixed size array to store ParkingSpot objects
    public ParkingSpot?[] ParkingSpots { get; } = new ParkingSpot[50];

    // '=>' is a lambda expression, used here for a concise single-line method
    public bool IsOccupied(int parkingSpotNumber) => ParkingSpots[parkingSpotNumber - 1] != null;

    // Method demonstrating basic control flow and array manipulation
    public bool TryOccupy(int parkingSpotNumber, string licensePlate, DateTime entryTime)
    {
        // Array indexing, 0-based (hence the -1)
        // The 'if' condition checks for null (null handling)
        if (IsOccupied(parkingSpotNumber)) { return false; }
        ParkingSpots[parkingSpotNumber - 1] = new ParkingSpot(licensePlate, entryTime);
        return true;
    }

    // Method using 'out' parameter to return multiple values
    public bool TryExit(int parkingSpotNumber, DateTime exitTime, out decimal costs)
    {
        costs = 0;
        if (!IsOccupied(parkingSpotNumber)) { return false; }

        // Null-forgiving operator '!' is used because we're sure the element is not null here
        var entryTime = ParkingSpots[parkingSpotNumber - 1]!.EntryDate;
        var duration = exitTime - entryTime;

        // TimeSpan usage for time manipulation
        if (duration.TotalMinutes <= 15) // Free within 15 minutes
        {
            ParkingSpots[parkingSpotNumber - 1] = null;
            return true;
        }

        costs = CalculateCosts(duration);
        ParkingSpots[parkingSpotNumber - 1] = null;
        return true;
    }

    // Static method, not tied to a specific instance of Garage
    private static decimal CalculateCosts(TimeSpan duration)
    {
        int halfHours = (int)Math.Ceiling(duration.TotalMinutes / 30);
        return halfHours * 3; // 3€ per started half hour
    }

    // StringBuilder for efficient string concatenation in a loop
    public string GenerateReport()
    {
        var report = new StringBuilder();
        report.AppendLine("| Spot | License Plate |");
        report.AppendLine("| ---- | ------------- |");
        for (int i = 0; i < ParkingSpots.Length; i++)
        {
            // ?? operator to replace null with empty string
            var spotInfo = ParkingSpots[i]?.LicensePlate ?? string.Empty;
            // String interpolation and format specifiers for alignment
            report.AppendLine($"| {i + 1,4} | {spotInfo,-13} |");
        }
        
        return report.ToString();
    }
}
