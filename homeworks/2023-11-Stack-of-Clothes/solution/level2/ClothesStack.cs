// Custom stack class implemented using a linked list
using System.Text;

// Node class for the stack
class Node(string boxContent)
{
    public string BoxContent = boxContent; // Holds the data for the node, in this case, the type of clothing
    public Node? Next = null; // Points to the next node in the stack
}

class ClothesStack
{
    private Node? top = null; // The top of the stack

    public int Count { get; private set; } // The number of items in the stack

    // Pushes an item onto the stack
    public void Push(string boxContent)
    {
        // Create a new node and set its Next to the current top of the stack
        top = new Node(boxContent) { Next = top };
        Count++;
    }

    // Pops an item from the top of the stack
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
        for (Node? current = top; current != null; current = current.Next, depth++)
        {
            if (current.BoxContent == boxContent)
            {
                return true;
            }
        }

        return false; // Indicates not found
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (Node? current = top; current != null; current = current.Next)
        {
            sb.Append(current.BoxContent);
            if (current.Next != null) { sb.Append(", "); }
        }

        return sb.ToString();
    }
}