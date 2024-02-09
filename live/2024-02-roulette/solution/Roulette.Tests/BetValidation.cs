using Roulette.Logic;

namespace Roulette.Tests;

public class BetTests
{
    [Fact]
    public void ValidBets()
    {
        var bet = new Bet(MultiNumberBetType.Street, [1, 2, 3]);
        Assert.True(bet.Validate());
        bet = new Bet(MultiNumberBetType.Street, [3, 2, 1]);
        Assert.True(bet.Validate());

        bet = new Bet(MultiNumberBetType.Split, [1, 2]);
        Assert.True(bet.Validate());
        bet = new Bet(MultiNumberBetType.Split, [2, 1]);
        Assert.True(bet.Validate());

        bet = new Bet(MultiNumberBetType.Square, [1, 2, 4, 5]);
        Assert.True(bet.Validate());
        bet = new Bet(MultiNumberBetType.Square, [1, 5, 4, 2]);
        Assert.True(bet.Validate());

        bet = new Bet(MultiNumberBetType.SixLine, [1, 2, 3, 4, 5, 6]);
        Assert.True(bet.Validate());
    }

    [Fact]
    public void InvalidBets()
    {
        var bet = new Bet(MultiNumberBetType.Street, [1, 2, 4]);
        Assert.False(bet.Validate());

        bet = new Bet(MultiNumberBetType.Split, [1, 3]);
        Assert.False(bet.Validate());

        bet = new Bet(MultiNumberBetType.Square, [1, 2, 3, 4]);
        Assert.False(bet.Validate());

        bet = new Bet(MultiNumberBetType.SixLine, [1, 2, 3, 4, 5, 7]);
        Assert.False(bet.Validate());
    }

    [Fact]
    public void Contains_ReturnsTrue_WhenHashSetExistsInList()
    {
        // Arrange
        List<HashSet<int>> list =
        [
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9]
        ];
        HashSet<int> numbers = [4, 5, 6];

        // Act
        var result = Bet.Contains(list, numbers);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Contains_ReturnsFalse_WhenHashSetDoesNotExistInList()
    {
        // Arrange
        List<HashSet<int>> list =
        [
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9]
        ];
        HashSet<int> numbers = [10, 11, 12];

        // Act
        var result = Bet.Contains(list, numbers);

        // Assert
        Assert.False(result);
    }
}