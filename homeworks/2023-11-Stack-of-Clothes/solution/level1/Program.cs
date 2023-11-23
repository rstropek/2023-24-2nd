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
            // Process shipping operation. Start by pushing items from the main stack 
            // onto the temporary stack until the requested item is found.
            var found = false;
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
