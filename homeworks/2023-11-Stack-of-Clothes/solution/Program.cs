using System;
using System.IO;

// Node class for the stack
class Node(string data)
{
    public string Data = data; // Holds the data for the node, in this case, the type of clothing
    public Node? Next = null; // Points to the next node in the stack
}

// Custom stack class implemented using a linked list
class ClothesStack
{
    private Node? top = null; // The top of the stack

    // Pushes an item onto the stack
    public void Push(string item)
    {
        // Create a new node and set its Next to the current top of the stack
        top = new Node(item) { Next = top };
    }

    // Pops an item from the top of the stack
    public string Pop()
    {
        if (top == null)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        // Retrieve the top item and update the top to the next node
        var temp = top;
        top = top.Next;
        return temp.Data;
    }

    // Checks if the stack is empty
    public bool IsEmpty() => top == null;
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "operations.txt"; // Path to the file containing operations
        var operations = File.ReadAllLines(filePath);
        var mainStack = new ClothesStack(); // Main stack for storing clothes boxes
        var tempStack = new ClothesStack(); // Temporary stack used during shipping
        int moveCount = 0; // Counter for the number of box movements

        foreach (var operation in operations)
        {
            var parts = operation.Split(' ');
            switch (parts[0].ToLower())
            {
                case "incoming":
                    // Process incoming operation by pushing the item onto the main stack
                    mainStack.Push(parts[1]);
                    moveCount++; // Increment move count for each incoming operation
                    break;

                case "shipping":
                    // Process shipping operation
                    bool found = false;
                    while (!mainStack.IsEmpty())
                    {
                        string tempItem = mainStack.Pop();
                        moveCount++; // Increment move count for each pop
                        if (tempItem == parts[1])
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
                    if (!found)
                    {
                        Console.WriteLine($"Requested item {parts[1]} not found.");
                    }

                    // Move items back from the temporary stack to the main stack
                    while (!tempStack.IsEmpty())
                    {
                        mainStack.Push(tempStack.Pop());
                        moveCount++; // Increment move count for each move back
                    }

                    break;
            }
        }

        Console.WriteLine($"Total box movements: {moveCount}"); // Output total box movements
    }
}
