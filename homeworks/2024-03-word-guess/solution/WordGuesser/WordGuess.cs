using System.Text;

namespace WordGuesser;

/// <summary>
/// Represents a word guessing game
/// </summary>
public class WordGuess
{
    /// <summary>
    /// The list of available words to guess.
    /// </summary>
    private static readonly string[] AvailableWords = [
        "Snowflakes",
        "Frostbite",
        "Snowboarding",
        "Ice skating",
        "Thermometer",
        "Snowmobile",
        "Hibernation",
        "Blizzard",
        "Wintercoat",
        "Fireplace",
        "Snowstorm",
        "Ice fishing",
        "Scarves",
        "Frostwork",
        "Windchill",
        "Snowshoes",
        "Ice crystals",
        "Freezing rain",
        "Snowplough",
        "Antifreeze"
    ];

    /// <summary>
    /// Gets the word to guess.
    /// </summary>
    /// <remarks>
    /// Note that this property is `protected`. That means that only itself and
    /// derived classes can access it. It cannot be accessed from outside the class.
    /// </remarks>
    protected string WordToGuess { get; }

    /// <summary>
    /// Gets the current guess.
    /// </summary>
    /// <remarks>
    /// The current guess is the word to guess but with the letters that have not been
    /// guessed yet replaced by underscores. Note that the setter of this property
    /// is `protected`. That means that only itself and derived classes can access it.
    /// The getter is public. So it can be accessed from outside the class.
    /// </remarks>
    public string CurrentGuess { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="WordGuess"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor picks a random word from <see cref="AvailableWords"/>  and
    /// stores it in <see cref="WordToGuess"/>. It then calls <see cref="GetInitialGuess"/>.
    public WordGuess()
    {
        WordToGuess = GetRandomWord();
        CurrentGuess = GetInitialGuess();
    }

    /// <summary>
    /// Gets a value indicating if the game is completed (i.e. all letter of the word have been guessed).
    /// </summary>
    public bool Completed => CurrentGuess == WordToGuess;

    /// <summary>
    /// Returns a random word from <see cref="AvailableWords"/>.
    /// </summary>
    /// <returns>Random word from <see cref="AvailableWords"/></returns>
    public virtual string GetRandomWord()
    {
        return Random.Shared.GetItems(AvailableWords, 1)[0];
    }

    /// <summary>
    /// Returns the initial guess.
    /// </summary>
    /// <returns>Initial guess</returns>
    /// <remarks>
    /// This method takes the current <see cref="WordToGuess"/> and replaces the
    /// letters with underscores. It keeps spaces as spaces. This implementation
    /// replaces all letters with underscores. Derived classes can override this
    /// method to provide a different initial guess.
    /// </remarks>
    public virtual string GetInitialGuess()
    {
        var builder = new StringBuilder(WordToGuess.Length);
        foreach (var c in WordToGuess)
        {
            builder.Append(c == ' ' ? ' ' : '_');
        }

        return builder.ToString();
    }

    /// <summary>
    /// Guesses a letter.
    /// </summary>
    /// <param name="letter">The guessed letter</param>
    /// <returns>True if the letter was found in the word; otherwise, false</returns>
    /// <remarks>
    /// This method takes a letter and checks if it is in the word. If it is, it
    /// replaces the corresponding underscores in <see cref="CurrentGuess"/> with
    /// the letter and returns true. If it is not, it returns false.
    /// This implementation is case-insensitive and it reveals all occurrences of
    /// the letter in the word. Derived classes can override this method to provide
    /// a different implementation.
    /// </remarks>
    public virtual bool Guess(char letter)
    {
        var found = false;
        var builder = new StringBuilder(CurrentGuess);
        for (var i = 0; i < WordToGuess.Length; i++)
        {
            if (char.ToLower(WordToGuess[i]) == char.ToLower(letter))
            {
                found = true;
                builder[i] = WordToGuess[i];
            }
        }

        CurrentGuess = builder.ToString();
        return found;
    }
}

/// <summary>
/// Represents a word guessing game with easy difficulty.
/// </summary>
/// <remarks>
/// In contrast to <see cref="WordGuess"/>, this class reveals three random letters
/// of the word to guess as the initial guess. Therefore, the user has to guess fewer
/// letters to complete the word.
/// </remarks>
public class EasyWordGuess : WordGuess
{
    /// <summary>
    /// Returns the initial guess.
    /// </summary>
    /// <returns>Initial guess</returns>
    /// <remarks>
    /// This method calls the base class's <see cref="WordGuess.GetInitialGuess"/>.
    /// After that, it reveals all occurrences of three different, randomly picked 
    /// letters of the word to guess. If the word to guess contains less than four 
    /// different letters, nothing is revealed.
    /// </remarks>
    public override string GetInitialGuess()
    {
        var builder = new StringBuilder(base.GetInitialGuess());
        var revealed = new HashSet<char>();

        var availableChars = new HashSet<char>(WordToGuess.ToLower());
        var numberOfAvailableChars = availableChars.Count;
        if (WordToGuess.Contains(' ')) { numberOfAvailableChars--; }
        if (numberOfAvailableChars <= 3) { return builder.ToString(); }

        for (var i = 0; i < 3; i++)
        {
            char letter;
            do
            {
                letter = WordToGuess[Random.Shared.Next(WordToGuess.Length)];
            } while (letter == ' ' || revealed.Contains(char.ToLower(letter)));

            revealed.Add(char.ToLower(letter));
            for (var j = 0; j < WordToGuess.Length; j++)
            {
                if (char.ToLower(WordToGuess[j]) == char.ToLower(letter))
                {
                    builder[j] = WordToGuess[j];
                }
            }
        }

        return builder.ToString();
    }
}

/// <summary>
/// Represents a word guessing game with hard difficulty.
/// </summary>
/// <remarks>
/// In contrast to <see cref="WordGuess"/>, this class does a
/// case-sensitive comparison when guessing letters. Additionally,
/// it reveals only the first occurrence of the guessed letter in
/// the word to guess.
/// </remarks>
public class HardWordGuess : WordGuess
{
    /// <summary>
    /// Guesses a letter.
    /// </summary>
    /// <param name="letter">The guessed letter</param>
    /// <returns>True if the letter was found in the word; otherwise, false</returns>
    /// <seealso cref="WordGuess.Guess(char)"/>
    /// <remarks>
    /// This implementation is case-sensitive and it reveals only the first occurrence of
    /// the letter in the word.
    /// </remarks>
    public override bool Guess(char letter)
    {
        for (var i = 0; i < WordToGuess.Length; i++)
        {
            if (WordToGuess[i] == letter)
            {
                CurrentGuess = CurrentGuess[..i] + letter + CurrentGuess[(i + 1)..];
                return true;
            }
        }

        return false;
    }
}
