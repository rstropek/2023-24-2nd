using Rpg.Logic;

// Some weapons and defenses
var stormbringerBlade = new Weapon { Name = "Stormbringer Blade", BaseDamage = 30 };
var ravenclawBlade = new Weapon { Name = "Ravenclaw Blade", BaseDamage = 28 };
var nightsFang = new Weapon { Name = "Night's Fang", BaseDamage = 9 };
var silentWhisper = new Weapon { Name = "Silent Whisper", BaseDamage = 11 };
var tempestBlade = new Weapon { Name = "Tempest Blade", BaseDamage = 32 };
var starshardLance = new Weapon { Name = "Starshard Lance", BaseDamage = 28 };
var guardianOfDawn = new Shield { Name = "Guardian of Dawn", BaseDefenseValue = 14 };
var bulwarkOfTheAncients = new Shield { Name = "Bulwark of the Ancients", BaseDefenseValue = 15 };
var starflare = new AttackSpell { Spell = "Starflare", BaseDamage = 50 };
var whisperingDagger1 = new Weapon { Name = "Whispering Dagger", BaseDamage = 10 };
var whisperingDagger2 = new Weapon { Name = "Baselard", BaseDamage = 12 };
var steelwindPlate = new Armor { BaseDefenseValue = 20 };
var celestialAegis = new Armor { BaseDefenseValue = 22 };

// Some brave warriors
var people = new Person[]
{
    new Warrior("Eldric the Brave", stormbringerBlade, bulwarkOfTheAncients),
    new Warrior("Seraphina the Valiant", ravenclawBlade, guardianOfDawn),
    new Warrior("Draven the Ironheart", tempestBlade, steelwindPlate),
    new Warrior("Aeliana the Shieldmaiden", starshardLance, celestialAegis),
    new Mage("Liora the Enchantress", starflare),
    new Rogue("Thalos the Silent", whisperingDagger1, whisperingDagger2),
    new Rogue("Nimue the Shadow", nightsFang, silentWhisper),
};

// Example for a single match
var singleMatchP1 = people[0];
var singleMatchP2 = people[1];
var singleMatch = new Fight(singleMatchP1, singleMatchP2);
var singleMatchWinner = singleMatch.ExecuteFight();
Console.WriteLine($"In a single match between '{singleMatchP1.Name}' and '{singleMatchP2.Name}', the winner is '{singleMatchWinner.Name}'!");
Console.WriteLine();

// Example for a tournament
var rand = new Random(1000);
for (var i = 0; i < 500; i++)
{
    var p1 = people[rand.Next(people.Length)];
    Person p2;
    do
    {
        p2 = people[rand.Next(people.Length)];
    }
    while (p1 == p2);

    var fight = new Fight(p1, p2);
    var winner = fight.ExecuteFight();
    Console.WriteLine($"'{p1.Name}' fought '{p2.Name}' and '{winner.Name}' won!");
}
