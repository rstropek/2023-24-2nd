namespace Seventeen.Logic;

public class StackOfCards
{
    /// <summary>
    /// Gets or sets the top card in the stack.
    /// </summary>
    public CardInCollection? TopCard { get; set; }

    /// <summary>
    /// Pushes a card to the stack.
    /// </summary>
    /// <param name="card">Card to push onto the stack</param>
    public void Push(Card card)
    {
        TopCard = new CardInCollection(card, TopCard);
    }

    /// <summary>
    /// Pops a card from the stack.
    /// </summary>
    /// <returns>
    /// The card that was popped from the stack, or null if the stack is empty.
    /// </returns>
    public Card? Pop()
    {
        if (TopCard == null) { return null; }

        var card = TopCard.Card;
        TopCard = TopCard.NextCard;
        return card;
    }

    /// <summary>
    /// Fills the stack with 52 cards.
    /// </summary>
    /// <remarks>
    /// The cards will be in random order.
    /// </remarks>
    public void Fill()
    {
        var cards = new Card[4 * 13];

        // Fill the array with all cards
        var index = 0;
        for (var cardSuit = Card.CARD_SUIT_CLUBS; cardSuit <= Card.CARD_SUIT_SPADES; cardSuit++)
        {
            for (var cardType = Card.CARD_TYPE_ACE; cardType <= Card.CARD_TYPE_KING; cardType++)
            {
                cards[index] = new Card(cardType, cardSuit);
                index++;
            }
        }

        // Exchange two random cards 10.000 times
        for (var i = 0; i < 10000; i++)
        {
            var firstIndex = Random.Shared.Next(cards.Length);
            var secondIndex = Random.Shared.Next(cards.Length);
            (cards[secondIndex], cards[firstIndex]) = (cards[firstIndex], cards[secondIndex]);
        }

        // Push all cards to the stack
        foreach (var card in cards) { Push(card); }
    }
}