using System.Text;

class Warehouse
{
    private readonly ClothesStack[] stacks;

    public Warehouse()
    {
        stacks = new ClothesStack[5];
        for (int i = 0; i < 5; i++) { stacks[i] = new(); }
    }

    // Method to handle incoming boxes
    public void Incoming(string boxContent)
    {
        // Find the stack with the lowest height
        ClothesStack targetStack = stacks[0];
        for (int i = 1; i < stacks.Length; i++)
        {
            if (stacks[i].Count < targetStack.Count)
            {
                targetStack = stacks[i];
            }
        }

        targetStack.Push(boxContent);
    }

    // Method to handle shipping orders
    public int Shipping(string boxContent)
    {
        var moveCount = 0;

        // Search for the stack where the box is nearest to the top
        ClothesStack? sourceStack = null;
        int minDepth = int.MaxValue;
        foreach (var stack in stacks)
        {
            if (stack.TryFindDepth(boxContent, out var depth) && depth < minDepth)
            {
                sourceStack = stack;
                minDepth = depth;
            }
        }

        if (sourceStack == null) { throw new InvalidOperationException("Box not found"); }

        // Move boxes above the desired box to other stacks
        for (int i = 0; i < minDepth; i++)
        {
            string tempItem = sourceStack.Pop();
            moveCount++;
            Incoming(tempItem);  // Relocate to another stack
        }

        // Pop the desired box
        moveCount++;
        sourceStack.Pop();
        return moveCount;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < stacks.Length; i++)
        {
            sb.AppendLine($"Stack {i}: {stacks[i]}");
        }

        return sb.ToString();
    }
}