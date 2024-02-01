using TrainSwitching.Logic;

if (args.Length != 1)
{
    Console.WriteLine("Please provide the path to the input file as the first argument.");
    return;
}

var lines = File.ReadAllLines(args[0]);
var station = new TrainStation();
var failingOperations = 0;
foreach(var line in lines)
{
    var op = SwitchingOperationParser.Parse(line);
    if (!station.TryApplyOperation(op))
    {
        failingOperations++;
    }
}

Console.WriteLine($"Number of failing operations: {failingOperations} ({(double)failingOperations / lines.Length:P2})");
Console.WriteLine($"Checksum at the end: {station.CalculateChecksum()}");
