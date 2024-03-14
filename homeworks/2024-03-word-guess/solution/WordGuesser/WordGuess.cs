using System.Text;

namespace WordGuesser;

public class WordGuess
{
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

    protected string WordToGuess { get; }

    public string CurrentGuess { get; protected set; }

    public WordGuess()
    {
        WordToGuess = GetRandomWord();
        CurrentGuess = GetInitialGuess();
    }

    public bool Completed => CurrentGuess == WordToGuess;

    public virtual string GetRandomWord()
    {
        return Random.Shared.GetItems(AvailableWords, 1)[0];
    }

    public virtual string GetInitialGuess()
    {
        var builder = new StringBuilder(WordToGuess.Length);
        foreach (var c in WordToGuess)
        {
            builder.Append(c == ' ' ? ' ' : '_');
        }

        return builder.ToString();
    }

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

public class EasyWordGuess : WordGuess
{
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
            } while (letter == ' ' || revealed.Contains(letter));

            revealed.Add(letter);
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

public class HardWordGuess : WordGuess
{
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
