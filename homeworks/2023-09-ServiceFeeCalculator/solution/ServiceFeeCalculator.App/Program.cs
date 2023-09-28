// Ask the user for all necessary data (e.g. type of repair job, description, start and end date and time, etc.)
// Create an instance of the appropriate class
// Call `CalculateFee()` and print the result to the console

using ServiceFeeCalculator.Level1;

// Note that there is no sample solution for the app for level 2 and up.
// You have to come up with your own solution.

Console.Write("Type of repair job (basic, regular, complex): ");
var type = Console.ReadLine()!;

Console.Write("Description: ");
var description = Console.ReadLine()!;

Console.Write("Start date and time (yyyy-MM-ddTHH:mm:ss): ");
var start = DateTime.Parse(Console.ReadLine()!);

Console.Write("End date and time (yyyy-MM-ddTHH:mm:ss): ");
var end = DateTime.Parse(Console.ReadLine()!);

// Note the switch expression here. Alternatively, you can use
// a switch statement or if-else-if-else.
RepairJob job = type switch
{
    "basic" => new BasicRepairJob(),
    "regular" => new RegularRepairJob(),
    "complex" => new ComplexRepairJob(),
    _ => throw new ArgumentException("Invalid type of repair job.")
};

job.Description = description;
job.Start = start;
job.End = end;

Console.WriteLine($"Fee: {job.CalculateFee():C}");
