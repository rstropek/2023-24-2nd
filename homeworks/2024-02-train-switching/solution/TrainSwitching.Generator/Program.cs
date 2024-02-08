using static TrainSwitching.Logic.Constants;

if (args.Length != 1 || !int.TryParse(args[0], out var numberOfRecords))
{
    Console.WriteLine("Number of records to generate missing");
    return;
}

using var stream = new FileStream("switching.dat", FileMode.Create);
using var binaryFile = new BinaryWriter(stream);

for(var i = 0; i < numberOfRecords; i++)
{
    var track = Random.Shared.Next(1, 11);

    // 50% chance of adding a wagon
    // 30% chance of removing wagon(s)
    // 20% chance of train leaving
    var operationType = Random.Shared.Next(1, 11) switch
    {
        var x when x <= 6 => OPERATION_ADD,
        var x when x <= 9 => OPERATION_REMOVE,
        _ => OPERATION_TRAIN_LEAVE
    };

    var direction = Random.Shared.Next(1, 3) switch
    {
        1 => "East",
        _ => "West"
    };

    var wagonType = Random.Shared.Next(1, 5) switch
    {
        1 => "Passenger Wagon",
        2 => "Locomotive",
        3 => "Freight Wagon",
        _ => "Car Transport Wagon"
    };

    var numberOfWagons = operationType == OPERATION_REMOVE ? Random.Shared.Next(1, 6) : 0;

    Console.Write($"At track {track}, ");
    Console.WriteLine(operationType switch
    {
        OPERATION_ADD => $"add {wagonType} from {direction}",
        OPERATION_REMOVE => $"remove {numberOfWagons} wagon{(numberOfWagons > 1 ? "s" : "")} from {direction}",
        _ => $"train leaves to {direction}"
    });

    // 4 bits for track number
    var byte1 = (byte)track;
    byte1 <<= 4;

    // 4 bits for operation type
    byte1 |= (byte)operationType;

    // 1 bit for direction
    var byte2 = direction == "East" ? (byte)0 : (byte)1;

    byte2 <<= 7;

    // if operation is add, 7 bits for wagon type
    // if operation is remove, 7 bits for number of wagons
    // if operation is train leave, 7 zero bits
    if (operationType == OPERATION_ADD)
    {
        byte2 |= wagonType switch
        {
            "Passenger Wagon" => (byte)1,
            "Locomotive" => (byte)2,
            "Freight Wagon" => (byte)3,
            _ => (byte)4
        };
    }
    else if (operationType == OPERATION_REMOVE)
    {
        byte2 |= (byte)numberOfWagons;
    }

    binaryFile.Write(byte1);
    binaryFile.Write(byte2);
}