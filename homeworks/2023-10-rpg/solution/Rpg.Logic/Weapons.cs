namespace Rpg.Logic;

public abstract class Attack
{
    public double BaseDamage { get; set; } = 1;
    public abstract double CalculateDamage();
}

public class Weapon : Attack
{
    public string Name { get; set; } = "";
    public override double CalculateDamage() =>
        // Weapons do between 50% and 100% of their base damage
        BaseDamage * Random.Shared.Next(50, 101) / 100d;
}

public class AttackSpell : Attack
{
    public string Spell { get; set; } = "";

    public override double CalculateDamage()
    {
        // Spells do not always work, they only work in 80% of the cases.
        // If they work, they do their full damage, otherwise they do no damage.
        if (Random.Shared.Next(10) >= 8)
        {
            return BaseDamage;
        }

        return 0d;
    }
}

public abstract class Defense
{
    public double BaseDefenseValue { get; set; }
    public abstract double CalculateDefense();
}

public class Shield : Defense
{
    public string Name { get; set; } = "";
    public override double CalculateDefense()
        // Shields offer between 75% and 100% of their base defense value
        => BaseDefenseValue * Random.Shared.Next(75, 100) / 100d;
}

public class Armor : Defense
{
    public override double CalculateDefense()
        // Armors always offer their full defense value
        => BaseDefenseValue;
}
