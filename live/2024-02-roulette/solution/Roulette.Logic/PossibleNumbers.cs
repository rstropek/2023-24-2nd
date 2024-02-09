namespace Roulette.Logic;

public class PossibleNumbers
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PossibleNumbers"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor must initialize all properties of this class.
    /// You MUST NOT simply write down all possible numbers. You have to
    /// find a way to calculate the possible bets based on the rules of
    /// Roulette. For a detailed description of how Roulette works, see
    /// https://de.888casino.com/magazine/roulette-strategie-guide/roulette-regeln
    /// </remarks>
    public PossibleNumbers()
    {
        // Singles (aka Straight up)
        for (int i = 0; i < 37; i++) { SingleNumbers.Add(i); }

        // Red and black
        for (int i = 1; i < 37; i++)
        {
            if (!RedBlack[0].Contains(i))
            {
                RedBlack[1].Add(i);
            }
        }

        // Even and odd
        for (int i = 1; i < 37; i++)
        {
            EvenOdd[i % 2].Add(i);
        }

        // High and low
        for (int i = 1; i < 37; i++)
        {
            HighLow[(i - 1) / 18].Add(i);
        }

        // Dozens
        for (int i = 1; i < 37; i++)
        {
            Dozens[(i - 1) / 12].Add(i);
        }

        // Rows
        for (int i = 1; i < 37; i++)
        {
            Rows[(i - 1) % 3].Add(i);
        }

        // Streets
        for (int row = 0; row < 12; row++)
        {
            Streets.Add([row * 3 + 1, row * 3 + 1 + 1, row * 3 + 1 + 2]);
        }

        // Splits
        for (int i = 1; i <= 33; i++)
        {
            Splits.Add([i, i + 3]);
        }
        for (int row = 0; row < 12; row++)
        {
            for (int number = 0; number < 2; number++)
            {
                Splits.Add([1 + row * 3 + number, 1 + row * 3 + number + 1]);
            }
        }

        // Squares
        for (int row = 0; row < 11; row++)
        {
            for (int square = 0; square < 2; square++)
            {
                Squares.Add([1 + row * 3, 1 + row * 3 + 1, 1 + (row + 1) * 3, 1 + (row + 1) * 3 + 1]);
            }
        }

        // Sixe lines
        for (int row = 0; row < 11; row++)
        {
            HashSet<int> six = [];
            for (int number = 0; number < 6; number++)
            {
                six.Add(1 + row * 3 + number);
            }

            SixLines.Add(six);
        }
    }

    /// <summary>
    /// Contains all possible single number bets.
    /// </summary>
    /// <remarks>
    /// This list must contain all possible single number bets
    /// on a roulette table. Each sub-list contains exactly one
    /// number, which is the number of the bet.
    /// </remarks>
    public List<int> SingleNumbers { get; } = [];

    /// <summary>
    /// Contains all possible red and black bets.
    /// </summary>
    /// <remarks>
    /// This list must contain exactly two sub-lists. The first
    /// sub-list contains all red numbers, the second sub-list
    /// contains all black numbers.
    /// </remarks>
    public List<HashSet<int>> RedBlack { get; } = [[1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36], []];

    /// <summary>
    /// Contains all possible even and odd bets.
    /// </summary>
    /// <remarks>
    /// This list must contain exactly two sub-lists. The first
    /// sub-list contains all even numbers, the second sub-list
    /// contains all odd numbers.
    /// </remarks>
    public List<HashSet<int>> EvenOdd { get; } = [[], []];

    /// <summary>
    /// Contains all possible high and low bets.
    /// </summary>
    /// <remarks>
    /// This list must contain exactly two sub-lists. The first
    /// sub-list contains all low numbers (<= 18), the second sub-list
    /// contains all high numbers (>= 19).
    public List<HashSet<int>> HighLow { get; } = [[], []];

    /// <summary>
    /// Contains all possible dozen bets.
    /// </summary>
    /// <remarks>
    /// This list must contain exactly three sub-lists. The first
    /// sub-list contains all numbers in the first dozen (1-12), the second
    /// sub-list contains all numbers in the second dozen (13-24), the third
    /// sub-list contains all numbers in the third dozen (25-36).
    /// </remarks>
    public List<HashSet<int>> Dozens { get; } = [[], [], []];

    /// <summary>
    /// Contains all possible row bets.
    /// </summary>
    /// <remarks>
    /// This list must contain exactly three sub-lists.
    /// Lookup the numbers for each row on a roulette table.
    /// </remarks>
    public List<HashSet<int>> Rows { get; } = [[], [], []];

    /// <summary>
    /// Contains all possible street bets.
    /// </summary>
    /// <remarks>
    /// See https://de.888casino.com/magazine/roulette-strategie-guide/roulette-regeln#street-einsatz-auf-drei-zahlen-auch-trio
    /// for a description.
    /// </remarks>
    public List<HashSet<int>> Streets { get; } = [];

    /// <summary>
    /// Contains all possible split bets.
    /// </summary>
    /// <remarks>
    /// See https://de.888casino.com/magazine/roulette-strategie-guide/roulette-regeln#split
    /// for a description.
    /// </remarks>
    public List<HashSet<int>> Splits { get; } = [];

    /// <summary>
    /// Contains all possible square bets.
    /// </summary>
    /// <remarks>
    /// See https://de.888casino.com/magazine/roulette-strategie-guide/roulette-regeln#corner-square-einsatz-auf-vier-zahlen
    /// for a description.
    /// </remarks>
    public List<HashSet<int>> Squares { get; } = [];

    /// <summary>
    /// Contains all possible six line bets.
    /// </summary>
    /// <remarks>
    /// See https://de.888casino.com/magazine/roulette-strategie-guide/roulette-regeln#der-linien-einsatz-sechs-zahlen-einsatz-oder-sechser-linien-einsatz
    /// for a description.
    /// </remarks>
    public List<HashSet<int>> SixLines { get; } = [];
}
