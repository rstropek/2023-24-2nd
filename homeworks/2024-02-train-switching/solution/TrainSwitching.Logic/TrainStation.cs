namespace TrainSwitching.Logic;

public class TrainStation
{
    public Track[] Tracks { get; }
    
    public TrainStation()
    {
        Tracks = new Track[10];
        for (var i = 0; i < 10; i++)
        {
            Tracks[i] = new();
        }
    }

    /// <summary>
    /// Tries to apply the given operation to the train station.
    /// </summary>
    /// <param name="op">Operation to apply</param>
    /// <returns>Returns true if the operation could be applied, otherwise false</returns>
    public bool TryApplyOperation(SwitchingOperation op)
    {
        if (op.TrackNumber is < 1 or > 10) { return false; }

        if (op.TrackNumber is 9 or 10 && op.Direction == Constants.DIRECTION_EAST) { return false; }

        var track = Tracks[op.TrackNumber - 1];

        switch (op.OperationType)
        {
            case Constants.OPERATION_ADD:
                if (op.Direction == Constants.DIRECTION_EAST)
                {
                    track.Wagons.Add(op.WagonType!.Value);
                }
                else
                {
                    track.Wagons.Insert(0, op.WagonType!.Value);
                }

                break;

            case Constants.OPERATION_REMOVE:
                if (op.NumberOfWagons > track.Wagons.Count) { return false; }

                if (op.Direction == Constants.DIRECTION_EAST)
                {
                    track.Wagons.RemoveRange(track.Wagons.Count - op.NumberOfWagons!.Value, op.NumberOfWagons.Value);
                }
                else
                {
                    track.Wagons.RemoveRange(0, op.NumberOfWagons!.Value);
                }

                break;

            case Constants.OPERATION_TRAIN_LEAVE:
                var hasLocomotive = false;
                foreach(var wagon in track.Wagons)
                {
                    if (wagon == Constants.WAGON_TYPE_LOCOMOTIVE)
                    {
                        hasLocomotive = true;
                        break;
                    }
                }

                if (!hasLocomotive) { return false; }

                track.Wagons.Clear();
                break;

            default:
                throw new InvalidOperationException($"Unknown operation type: {op.OperationType}");
        }

        return true;
    }

    /// <summary>
    /// Calculates the checksum of the train station.
    /// </summary>
    /// <returns>The calculated checksum</returns>
    /// <remarks>
    /// See readme.md for details on how to calculate the checksum.
    /// </remarks>
    public int CalculateChecksum()
    {
        var checksum = 0;
        for (var i = 0; i < 10; i++)
        {
            var track = Tracks[i];
            var trackValue = 0;
            foreach (var wagon in track.Wagons)
            {
                trackValue += wagon switch
                {
                    Constants.WAGON_TYPE_PASSENGER => 1,
                    Constants.WAGON_TYPE_LOCOMOTIVE => 10,
                    Constants.WAGON_TYPE_FREIGHT => 20,
                    Constants.WAGON_TYPE_CAR_TRANSPORT => 30,
                    _ => throw new InvalidOperationException($"Unknown wagon type: {wagon}")
                };
            }

            trackValue *= i + 1;
            checksum += trackValue;
        }

        return checksum;
    }
}