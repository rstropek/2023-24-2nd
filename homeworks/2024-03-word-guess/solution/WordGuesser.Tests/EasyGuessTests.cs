using WordGuesser;

namespace WordGuesser.Tests;

public class EasyWordGuessMockSingleWord : EasyWordGuess
{
    public override string GetRandomWord() => "Snowmobile";
}

public class EasyWordGuessMockShort : EasyWordGuess
{
    public override string GetRandomWord() => "Eat";
}

public class EasyNormalGuessTests
{
    [Fact]
    public void EasyWordGuess_InitializesCurrentGuess_NormalWord()
    {
        // Arrange
        var wordGuess = new EasyWordGuessMockSingleWord();

        // Act
        var currentGuess = wordGuess.CurrentGuess;

        // Assert
        var chars = new HashSet<char>();
        foreach (var c in currentGuess)
        {
            chars.Add(c);
        }

        Assert.Equal(4, chars.Count);           
    }

    [Fact]
    public void EasyWordGuess_InitializesCurrentGuess_ShortWord()
    {
        // Arrange
        var wordGuess = new EasyWordGuessMockShort();

        // Act
        var currentGuess = wordGuess.CurrentGuess;

        // Assert
        Assert.Equal("___", currentGuess);
    }
}