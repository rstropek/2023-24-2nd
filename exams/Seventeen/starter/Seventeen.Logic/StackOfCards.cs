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
        // TODO: Implement this method
        throw new NotImplementedException();
    }

    /// <summary>
    /// Pops a card from the stack.
    /// </summary>
    /// <returns>
    /// The card that was popped from the stack, or null if the stack is empty.
    /// </returns>
    public Card? Pop()
    {
        // TODO: Implement this method
        throw new NotImplementedException();
    }

    /// <summary>
    /// Fills the stack with 52 cards.
    /// </summary>
    /// <remarks>
    /// The cards will be in random order.
    /// </remarks>
    public void Fill()
    {
        // TODO: Implement this method
        throw new NotImplementedException();

        // Here are the steps that you need to do:
        // 1. Fill an array of size 52 (4 * 13) with all cards. Use a nested for loop for that.
        // 2. Exchange two random cards in the array 10.000 times. Use a for loop for that.
        //    Remember: You get a random number with: `var randomIndex = Random.Shared.Next(52)`
        // 3. Push all cards from the array to the stack. Use a foreach loop for that.
    }
}