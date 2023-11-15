CustomerInQueue? firstCustomer = null;
CustomerInQueue? lastCustomer = null;

Console.WriteLine("""
    What do you want to do?
    1) Add a customer to the queue
    2) Seat the next customer
    3) Display the queue
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
