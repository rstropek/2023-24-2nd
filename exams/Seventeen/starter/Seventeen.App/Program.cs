using Seventeen.Logic;

Console.WriteLine("Welcome to 17-and-4!");

var cards = new StackOfCards();
cards.Fill();

var hand = new HandOfCards();
hand.AddCardAtEnd(cards.Pop()!);
hand.AddCardAtEnd(cards.Pop()!);

do
{
    Console.WriteLine($"Your hand: {hand}");
    Console.WriteLine($"Your hand value: {hand.GetTotalValue()}");

    Console.Write("Do you want to draw another card? (y/n)");
    var answer = Console.ReadLine()!;
    if (answer == "n") { break; }

    hand.AddCardAtEnd(cards.Pop()!);
}
while (hand.GetTotalValue() <= 21);

if (hand.GetTotalValue() > 21)
{
    Console.WriteLine("You lost!");
}

Console.WriteLine($"Your hand: {hand}");
Console.WriteLine($"Your hand value: {hand.GetTotalValue()}");
