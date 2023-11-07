using PhoneTariff.Logic;

Console.Write("Which tariff? [F]lat fee, [M]ixed, [P]ay as you go: ");
var selection = Console.ReadLine()!;

Console.Write("How many MB did you use? ");
var megabytes = double.Parse(Console.ReadLine()!);

Tariff tariff;
switch (selection)
{
    case "f":
        {
            Console.Write("Monthly fee: ");
            var monthlyFee = decimal.Parse(Console.ReadLine()!);
            // var ff = new FlatFee();
            // ff.MonthlyFee = monthlyFee;
            // tariff = ff;
            tariff = new FlatFee() { MonthlyFee = monthlyFee };
            break;
        }
    case "m":
        {
            Console.Write("Monthly fee: ");
            var monthlyFee = decimal.Parse(Console.ReadLine()!);
            Console.Write("Included megabytes: ");
            var includedMegabytes = double.Parse(Console.ReadLine()!);
            Console.Write("Price per megabyte: ");
            var pricePerMegabyte = decimal.Parse(Console.ReadLine()!);
            tariff = new Mixed(monthlyFee, includedMegabytes, pricePerMegabyte);
        };
        break;
    case "p":
        {
            Console.Write("Price per megabyte: ");
            var pricePerMegabyte = decimal.Parse(Console.ReadLine()!);
            tariff = new PayAsYouGo() { PricePerMegabyte = pricePerMegabyte };
            break;
        }
    default: 
        Console.WriteLine("Wrong selection");
        return;
}

Console.WriteLine($"You have to pay {tariff.CalculateFee(megabytes)}€");
