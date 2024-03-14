# Word Guessing Game

## Introduction

You job is to build a simple word guessing game. At the start of the game, the computer selects a random word/word group from the following list of words:

```cs
[
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
]
```

The computer replaces the letters of the word (not the spaces) with underscores. For example, if the word is "Ice fishing", the computer will display "___ _______". The player then guesses a letter. If the letter is in the word, the computer reveals the letter in the word. The number of wrong guesses is counted. The game ends when the player has guessed all the letters in the word. At the end, the computer prints the word and the number of wrong guesses.

The game must be available in three different difficulty levels:

1. Normal - Comparison of guessed letters is case-insensitive. Also, if a letter appears more than once in the word, all occurrences of the letter are revealed.
2. Easy - Like normal, but the computer reveals all occurrences of three random letters in the word at the start of the game.
3. Hard - Comparison of guessed letters is case-sensitive. Also, if a letter appears more than once in the word, only the first occurrence of the letter is revealed.

The game must be implemented as a console application. The user must be able to select the difficulty level at the start of the game.

## Setting Up the Project

Setup the project like you did in the [previous homework](https://github.com/rstropek/2023-24-2nd/tree/main/homeworks/2024-03-vending-machine#setting-up-the-project). The name of the project should be `WordGuesser`.
