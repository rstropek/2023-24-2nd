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
        // TODO: Implement this method
        throw new NotImplementedException();
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
        // TODO: Implement this method
        throw new NotImplementedException();

        // For the basic requirements, the ACE counts as 1.
        //
        // For the advanced requirements, the ACE counts as 1
        // or 11, whichever is best for the hand.
        //
        // Here are the necessary steps for the advanced requirement:
        // 1. Count the number of aces in the hand.
        // 2. Add the value of all cards, aces count as 1 for the moment.
        // 3. For each ace, add 10 to the total value as long as the total value
        //    is less than or equal to 21.
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
        // TODO: Implement this method
        throw new NotImplementedException();

        // IMPORTANT NOTE: You can turn a card type into a string
        //   with `Card.CardTypeText` (e.g. `var cardTypeText = myCard.CardTypeText;`).
        //
        // IMPORTANT NOTE: You can turn a card suit into a string
    }
}