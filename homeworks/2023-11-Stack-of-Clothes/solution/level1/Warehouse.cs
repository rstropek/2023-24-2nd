class Warehouse
{
    private readonly ClothesStack mainStack = new();

    // Method to handle incoming boxes
    public void Incoming(string boxContent)
    {
        // Process incoming operation by pushing the item onto the main stack
        mainStack.Push(boxContent);
    }

    // Method to handle shipping orders. It returns the number of box movements.
    public int Shipping(string boxContent)
    {
        var tempStack = new ClothesStack();
        var moveCount = 0;

        // Process shipping operation. Start by pushing items from the main stack 
        // onto the temporary stack until the requested item is found.
        var found = false;
        while (!mainStack.IsEmpty())
        {
            string tempItem = mainStack.Pop();
            moveCount++;
            if (tempItem == boxContent)
            {
                found = true;
                break; // Item found, exit the loop
            }
            else
            {
                tempStack.Push(tempItem); // Push item onto temporary stack
            }
        }

        // Handle case where the requested item is not found
        if (!found) { throw new InvalidOperationException("Box not found"); }

        // Move items back from the temporary stack to the main stack
        while (!tempStack.IsEmpty())
        {
            mainStack.Push(tempStack.Pop());
            moveCount++;
        }

        return moveCount;
    }

    public override string ToString() => mainStack.ToString();
}