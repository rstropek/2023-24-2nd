// Node class for the stack
class Node(string boxContent)
{
    public string BoxContent = boxContent; // Holds the data for the node, in this case, the type of clothing
    public Node? Next = null; // Points to the next node in the stack
}

// Custom stack class implemented using a linked list
class ClothesStack
{
    private Node? top = null; // The top of the stack

    // Pushes an item onto the stack
    public void Push(string boxContent)
    {
        // Create a new node and set its Next to the current top of the stack
        top = new Node(boxContent) { Next = top };
    }

    // Pops an item from the top of the stack
    public string Pop()
    {
        // Verify that the stack is not empty
        if (top == null) { throw new InvalidOperationException("Stack is empty"); }

        // Retrieve the top item and update the top to the next node
        var temp = top;
        top = top.Next;
        return temp.BoxContent;
    }

    // Checks if the stack is empty
    public bool IsEmpty() => top == null;
}
