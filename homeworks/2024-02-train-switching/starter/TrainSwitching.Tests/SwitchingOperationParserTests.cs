using TrainSwitching.Logic;
using static TrainSwitching.Logic.Constants;

namespace TrainSwitching.Tests;

public class SwitchingOperationParserTests
{
    [Theory]
    [InlineData("At track 1, add Passenger Wagon from East", 1, OPERATION_ADD, DIRECTION_EAST, WAGON_TYPE_PASSENGER, null)]
    [InlineData("At track 2, add Locomotive from East", 2, OPERATION_ADD, DIRECTION_EAST, WAGON_TYPE_LOCOMOTIVE, null)]
    [InlineData("At track 3, add Freight Wagon from West", 3, OPERATION_ADD, DIRECTION_WEST, WAGON_TYPE_FREIGHT, null)]
    [InlineData("At track 4, add Car Transport Wagon from West", 4, OPERATION_ADD, DIRECTION_WEST, WAGON_TYPE_CAR_TRANSPORT, null)]
    [InlineData("At track 5, remove 3 wagons from East", 5, OPERATION_REMOVE, DIRECTION_EAST, null, 3)]
    [InlineData("At track 6, train leaves to West", 6, OPERATION_TRAIN_LEAVE, DIRECTION_WEST, null, null)]
    public void ParseOperation(string line, int trackNumber, int operationType, int direction, int? wagonType, int? numberOfWagons)
    {
        var operation = SwitchingOperationParser.Parse(line);

        Assert.Equal(trackNumber, operation.TrackNumber);
        Assert.Equal(operationType, operation.OperationType);
        Assert.Equal(direction, operation.Direction);
        Assert.Equal(wagonType, operation.WagonType);
        Assert.Equal(numberOfWagons, operation.NumberOfWagons);
    }
}