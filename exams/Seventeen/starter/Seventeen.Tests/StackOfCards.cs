namespace Seventeen.Tests;

using Seventeen.Logic;
using Xunit;

public class StackOfCardsTests
{
    [Fact]
    /// <summary>
    /// Verifies that the Push method adds a card to the top of the stack correctly.
    /// </summary>
    public void Push()
    {
        // Arrange
        var stack = new StackOfCards();
        var card = new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS);

        // Act
        stack.Push(card);

        // Assert
        Assert.Equal(card, stack.TopCard!.Card);
        Assert.Null(stack.TopCard.NextCard);
    }

    [Fact]
    /// <summary>
    /// Verifies that the Push method adds two cards to the top of the stack correctly.
    /// </summary>
    public void Push_Two_Cards()
    {
        // Arrange
        var stack = new StackOfCards();
        var card1 = new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS);
        var card2 = new Card(Card.CARD_TYPE_TWO, Card.CARD_SUIT_CLUBS);

        // Act
        stack.Push(card1);
        stack.Push(card2);

        // Assert
        Assert.Equal(card2, stack.TopCard!.Card);
        Assert.Equal(card1, stack.TopCard.NextCard!.Card);
        Assert.Null(stack.TopCard.NextCard.NextCard);
    }
    
    [Fact]
    /// <summary>
    /// Verifies that the Pop method removes and returns the top card from the stack correctly.
    /// </summary>
    public void Pop()
    {
        // Arrange
        var stack = new StackOfCards();
        stack.Push(new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS));
        stack.Push(new Card(Card.CARD_TYPE_TWO, Card.CARD_SUIT_CLUBS));

        // Act
        var poppedCard = stack.Pop();

        // Assert
        Assert.Equal(Card.CARD_TYPE_TWO, poppedCard!.CardType);
        Assert.NotNull(stack.TopCard);
        Assert.Equal(Card.CARD_TYPE_ACE, stack.TopCard!.Card.CardType);
        Assert.Null(stack.TopCard.NextCard);
    }

    [Fact]
    /// <summary>
    /// Verifies that the Pop method removes and returns the last card from the stack correctly.
    /// </summary>
    public void Pop_Last_Card()
    {
        // Arrange
        var stack = new StackOfCards();
        var card = new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS);
        stack.Push(card);

        // Act
        var poppedCard = stack.Pop();

        // Assert
        Assert.Equal(card, poppedCard);
        Assert.Null(stack.TopCard);
    }

    [Fact]
    /// <summary>
    /// Verifies that the Push and Pop methods work correctly when used multiple times.
    /// </summary>
    public void Push_Pop_Multiple()
    {
        // Arrange
        var stack = new StackOfCards();
        stack.Push(new Card(Card.CARD_TYPE_ACE, Card.CARD_SUIT_CLUBS));
        stack.Push(new Card(Card.CARD_TYPE_TWO, Card.CARD_SUIT_CLUBS));
        stack.Push(new Card(Card.CARD_TYPE_THREE, Card.CARD_SUIT_CLUBS));

        // Act
        var card1 = stack.Pop();
        var card2 = stack.Pop();
        var card3 = stack.Pop();

        // Assert
        Assert.Equal(Card.CARD_TYPE_THREE, card1!.CardType);
        Assert.Equal(Card.CARD_TYPE_TWO, card2!.CardType);
        Assert.Equal(Card.CARD_TYPE_ACE, card3!.CardType);
    }

    [Fact]
    /// <summary>
    /// Verifies that the Pop method returns null when the stack is empty.
    /// </summary>
    public void Pop_Returns_Null_If_Empty()
    {
        // Arrange
        var stack = new StackOfCards();

        // Act
        var poppedCard = stack.Pop();

        // Assert
        Assert.Null(poppedCard);
    }

    [Fact]
    /// <summary>
    /// Verifies that the Fill method fills the stack with 52 cards.
    /// </summary>
    public void Fill_ShouldFillStackWith52Cards()
    {
        // Arrange
        var stack = new StackOfCards();

        // Act
        stack.Fill();

        // Assert
        var cardCount = 0;
        while (stack.Pop() != null)
        {
            cardCount++;
        }
        Assert.Equal(52, cardCount);
    }
}