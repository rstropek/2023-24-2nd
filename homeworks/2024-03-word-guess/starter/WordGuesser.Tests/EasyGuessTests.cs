namespace WordGuesser.Tests;

public class EasyWordGuessMockSingleWord : EasyWordGuess
{
    /// <summary>
    /// Gets the word to guess.
    /// </summary>
    /// <remarks>
    /// This method is overriden to return a single, fixed word instead
    /// of a random word. This is useful for testing purposes.
    /// </remarks>
    public override string GetRandomWord() => "Snowmobile";
}

public class EasyWordGuessMockShort : EasyWordGuess
{
    /// <summary>
    /// Gets the word to guess.
    /// </summary>
    /// <remarks>
    /// This method is overriden to return a single, fixed word instead
    /// of a random word. The word is short and only contains three
    /// different letters.
    public override string GetRandomWord() => "Eat";
}

public class EasyGuessTests
{
    [Fact]
    public void EasyWordGuess_InitializesCurrentGuess_NormalWord()
    {
        // Use the EasyWordGuessMockSingleWord class to test if
        // the CurrentGuess property is initialized correctly.
        // The test makes sure that exactly three different letters
        // are revealed in the initial guess.

        // TODO: Implement the requested logic
        throw new NotImplementedException();
    }

    [Fact]
    public void EasyWordGuess_InitializesCurrentGuess_ShortWord()
    {
        // Use the EasyWordGuessMockShort class to test if
        // the CurrentGuess property is initialized correctly.
        // The test makes sure that the initial guess contains only
        // underscores because the word to guess contains less than
        // four different letters.

        // TODO: Implement the requested logic
        throw new NotImplementedException();
    }
}