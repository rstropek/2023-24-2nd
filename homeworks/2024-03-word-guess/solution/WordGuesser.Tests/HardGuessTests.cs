namespace WordGuesser.Tests;

public class HardWordGuessMockSingleWord : HardWordGuess
{
    public override string GetRandomWord() => "Snowspacemobile";
}

public class HardNormalGuessTests
{
    [Fact]
    public void HardWordGuess_CaseSensitive()
    {
        // Arrange
        var wordGuess = new HardWordGuessMockSingleWord();

        // Act
        var result = wordGuess.Guess('s');

        // Assert
        Assert.True(result);
        Assert.Equal("____s__________", wordGuess.CurrentGuess);
    }

    [Fact]
    public void HardWordGuess_OnlyRevealsFirst()
    {
        // Arrange
        var wordGuess = new HardWordGuessMockSingleWord();

        // Act
        var result = wordGuess.Guess('o');

        // Assert
        Assert.True(result);
        Assert.Equal("__o____________", wordGuess.CurrentGuess);
    }
}