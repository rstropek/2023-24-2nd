namespace Seventeen.Tests;

using Seventeen.Logic;
using Xunit;

public class HandOfCardsTests
{
    [Fact]
    /// <summary>
    /// Verifies that adding the first card to the hand sets the first card correctly and the next card is null.
    /// </summary>
    public void Add_First_Card()
    {
        // Arrange
        var hand = new HandOfCards();
        var card = new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS);

        // Act
        hand.AddCardAtEnd(card);

        // Assert
        Assert.NotNull(hand.FirstCard);
        Assert.Equal(card, hand.FirstCard.Card);
        Assert.Null(hand.FirstCard.NextCard);
    }

    [Fact]
    /// <summary>
    /// Verifies that adding multiple cards to the hand sets the first card, next card, and subsequent next cards correctly.
    /// </summary>
    public void Add_Multiple_Cards()
    {
        // Arrange
        var hand = new HandOfCards();
        var card1 = new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS);
        var card2 = new Card(Card.CARD_TYPE_TWO, Card.CARD_SUIT_CLUBS);

        // Act
        hand.AddCardAtEnd(card1);
        hand.AddCardAtEnd(card2);

        // Assert
        Assert.NotNull(hand.FirstCard);
        Assert.Equal(card1, hand.FirstCard.Card);
        Assert.NotNull(hand.FirstCard.NextCard);
        Assert.Equal(card2, hand.FirstCard.NextCard!.Card);
        Assert.Null(hand.FirstCard.NextCard.NextCard);
    }

    [Fact]
    /// <summary>
    /// Verifies that the total value of the hand is calculated correctly for simple cards.
    /// </summary>
    public void Total_Value_Simple_Cards()
    {
        // Arrange
        var hand = new HandOfCards();
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_TWO, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_THREE, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_FOUR, Card.CARD_SUIT_CLUBS));

        // Act
        var totalValue = hand.GetTotalValue();

        // Assert
        Assert.Equal(9, totalValue);
    }

    [Fact]
    /// <summary>
    /// Verifies that the total value of the hand is calculated correctly with a face card.
    /// </summary>
    public void Total_Value_With_Facecard()
    {
        // Arrange
        var hand = new HandOfCards();
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_TWO, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_THREE, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_FOUR, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_KING, Card.CARD_SUIT_CLUBS));

        // Act
        var totalValue = hand.GetTotalValue();

        // Assert
        Assert.Equal(19, totalValue);
    }

    [Fact]
    /// <summary>
    /// Verifies that the total value of the hand is calculated correctly with an Ace counting as 11.
    /// </summary>
    public void Total_Value_With_Ace_Counting_11()
    {
        // Arrange
        var hand = new HandOfCards();
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_TWO, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_THREE, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_FOUR, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS));

        // Act
        var totalValue = hand.GetTotalValue();

        // Assert
        Assert.Equal(20, totalValue);
    }

    [Fact]
    /// <summary>
    /// Verifies that the total value of the hand is calculated correctly with an Ace counting as 1.
    /// </summary>
    public void Total_Value_With_Ace_Counting_1()
    {
        // Arrange
        var hand = new HandOfCards();
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_TWO, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_THREE, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_FOUR, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_KING, Card.CARD_SUIT_CLUBS));

        // Act
        var totalValue = hand.GetTotalValue();

        // Assert
        Assert.Equal(20, totalValue);
    }

    [Fact]
    /// <summary>
    /// Verifies that the total value of the hand is calculated correctly with two Aces.
    /// </summary>
    public void Total_Value_Two_Aces()
    {
        // Arrange
        var hand = new HandOfCards();
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS));

        // Act
        var totalValue = hand.GetTotalValue();

        // Assert
        Assert.Equal(12, totalValue);
    }

    [Fact]
    /// <summary>
    /// Verifies that the total value of the hand is calculated correctly with three Aces.
    /// </summary>
    public void Total_Value_Three_Aces()
    {
        // Arrange
        var hand = new HandOfCards();
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS));

        // Act
        var totalValue = hand.GetTotalValue();

        // Assert
        Assert.Equal(13, totalValue);
    }

    [Fact]
    /// <summary>
    /// Verifies that the ToString method returns the correct string representation for a hand with a single card.
    /// </summary>
    public void ToString_Single_Card()
    {
        // Arrange
        var hand = new HandOfCards();
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS));

        // Act
        var handString = hand.ToString();

        // Assert
        Assert.Equal("Ace of Clubs", handString);
    }

    [Fact]
    /// <summary>
    /// Verifies that the ToString method returns the correct string representation for a hand with multiple cards.
    /// </summary>
    public void ToString_Multiple_Cards()
    {
        // Arrange
        var hand = new HandOfCards();
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS));
        hand.AddCardAtEnd(new Card(Card.CARD_TYPE_TWO, Card.CARD_SUIT_CLUBS));

        // Act
        var handString = hand.ToString();

        // Assert
        Assert.Equal("Ace of Clubs, Two of Clubs", handString);
    }
}