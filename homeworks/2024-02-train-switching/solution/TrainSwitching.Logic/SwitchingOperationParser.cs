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

    /// <summary>
    /// Parses the given input bytes into a SwitchingOperation.
    /// </summary>
    /// <param name="inputBytes">Input bytes, structure see comments below</param>
    /// <returns>Switching operation</returns>
    public static SwitchingOperation Parse(byte[] inputBytes)
    {
        // inputBytes[0]:
        // * 4 bits for track number
        // * 4 bits for operation type
        // inputBytes[1]:
        // * 1 bit for direction
        // * Last 7 bits:
        //   * if operation is add, 7 bits for wagon type
        //   * if operation is remove, 7 bits for number of wagons
        //   * if operation is train leave, 7 zero bits

        var byte1 = inputBytes[0];
        var byte2 = inputBytes[1];

        var operation = new SwitchingOperation
        {
            TrackNumber = byte1 >> 4,
            OperationType = byte1 & 0b00001111,
            Direction = (byte2 >> 7) == 0 ? Constants.DIRECTION_EAST : Constants.DIRECTION_WEST
        };

        if (operation.OperationType == Constants.OPERATION_ADD)
        {
            operation.WagonType = byte2 & 0b01111111;
        }
        else if (operation.OperationType == Constants.OPERATION_REMOVE)
        {
            operation.NumberOfWagons = byte2 & 0b01111111;
        }

        return operation;
    }

}