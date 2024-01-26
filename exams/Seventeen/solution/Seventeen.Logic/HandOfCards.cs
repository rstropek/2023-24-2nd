using System.Text;

namespace Seventeen.Logic;

/// <summary>
/// Represents a hand of cards (single-linked list).
/// </summary>
public class HandOfCards
{
    /// <summary>
    /// Gets or sets the first card in the hand.
    /// </summary>
    public CardInCollection? FirstCard { get; set; }

    /// <summary>
    /// Adds a card to the end of the hand.
    /// </summary>
    /// <param name="card">Card to add</param>
    public void AddCardAtEnd(Card card)
    {
        if (FirstCard == null)
        {
            FirstCard = new CardInCollection(card);
            return;
        }

        var currentCard = FirstCard;
        while (currentCard.NextCard != null)
        {
            currentCard = currentCard.NextCard;
        }

        currentCard.NextCard = new CardInCollection(card);
    }

    /// <summary>
    /// Gets the total value of the hand.
    /// </summary>
    /// <returns>Total value of the hand</returns>
    /// <remarks>
    /// The value of a hand is the sum of the card values.
    /// The value of a card is the card type, except for face 
    /// cards which are worth 10.
    /// An ace is worth 1 or 11, whichever is best for the hand.
    /// </remarks>
    public int GetTotalValue()
    {
        var totalValue = 0;
        var currentCard = FirstCard;
        var numberOfAces = 0;
        while (currentCard != null)
        {
            if (currentCard.Card.CardType >= 10)
            {
                totalValue += 10;
            } else {
                totalValue += currentCard.Card.CardType;
                if (currentCard.Card.CardType == Card.CARD_TYPE_ACE)
                {
                    numberOfAces++;
                }
            }

            currentCard = currentCard.NextCard;
        }

        for (var i = 0; i < numberOfAces; i++)
        {
            if (totalValue + 10 <= 21)
            {
                totalValue += 10;
            }
        }

        return totalValue;
    }

    /// <summary>
    /// Returns a string representation of the hand.
    /// </summary>
    /// <remarks>
    /// The string representation is a comma-separated list of cards.
    /// (e.g. "Ace of Clubs, Two of Clubs, Three of Clubs")
    /// </remarks>
    public override string ToString()
    {
        var result = new StringBuilder();
        var currentCard = FirstCard;
        while (currentCard != null)
        {
            if (result.Length > 0)
            {
                result.Append(", ");
            }
            result.Append(currentCard.Card.CardTypeText);
            result.Append(" of ");
            result.Append(currentCard.Card.CardSuitText);

            currentCard = currentCard.NextCard;
        }

        return result.ToString();   
    }
}