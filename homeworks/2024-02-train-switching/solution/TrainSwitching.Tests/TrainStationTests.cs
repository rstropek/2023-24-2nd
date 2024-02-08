using TrainSwitching.Logic;
using static TrainSwitching.Logic.Constants;

namespace TrainSwitching.Tests;

public class TrainStationTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(11)]
    public void TryApplyOperation_InvalidTrackNumber_ReturnsFalse(int trackNumber)
    {
        var station = new TrainStation();
        var op = new SwitchingOperation { TrackNumber = trackNumber };
        Assert.False(station.TryApplyOperation(op));
    }

    [Fact]
    public void TryApplyOperation_InvalidDirectionForTrack9And10_ReturnsFalse()
    {
        var station = new TrainStation();
        var op = new SwitchingOperation { TrackNumber = 9, Direction = DIRECTION_EAST };
        Assert.False(station.TryApplyOperation(op));
    }

    [Fact]
    public void TryApplyOperation_AddOperation_AddsWagonToTrack()
    {
        var station = new TrainStation();
        var op = new SwitchingOperation { TrackNumber = 1, OperationType = OPERATION_ADD, WagonType = WAGON_TYPE_FREIGHT, Direction = DIRECTION_EAST };
        Assert.True(station.TryApplyOperation(op));
        Assert.Contains(WAGON_TYPE_FREIGHT, station.Tracks[0].Wagons);
    }

    [Fact]
    public void TryApplyOperation_RemoveOperation_RemovesWagonFromTrack()
    {
        var station = new TrainStation();
        var addOp = new SwitchingOperation { TrackNumber = 1, OperationType = OPERATION_ADD, WagonType = WAGON_TYPE_FREIGHT, Direction = DIRECTION_EAST };
        Assert.True(station.TryApplyOperation(addOp));
        var removeOp = new SwitchingOperation { TrackNumber = 1, OperationType = OPERATION_REMOVE, NumberOfWagons = 1, Direction = DIRECTION_EAST };
        Assert.True(station.TryApplyOperation(removeOp));
        Assert.DoesNotContain(WAGON_TYPE_FREIGHT, station.Tracks[0].Wagons);
    }

    [Fact]
    public void TryApplyOperation_RemoveOperation_TooManyWagons()
    {
        var station = new TrainStation();
        var addOp = new SwitchingOperation { TrackNumber = 1, OperationType = OPERATION_ADD, WagonType = WAGON_TYPE_FREIGHT, Direction = DIRECTION_EAST };
        Assert.True(station.TryApplyOperation(addOp));
        var removeOp = new SwitchingOperation { TrackNumber = 1, OperationType = OPERATION_REMOVE, NumberOfWagons = 2, Direction = DIRECTION_EAST };
        Assert.False(station.TryApplyOperation(removeOp));
        Assert.Contains(WAGON_TYPE_FREIGHT, station.Tracks[0].Wagons);
    }

    [Fact]
    public void TryApplyOperation_RemoveOperation_RemovesFromRightDirection()
    {
        var station = new TrainStation();
        var addOp = new SwitchingOperation { TrackNumber = 1, OperationType = OPERATION_ADD, WagonType = WAGON_TYPE_FREIGHT, Direction = DIRECTION_EAST };
        Assert.True(station.TryApplyOperation(addOp));
        addOp = new SwitchingOperation { TrackNumber = 1, OperationType = OPERATION_ADD, WagonType = WAGON_TYPE_CAR_TRANSPORT, Direction = DIRECTION_EAST };
        Assert.True(station.TryApplyOperation(addOp));
        var removeOp = new SwitchingOperation { TrackNumber = 1, OperationType = OPERATION_REMOVE, NumberOfWagons = 1, Direction = DIRECTION_WEST };
        Assert.True(station.TryApplyOperation(removeOp));
        Assert.DoesNotContain(WAGON_TYPE_FREIGHT, station.Tracks[0].Wagons);
        Assert.Contains(WAGON_TYPE_CAR_TRANSPORT, station.Tracks[0].Wagons);
    }

    [Fact]
    public void TryApplyOperation_TrainLeaveOperation_ClearsTrack()
    {
        var station = new TrainStation();
        var addOp = new SwitchingOperation { TrackNumber = 1, OperationType = OPERATION_ADD, WagonType = WAGON_TYPE_LOCOMOTIVE, Direction = DIRECTION_EAST };
        station.TryApplyOperation(addOp);
        var leaveOp = new SwitchingOperation { TrackNumber = 1, OperationType = OPERATION_TRAIN_LEAVE };
        Assert.True(station.TryApplyOperation(leaveOp));
        Assert.Empty(station.Tracks[0].Wagons);
    }

    [Fact]
    public void TryApplyOperation_TrainLeaveOperation_NoLocomotive_ReturnsFalse()
    {
        var station = new TrainStation();
        var addOp = new SwitchingOperation { TrackNumber = 1, OperationType = OPERATION_ADD, WagonType = WAGON_TYPE_PASSENGER, Direction = DIRECTION_EAST };
        station.TryApplyOperation(addOp);
        var leaveOp = new SwitchingOperation { TrackNumber = 1, OperationType = OPERATION_TRAIN_LEAVE };
        Assert.False(station.TryApplyOperation(leaveOp));
        Assert.NotEmpty(station.Tracks[0].Wagons);
    }
}