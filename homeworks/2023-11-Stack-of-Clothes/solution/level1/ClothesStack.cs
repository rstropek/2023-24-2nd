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

    public void Push(string boxContent)
    {
        // Create a new box and set its Next to the current top of the stack
        top = new Box(boxContent) { Next = top };
    }

    public string Pop()
    {
        // Verify that the stack is not empty
        if (top == null)
        { 
            // Note: Exceptions are a way to handle errors in C#. Whenever
            // something unexpected happens, you can throw an exception to
            // indicate that something went wrong. The exception will end
            // the method and return control to the caller. The caller can
            // then choose to handle the exception or let it bubble up to
            // the caller's caller. If the exception is not handled, the
            // program will crash.
            throw new InvalidOperationException("Stack is empty"); 
        }

        // Retrieve the top item and update the top to the next node
        var temp = top;
        top = top.Next;
        return temp.BoxContent;
    }

    public bool IsEmpty() => top == null;

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
