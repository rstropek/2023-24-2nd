using System.Text;

CustomerInQueue? firstCustomer = null;
CustomerInQueue? lastCustomer = null;

const string FILE_NAME = "queue.csv";

Console.WriteLine($"""
    What do you want to do?
    1) Add a customer to the queue
    2) Seat the next customer
    3) Display the queue
    4) Save the queue to {FILE_NAME}
    5) Load the queue from {FILE_NAME}
    6) Remove customer from queue
    """);
while (true)
{
    Console.Write("\nYour choice: ");
    string choice = Console.ReadLine()!;

    switch (choice)
    {
        case "1": AddCustomer(); break;
        case "2": SeatNextCustomer(); break;
        case "3": DisplayQueue(); break;
        case "4": SaveQueueToFile(FILE_NAME); break;
        case "5": LoadQueueFromFile(FILE_NAME); break;
        case "6": RemoveCustomerFromQueue(); break;
        default: Console.WriteLine("Invalid choice, please try again."); break;
    }

    Console.WriteLine(); // Add a blank line for readability
}

void AddCustomer()
{
    Console.Write("Enter customer name: ");
    string name = Console.ReadLine()!;
    Console.Write("Enter customer phone number: ");
    string phoneNumber = Console.ReadLine()!;

    var newCustomer = new CustomerInQueue(name, phoneNumber);
    AddCustomerObject(newCustomer);
}

// Note that the following method is new compared to the
// Basic version of the program. This makes the code for
// adding a new customer reusable during reading file.
void AddCustomerObject(CustomerInQueue newCustomer)
{
    // If there is at least one customer in the queue,
    // append the new customer to the end of the queue.
    if (lastCustomer != null) { lastCustomer.Next = newCustomer; }

    // Update the last customer to be the new customer
    // who just joined the queue.
    lastCustomer = newCustomer;

    // If the queue was empty before the new customer joined,
    // the new customer will also be the first customer.
    if (firstCustomer == null) { firstCustomer = newCustomer; }
    // Note for pros: Instead of the previous line, you could
    // also write: firstCustomer ??= newCustomer;
}

void SeatNextCustomer()
{
    if (firstCustomer == null)
    {
        Console.WriteLine("The queue is empty");
        return;
    }

    Console.WriteLine($"Seating {firstCustomer.Name} ({firstCustomer.PhoneNumber})");

    RemoveFirstCustomer();
}

void RemoveFirstCustomer()
{
    // Remove the first customer by setting the first customer
    // to be the second customer.
    firstCustomer = firstCustomer.Next;

    // If there is no second customer, the queue is now empty.
    // Therefore, we need to also set the last customer to null.
    if (firstCustomer == null) { lastCustomer = null; }
}

void DisplayQueue()
{
    if (firstCustomer == null)
    {
        Console.WriteLine("The queue is empty");
        return;
    }

    // Start with the first customer
    var current = firstCustomer;
    while (current != null)
    {
        Console.WriteLine($"{current.Name} ({current.PhoneNumber})");

        // Move to the next customer
        current = current.Next;
    }
}

void SaveQueueToFile(string filename)
{
    // Important tip: Instead of working with strings, it is 
    // much better to use StringBuilder if you need to create
    // a string step-by-step.
    var sb = new StringBuilder();

    // Start with the first customer
    var counter = 0;
    var current = firstCustomer;
    while (current != null)
    {
        sb.AppendLine($"{current.Name},{current.PhoneNumber}");
        counter++;

        // Move to next customer
        current = current.Next;
    }

    File.WriteAllText(filename, sb.ToString());
    Console.WriteLine($"Saved {counter} customers to {filename}");
}

void LoadQueueFromFile(string filename)
{
    var lines = File.ReadAllLines(filename);

    // Empty the queue
    firstCustomer = null;
    lastCustomer = null;

    foreach (var line in lines)
    {
        var parts = line.Split(',');
        var newCustomer = new CustomerInQueue(parts[0], parts[1]);
        AddCustomerObject(newCustomer);
    }

    Console.WriteLine($"Loaded {lines.Length} customers from {filename}");
}

void RemoveCustomerFromQueue()
{
    Console.Write("Enter customer name to remove: ");
    var name = Console.ReadLine()!;

    if (firstCustomer == null)
    {
        Console.WriteLine("The queue is empty.");
        return;
    }

    // If the first customer is the one to be removed
    if (firstCustomer.Name == name)
    {
        RemoveFirstCustomer();
        return;
    }

    // The customer to remove is NOT the first customer.
    // Therefore, we need to go through the queue.
    var current = firstCustomer;
    while (current.Next != null)
    {
        // Is the next customer the one to remove.
        if (current.Next.Name == name)
        {
            // Remove the next customer from the queue.
            current.Next = current.Next.Next;

            // If the current customer is not the last one,
            // we need to update lastCustomer.
            if (current.Next == null) { lastCustomer = current; }
            return;
        }

        // Go to next customer
        current = current.Next;
    }

    Console.WriteLine($"Customer {name} not found in the queue.");
}

class CustomerInQueue
{
    public string Name { get; }
    public string PhoneNumber { get; }
    public CustomerInQueue? Next { get; set; }

    public CustomerInQueue(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}
