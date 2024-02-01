namespace TrainSwitching.Logic;

public static class SwitchingOperationParser
{
    /// <summary>
    /// Parses a line of input into a <see cref="SwitchingOperation"/>.
    /// </summary>
    /// <param name="inputLine">Line to parse. See readme.md for details</param>
    /// <returns>The parsed switching operation</returns>
    public static SwitchingOperation Parse(string inputLine)
    {
        /*
        Examples:
            At track `<n>`, add Passenger Wagon from `<East|West>`
            At track `<n>`, add Locomotive from `<East|West>`
            At track `<n>`, add Freight Wagon from `<East|West>`
            At track `<n>`, add Car Transport Wagon from `<East|West>`
            At track `<n>`, remove `<m>` wagons from `<East|West>`
            At track `<n>`, train leaves to `<East|West>`
        */

        var operation = new SwitchingOperation();

        var parts = inputLine.Split(',', StringSplitOptions.TrimEntries);
        var trackNumberText = parts[0][(parts[0].LastIndexOf(' ') + 1)..];
        operation.TrackNumber = int.Parse(trackNumberText);

        var operationDetails = parts[1].Split(' ', StringSplitOptions.TrimEntries);

        operation.OperationType = operationDetails[0] switch
        {
            "add" => Constants.OPERATION_ADD,
            "remove" => Constants.OPERATION_REMOVE,
            "train" => Constants.OPERATION_TRAIN_LEAVE,
            _ => throw new InvalidOperationException($"Unknown operation type: {operationDetails[1]}")
        };

        operation.Direction = operationDetails[^1] switch
        {
            "East" => Constants.DIRECTION_EAST,
            "West" => Constants.DIRECTION_WEST,
            _ => throw new InvalidOperationException($"Unknown direction: {operationDetails[^1]}")
        };

        if (operation.OperationType == Constants.OPERATION_ADD)
        {
            operation.WagonType = operationDetails[1] switch
            {
                "Passenger" => Constants.WAGON_TYPE_PASSENGER,
                "Locomotive" => Constants.WAGON_TYPE_LOCOMOTIVE,
                "Freight" => Constants.WAGON_TYPE_FREIGHT,
                "Car" => Constants.WAGON_TYPE_CAR_TRANSPORT,
                _ => throw new InvalidOperationException($"Unknown wagon type: {operationDetails[2]}")
            };
        }
        else if (operation.OperationType == Constants.OPERATION_REMOVE)
        {
            operation.NumberOfWagons = int.Parse(operationDetails[1]);
        }

        return operation;
    }
}