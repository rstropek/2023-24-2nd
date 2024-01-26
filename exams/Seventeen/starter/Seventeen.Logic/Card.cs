namespace Seventeen.Logic;

/// <summary>
/// Represents a card in a deck of cards.
/// </summary>
public class Card
{
    public const int CARD_TYPE_ACE = 1;
    public const int CARD_TYPE_TWO = 2;
    public const int CARD_TYPE_THREE = 3;
    public const int CARD_TYPE_FOUR = 4;
    public const int CARD_TYPE_FIVE = 5;
    public const int CARD_TYPE_SIX = 6;
    public const int CARD_TYPE_SEVEN = 7;
    public const int CARD_TYPE_EIGHT = 8;
    public const int CARD_TYPE_NINE = 9;
    public const int CARD_TYPE_TEN = 10;
    public const int CARD_TYPE_JACK = 11;
    public const int CARD_TYPE_QUEEN = 12;
    public const int CARD_TYPE_KING = 13;

    public const int CARD_SUIT_CLUBS = 1;
    public const int CARD_SUIT_DIAMONDS = 2;
    public const int CARD_SUIT_HEARTS = 3;
    public const int CARD_SUIT_SPADES = 4;

    public int CardType { get; set; }

    /// <summary>
    /// Returns the card type as text.
    /// </summary>
    public string CardTypeText => CardType switch
    {
        CARD_TYPE_ACE => "Ace",
        CARD_TYPE_TWO => "Two",
        CARD_TYPE_THREE => "Three",
        CARD_TYPE_FOUR => "Four",
        CARD_TYPE_FIVE => "Five",
        CARD_TYPE_SIX => "Six",
        CARD_TYPE_SEVEN => "Seven",
        CARD_TYPE_EIGHT => "Eight",
        CARD_TYPE_NINE => "Nine",
        CARD_TYPE_TEN => "Ten",
        CARD_TYPE_JACK => "Jack",
        CARD_TYPE_QUEEN => "Queen",
        CARD_TYPE_KING => "King",
        _ => throw new Exception("Invalid card type")
    };

    public int CardSuit { get; set; }

    /// <summary>
    /// Returns the card suit as text.
    /// </summary>
    public string CardSuitText => CardSuit switch
    {
        CARD_SUIT_CLUBS => "Clubs",
        CARD_SUIT_DIAMONDS => "Diamonds",
        CARD_SUIT_HEARTS => "Hearts",
        CARD_SUIT_SPADES => "Spades",
        _ => throw new Exception("Invalid card suit")
    };

    public Card(int cardType, int cardSuit)
    {
        CardType = cardType;
        CardSuit = cardSuit;
    }
}