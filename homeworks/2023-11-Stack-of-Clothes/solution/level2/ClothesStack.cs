using System.Text;

class Box(string boxContent)
{
    public string BoxContent = boxContent;

    // Points to the next node in the stack (i.e. the node below this one)
    public Box? Next = null;
}

// Custom stack class implemented using a linked list
class ClothesStack
{
    private Box? top = null;

    // The number of items in the stack
    public int Count { get; private set; }

    public void Push(string boxContent)
    {
        // Create a new box and set its Next to the current top of the stack
        top = new Box(boxContent) { Next = top };
        Count++;
    }

    public string Pop()
    {
        // Verify that the stack is not empty
        if (top == null) { throw new InvalidOperationException("Stack is empty"); }

        // Retrieve the top item and update the top to the next node
        var temp = top;
        top = top.Next;
        Count--;
        return temp.BoxContent;
    }

    // Checks if the stack is empty
    public bool IsEmpty() => top == null;

    // Method to find the depth of a box in the stack
    public bool TryFindDepth(string boxContent, out int depth)
    {
        depth = 0;
        for (Box? current = top; current != null; current = current.Next, depth++)
        {
            if (current.BoxContent == boxContent)
            {
                return true; // Indicates found
            }
        }

        return false; // Indicates not found
    }

    public override string ToString()
    {
        // Build a string representation of the stack.
        // The leftmost item is the top of the stack.
        var sb = new StringBuilder();
        for (var current = top; current != null; current = current.Next)
        {
            sb.Append(current.BoxContent);
            if (current.Next != null) { sb.Append(", "); }
        }

        return sb.ToString();
    }
}