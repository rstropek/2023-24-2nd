# Twenty-One (German: Siebzehn und Vier)

## Introduction

[Twenty-One](<https://en.wikipedia.org/wiki/Twenty-One_(banking_game)>) (in German called [17-und-4](https://de.wikipedia.org/wiki/Siebzehn_und_Vier)) is a traditional card game. In this exercise, you have to implement a simple version of this game.

## Rules

The game is played with a deck of 52 cards. Here are the card types:

- Ace
- Number cards 2-10
- Picture cards Jack (_Bube_), Queen, King

The deck has all these cards in four different suits: Hearts (♥️), Diamonds (♦️), Clubs (♣️), Spades (♠️).

![Cards](640px-Piatnikcards.jpg)

Bildquelle: https://de.wikipedia.org/wiki/Spielkarte#/media/Datei:Piatnikcards.jpg

Before the game, the 52 cards are suffled so that they are in a random order. Then, the player gets two cards. The computer calculates the value of the hand (details see below). The user can then decide, whether she wants an additional card. This is repeated until the user decides to not take an additional card or the value of the hand is greater than 21. In the latter case, the user loses.

Multiple players play the game one after each other. The winner is the user with the highest value of the hand that is not greater than 21.

The value of a hand is calculated as follows:

- Number cards between 2 and 10 have the value of their number.
- Picture cards have the value 10.
- Aces have the value 11 or 1, depending on which value is better for the player.
- The suite of the cards does not matter for the hand's value.

Here are some examples of hands and their values:

| Hand                        | Value |
| --------------------------- | ----: |
| Two, Three, Four            |     9 |
| Two, Three, Four, King      |    19 |
| Two, Three, Four, Ace       |    20 |
| Two, Three, Four, Ace, King |    20 |
| Ace, Ace                    |    12 |
| Ace, Ace, Ace               |    13 |

## Technical Requirements

You have to implement a _stack_ data structure that can store the cards of the deck. Next, you have to implement a _list_ data structure that stores the cards of the hand. Both data structures have some helper methods.

Your starter code contains the following ready-to-use parts:

* Class [`Card`](./starter/Seventeen.Logic/Card.cs) representing a single card consisting of card type and suite.
* Class [`CardInCollection`](./starter/Seventeen.Logic/CardInCollection.cs) representing a card in a collection (stack or list).
* [Console application](./starter/Seventeen.App/) that can be used to test your implementation interactively.
* [Unit tests](./starter/Seventeen.Tests/) that can be used to test your implementation automatically.

## Basic Requirements

* Class [`StackOfCards`](./starter/Seventeen.Logic/StackOfCards.cs):
    * Implement the `Push` method
    * Implement the `Pop` method
    * Implement the `Fill` method **without shuffling the cards**. You can add the cards in any order.
* Class [`HandOfCards`](./starter/Seventeen.Logic/HandOfCards.cs):
    * Implement the `AddCardAtEnd` method
    * Implement the `GetTotalValue` method **without considering the dual value of the aces**. An ace always has the value 1.
    * Implement the `ToString` method

## Advanced Requirements

* Class [`StackOfCards`](./starter/Seventeen.Logic/StackOfCards.cs):
    * Implement the `Fill` method **with** shuffling the cards.
* Class [`HandOfCards`](./starter/Seventeen.Logic/HandOfCards.cs):
    * Implement the `GetTotalValue` method **with** considering the dual value of the aces.
