using WordGuesser;

namespace WordGuesser.Tests;

public class WordGuessMockSingleWord : WordGuess
{
    public override string GetRandomWord() => "Test";
}

public class WordGuessMockWordGroup : WordGuess
{
    public override string GetRandomWord() => "Test Test";
}

public class NormalGuessTests
{
    [Fact]
    public void WordGuess_InitializesCurrentGuess_SingleWord()
    {
        // Arrange
        var wordGuess = new WordGuessMockSingleWord();

        // Act
        var currentGuess = wordGuess.CurrentGuess;

        // Assert
        Assert.Equal("____", currentGuess);
    }

    [Fact]
    public void WordGuess_InitializesCurrentGuess_WordGroup()
    {
        // Arrange
        var wordGuess = new WordGuessMockWordGroup();

        // Act
        var currentGuess = wordGuess.CurrentGuess;

        // Assert
        Assert.Equal("____ ____", currentGuess);
    }

    [Fact]
    public void WordGuess_Guess_ReturnsTrue()
    {
        // Arrange
        var wordGuess = new WordGuessMockSingleWord();

        // Act
        var result = wordGuess.Guess('t');

        // Assert
        Assert.True(result);
        Assert.Equal("T__t", wordGuess.CurrentGuess);
    }

    [Fact]
    public void WordGuess_Guess_ReturnsFalse()
    {
        // Arrange
        var wordGuess = new WordGuessMockSingleWord();

        // Act
        var result = wordGuess.Guess('z');

        // Assert
        Assert.False(result);
        Assert.Equal("____", wordGuess.CurrentGuess);
    }
}