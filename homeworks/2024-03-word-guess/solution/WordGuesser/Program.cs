using WordGuesser;

string difficulty;
do
{
    Console.WriteLine("Level of difficulty: (n)ormal, (e)asy, or (h)ard?");
    difficulty = Console.ReadLine()!;
}
while (difficulty is not "n" and not "e" and not "h");

WordGuess wordGuess = difficulty switch
{
    "e" => new EasyWordGuess(),
    "h" => new HardWordGuess(),
    _ => new WordGuess()
};

var numberOfWrongGuesses = 0;
do
{
    Console.Clear();
    Console.WriteLine($"Current guess: {wordGuess.CurrentGuess}");
    Console.WriteLine($"Number of wrong guesses: {numberOfWrongGuesses}");
    Console.WriteLine("Press a letter");
    if (!wordGuess.Guess(Console.ReadKey().KeyChar))
    {
        numberOfWrongGuesses++;
    }
}
while (!wordGuess.Completed);

Console.Clear();
Console.WriteLine($"Congratulations! You guessed the word {wordGuess.CurrentGuess} with {numberOfWrongGuesses} wrong guesses.");
