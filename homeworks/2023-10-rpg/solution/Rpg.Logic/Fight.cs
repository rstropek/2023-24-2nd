namespace Rpg.Logic;

public class Fight
{
    public Fight(Person character1, Person character2)
    {
        Character1 = character1;
        Character2 = character2;
    }

    public Person Character1 { get; }
    public Person Character2 { get; }

    public Person ExecuteFight()
    {
        // Randomly determine who hits first
        var whoHitsFirst = Random.Shared.Next(2);
        var first = whoHitsFirst == 0 ? Character1 : Character2;
        var second = whoHitsFirst == 0 ? Character2 : Character1;

        // Copy their initial health points
        var health1 = first.Health;
        var health2 = second.Health;

        // Fight until one of them is dead
        while (health1 > 0 && health2 > 0)
        {
            // Damage is calculated by subtracting the defense value from the damage value
            var damage = first.CalculateDamage() - second.CalculateDefense();
            health2 -= Math.Max(0, damage);
            // If a character is dead, we can stop the fight
            if (health2 <= 0) { break; }

            damage = second.CalculateDamage() - first.CalculateDefense();
            health1 -= Math.Max(0, damage);
            if (health1 <= 0) { break; }
        }

        // Return the winner
        return health1 > 0 ? first : second;
    }
}
