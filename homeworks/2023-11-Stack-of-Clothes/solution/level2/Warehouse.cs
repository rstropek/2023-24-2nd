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
    public void Incoming(string boxContent, ClothesStack? stackToAvoid = null)
    {
        // stackToAvoid is used to prevent a box from being placed on the same stack
        // as it is relocated from. This is used in the Shipping method.

        // Find the stack with the lowest height
        var minHeight = int.MaxValue;
        var targetStackIndex = -1;
        for (int i = 0; i < stacks.Length; i++)
        {
            if (stacks[i].Count < minHeight && (stackToAvoid == null || stacks[i] != stackToAvoid))
            {
                minHeight = stacks[i].Count;
                targetStackIndex = i;
            }
        }

        stacks[targetStackIndex].Push(boxContent);
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

            // Relocate to another stack. For that, we can use the existing
            // Incoming method, but we need to avoid placing the box on the
            // same stack as it is relocated from.
            Incoming(tempItem, sourceStack);  
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