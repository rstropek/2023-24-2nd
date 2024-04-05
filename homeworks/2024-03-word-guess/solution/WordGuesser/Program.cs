using WordGuesser;

// Ask the user if she wants to play a normal, easy, or hard game.
// If the user enters an invalid input, ask again until she enters a valid input.
string difficulty;
do
{
    Console.WriteLine("Level of difficulty: (n)ormal, (e)asy, or (h)ard?");
    difficulty = Console.ReadLine()!;
}
while (difficulty is not "n" and not "e" and not "h");

// Create the proper instance of WordGuess or its derived class based on the user's input.
WordGuess wordGuess = difficulty switch
{
    "e" => new EasyWordGuess(),
    "h" => new HardWordGuess(),
    _ => new WordGuess()
};

// Game loop:
// 1. Clear the screen
// 2. Show the current guess and the current number of wrong guesses
// 3. Ask the user to press a letter (use Console.ReadKey().KeyChar)
// 4. If the user's guess is wrong, increment the number of wrong guesses
// 5. Repeat until the word is completed
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

// Show the final result:
// 1. Clear the screen
// 2. Show a message with the guessed word and the number of wrong guesses 
Console.Clear();
Console.WriteLine($"Congratulations! You guessed the word {wordGuess.CurrentGuess} with {numberOfWrongGuesses} wrong guesses.");
