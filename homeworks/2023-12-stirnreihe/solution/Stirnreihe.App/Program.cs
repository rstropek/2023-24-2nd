using Stirnreihe.Data;

var line = new LineOfPeople();
bool running = true;

Console.WriteLine("Welcome to the Stirnreihe World Record App! What do you want to do?");
Console.WriteLine("1) Add a person to the line");
Console.WriteLine("1b) Add a person to the line (sorted)");
Console.WriteLine("2) Print the line");
Console.WriteLine("2b) Sort the line");
Console.WriteLine("3) Clear the line");
Console.WriteLine("3b) Remove a person from the line");
Console.WriteLine("4) Exit");

while (running)
{
    Console.Write("\nYour choice: ");

    var choice = Console.ReadLine()!;
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            line.AddToFront(CreatePerson());
            break;
        case "1b":
            line.AddSorted(CreatePerson());
            break;
        case "2":
            PrintLine(line);
            break;
        case "2b":
            line.Sort();
            Console.WriteLine("The line has been sorted.");
            break;
        case "3":
            line.Clear();
            Console.WriteLine("The line has been cleared.");
            break;
        case "3b":
            Console.Write("Index: ");
            var index = int.Parse(Console.ReadLine()!);
            var removedPerson = line.RemovePersonAt(index);
            Console.WriteLine($"Removed {removedPerson}");
            break;
        case "4":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}

static Person CreatePerson()
{
    Console.Write("First name: ");
    var firstName = Console.ReadLine()!;

    Console.Write("Last name: ");
    var lastName = Console.ReadLine()!;

    Console.Write("Height in cm: ");
    var height = int.Parse(Console.ReadLine()!);

    return new Person(firstName, lastName, height);
}

static void PrintLine(LineOfPeople line)
{
    if (line.Head == null) { Console.WriteLine("The line is empty"); }

    var current = line.Head;
    while (current != null)
    {
        Console.WriteLine(current.Person.ToString());
        current = current.Next;
    }
}
