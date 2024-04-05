# Word Guessing Game

## Introduction

You job is to build a simple word guessing game. At the start of the game, the computer selects a random word/word group. The computer replaces the letters of the word (not the spaces) with underscores. For example, if the word is "Ice fishing", the computer will display "___ _______".

The player then guesses a letter. If the letter is in the word, the computer reveals the letter in the word. The number of wrong guesses is counted. The game ends when the player has guessed all the letters in the word. At the end, the computer prints the word and the number of wrong guesses.

If you are unsure how the game works, start the game from [the sample solution](./solution/WordGuesser/) but **do not** look at the source code yet. Play the game a few times to understand how it works.

## Difficulty Levels

The game must be available in three different difficulty levels:

1. Normal - Comparison of guessed letters is case-insensitive. Also, if a letter appears more than once in the word, all occurrences of the letter are revealed.

2. Easy - Like normal, but the computer reveals all occurrences of three random letters in the word at the start of the game.

3. Hard - Comparison of guessed letters is case-sensitive. Also, if a letter appears more than once in the word, only the first occurrence of the letter is revealed.

The user must be able to select the difficulty level at the start of the game.

## Setting Up the Project

Copy the [_starter_](./starter/) folder to your projects folder. This folder contains the console app and unit tests.

## Normal Mode

1. Implement the methods of the `WordGuess` class in [_WordGuess.cs_](./starter/WordGuesser/WordGuess.cs).
2. Implement the unit tests in the `NormalGuessTests` class in [_NormalGuessTests.cs_](./starter/WordGuesser.Tests/NormalGuessTests.cs).
3. Run the tests and make sure they pass.

## Easy Mode

1. Implement the methods of the `EasyWordGuess` class in [_WordGuess.cs_](./starter/WordGuesser/WordGuess.cs).
2. Implement the unit tests in the `EasyGuessTests` class in [_EasyGuessTests.cs_](./starter/WordGuesser.Tests/EasyGuessTests.cs).
3. Run the tests and make sure they pass.

## Hard Mode

1. Implement the methods of the `HardWordGuess` class in [_WordGuess.cs_](./starter/WordGuesser/WordGuess.cs).
2. Implement the unit tests in the `HardGuessTests` class in [_HardGuessTests.cs_](./starter/WordGuesser.Tests/HardGuessTests.cs).
3. Run the tests and make sure they pass.

## Console App

1. Implement the console app in [_Program.cs_](./starter/WordGuesser/Program.cs).
2. Try the program and make sure it works as expected.

Note that there are no unit tests for the console app in this example.
