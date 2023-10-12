namespace Rpg.Logic;

public class Person
{
    public double Health { get; set; } = 100d;    
    public string Name { get; set; } = "";

    // NOTE that we use a virtual method here, not an abstract one!
    // That means that descendent classes CAN override this method, 
    // but they don't have to. That is the difference to abstract
    // methods, which MUST be overridden by descendent classes.
    public virtual double CalculateDamage() => 0d;
    public virtual double CalculateDefense() => 0d;
}

public class Warrior : Person
{
    // Warriors have one way to attack and one defense.

    public Attack Attack { get; set; }
    public Defense Defense { get; set; }

    public Warrior(string name, Attack attack, Defense defense)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
    }

    public override double CalculateDamage() => Attack.CalculateDamage();
    public override double CalculateDefense() => Defense.CalculateDefense();
}

public class Mage : Person
{
    // Mages are attack specialists. They only have one way to 
    // attack, but no defense.

    public AttackSpell Spell { get; set; }

    public Mage(string name, AttackSpell spell)
    {
        Name = name;
        Spell = spell;
    }

    public override double CalculateDamage() => Spell.CalculateDamage();
}

public class Rogue : Person
{
    // Rogues are also attack specialists. They have two ways to
    // attack, but no defense.

    public Weapon Weapon1 { get; set; }
    public Weapon Weapon2 { get; set; }

    public Rogue(string name, Weapon weapon1, Weapon weapon2)
    {
        Name = name;
        Weapon1 = weapon1;
        Weapon2 = weapon2;
    }

    public override double CalculateDamage() => Weapon1.CalculateDamage() + Weapon2.CalculateDamage();
}
