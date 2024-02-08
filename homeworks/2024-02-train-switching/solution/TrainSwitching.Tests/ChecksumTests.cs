using TrainSwitching.Logic;
using static TrainSwitching.Logic.Constants;

namespace TrainSwitching.Tests;

public class ChecksumTests
{
    [Fact]
    public void CalculateChecksum_EmptyTracks_ReturnsZero()
    {
        var station = new TrainStation();
        Assert.Equal(0, station.CalculateChecksum());
    }

    [Theory]
    [InlineData(WAGON_TYPE_LOCOMOTIVE, 0)]
    [InlineData(WAGON_TYPE_FREIGHT, 0)]
    [InlineData(WAGON_TYPE_CAR_TRANSPORT, 0)]
    [InlineData(WAGON_TYPE_PASSENGER, 0)]
    [InlineData(WAGON_TYPE_LOCOMOTIVE, 5)]
    [InlineData(WAGON_TYPE_FREIGHT, 5)]
    [InlineData(WAGON_TYPE_CAR_TRANSPORT, 5)]
    [InlineData(WAGON_TYPE_PASSENGER, 5)]
    public void CalculateChecksum_SingleWagon(int wagonType, int track)
    {
        var station = new TrainStation();
        station.Tracks[track].Wagons.Add(wagonType);
        var expected = wagonType switch
        {
            WAGON_TYPE_LOCOMOTIVE => 10,
            WAGON_TYPE_FREIGHT => 20,
            WAGON_TYPE_CAR_TRANSPORT => 30,
            _ => 1,
        };
        Assert.Equal(expected * (track + 1), station.CalculateChecksum());
    }

    [Fact]
    public void CalculateChecksum_MultipleWagonsOnMultipleTracks_ReturnsCorrectValue()
    {
        var station = new TrainStation();
        station.Tracks[0].Wagons.Add(WAGON_TYPE_LOCOMOTIVE);
        station.Tracks[1].Wagons.Add(WAGON_TYPE_FREIGHT);
        station.Tracks[1].Wagons.Add(WAGON_TYPE_CAR_TRANSPORT);
        Assert.Equal(10 + 2 * (20 + 30), station.CalculateChecksum());
    }
}