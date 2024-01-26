namespace Seventeen.Logic;

/// <summary>
/// Represents a card in a deck of cards.
/// </summary>
public class CardInCollection
{
    /// <summary>
    /// Gets or sets the card.
    /// </summary>
    public Card Card { get; set; }

    /// <summary>
    /// Gets or sets the next card in the collection.
    /// </summary>
    public CardInCollection? NextCard { get; set; }

    public CardInCollection(Card card)
    {
        Card = card;
    }

    public CardInCollection(Card card, CardInCollection? nextCard)
    {
        Card = card;
        NextCard = nextCard;
    }
}