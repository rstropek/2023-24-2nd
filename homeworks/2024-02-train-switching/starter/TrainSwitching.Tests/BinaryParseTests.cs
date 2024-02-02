using TrainSwitching.Logic;
using static TrainSwitching.Logic.Constants;

namespace TrainSwitching.Tests;

public class BinaryParseTests
{
    [Theory]
    [InlineData(new byte[] { 0b00010001, 0b00000001 }, 1, OPERATION_ADD, WAGON_TYPE_LOCOMOTIVE, DIRECTION_EAST, null)]
    [InlineData(new byte[] { 0b00100000, 0b10000000 }, 2, OPERATION_TRAIN_LEAVE, null, DIRECTION_WEST, null)]
    [InlineData(new byte[] { 0b00100010, 0b10000100 }, 2, OPERATION_REMOVE, null, DIRECTION_WEST, 4)]
    public void Parse_Binary(byte[] inputBytes, int track, int operationType, int? wagonType, int direction, int? numberOfWagons)
    {
        var operation = SwitchingOperationParser.Parse(inputBytes);

        Assert.Equal(track, operation.TrackNumber);
        Assert.Equal(operationType, operation.OperationType);
        Assert.Equal(wagonType, operation.WagonType);
        Assert.Equal(direction, operation.Direction);
        Assert.Equal(numberOfWagons, operation.NumberOfWagons);
    }
}