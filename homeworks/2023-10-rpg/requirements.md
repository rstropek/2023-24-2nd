# Technical Requirements

## Class Library `Rpg.Logic`

Create a class library `Rpg.Logic`.

### Attacks and Defenses

It contains the following classes for attacks and defenses:

[![](https://mermaid.ink/img/pako:eNqdk01vnDAQhv8K8qmRNiw23yiXNJtje1mplaq9zOIBrBqMjIm63fLfa_CmpUoaJfHF9ryjZ94Z2WdSKo6kIKWEYdgJqDW0h86z69YYKL97N7-ur72vCL3qnsbded-jlE5cMJfw2YXmxdV4lOh9hAF30EKNfyU4DkZDaR5z7kCWowRzSfxw5VKnNd_ZWfEtQnS19xnaFVk9oNaC41vIq4ae4ld9vp2_wwq7Ad3c9o1AyZ8RbnWr9NrQRf3PLJ34BeT4qom69Gcbd47eP9IX0EtP53dByIa0qFsQ3D7RBXEgpkFriRT2yLGCUZoDOXSTTYXRqP2pK0lh9IgbMvZ8prpHTYoK5GCjPXTflPrnTooz-UEKmuZ-EkUJjbI0YAlj6YacSMEi5ucsiLM8C9I8ZmE2bcjPBRH4MQ1pnLGA0ZSGLE4fq95zYZT-U0Qq4KjnOubUz_-tFoOxlkvVVaKe46OWNtwY0w_FdjvLfi1MMx79UrXbQfAGtGke8mSbsCQDFmKShhCHIS-PNM8qFtGKpwFlQCbrD5f6ny6fe96m372FO9M?type=png)](https://mermaid.live/edit#pako:eNqdk01vnDAQhv8K8qmRNiw23yiXNJtje1mplaq9zOIBrBqMjIm63fLfa_CmpUoaJfHF9ryjZ94Z2WdSKo6kIKWEYdgJqDW0h86z69YYKL97N7-ur72vCL3qnsbded-jlE5cMJfw2YXmxdV4lOh9hAF30EKNfyU4DkZDaR5z7kCWowRzSfxw5VKnNd_ZWfEtQnS19xnaFVk9oNaC41vIq4ae4ld9vp2_wwq7Ad3c9o1AyZ8RbnWr9NrQRf3PLJ34BeT4qom69Gcbd47eP9IX0EtP53dByIa0qFsQ3D7RBXEgpkFriRT2yLGCUZoDOXSTTYXRqP2pK0lh9IgbMvZ8prpHTYoK5GCjPXTflPrnTooz-UEKmuZ-EkUJjbI0YAlj6YacSMEi5ucsiLM8C9I8ZmE2bcjPBRH4MQ1pnLGA0ZSGLE4fq95zYZT-U0Qq4KjnOubUz_-tFoOxlkvVVaKe46OWNtwY0w_FdjvLfi1MMx79UrXbQfAGtGke8mSbsCQDFmKShhCHIS-PNM8qFtGKpwFlQCbrD5f6ny6fe96m372FO9M)

`CalculateDamage` and `CalculateDefense` must reflect the game rules. Here is a possible implementation of `Weapon.CalculateDamage`:

```cs
public override double CalculateDamage()
{
    // Weapons do between 50% and 100% of their base damage
    return BaseDamage * Random.Shared.Next(50, 101) / 100d;
}
```

Implement `AttackSpell.CalculateDamage`, `Shield.CalculateDefense`, and `Armor.CalculateDefense` accordingly.

### Characters

For characters, it contains the following classes:

[![](https://mermaid.ink/img/pako:eNqdU01rwzAM_SvBpw36saZbP8IuYx3s0jHWQ2H0osZKYubYwZYLpct_n5OmbUbpGPUhCk9PTy-RvGOx5sgiFkuwdiYgNZCvVODPOxqrVfD43e0GSzBGaHOemEOK5-iHTl0D17pNcreHqsO1W0sMXhEkZSfYkhEqDd4g9-UneCMMOZCHqmeQsZNAOIPc97-5PWcKRS0aJqjskVe2nTVf1rL2RATxVxNOcCNyiG17eoNehOM__F2m_uGx-slnBhcFShnUzyu8_NKvx9VqsEQo_Cj3YXABD6_ryjosR5OD4H7p6p4rRhn6ebPIv3JMwElasZUqPdUV3Iu8cEHasCgBabHDwJFebFXMIjIOD6Rmd48sqYGjL9ox2hbVhqfCkpeMtUpEWuHOSA9nRIWN-v0q3UsFZW7di3Xet4JnYCjbTEf9UTiaQDjE0XgID8Mhj9eD6SQJ7wcJH98NQmBl2WEFqE-tTwawdj1vrlcVyh-amxkM?type=png)](https://mermaid.live/edit#pako:eNqdU01rwzAM_SvBpw36saZbP8IuYx3s0jHWQ2H0osZKYubYwZYLpct_n5OmbUbpGPUhCk9PTy-RvGOx5sgiFkuwdiYgNZCvVODPOxqrVfD43e0GSzBGaHOemEOK5-iHTl0D17pNcreHqsO1W0sMXhEkZSfYkhEqDd4g9-UneCMMOZCHqmeQsZNAOIPc97-5PWcKRS0aJqjskVe2nTVf1rL2RATxVxNOcCNyiG17eoNehOM__F2m_uGx-slnBhcFShnUzyu8_NKvx9VqsEQo_Cj3YXABD6_ryjosR5OD4H7p6p4rRhn6ebPIv3JMwElasZUqPdUV3Iu8cEHasCgBabHDwJFebFXMIjIOD6Rmd48sqYGjL9ox2hbVhqfCkpeMtUpEWuHOSA9nRIWN-v0q3UsFZW7di3Xet4JnYCjbTEf9UTiaQDjE0XgID8Mhj9eD6SQJ7wcJH98NQmBl2WEFqE-tTwawdj1vrlcVyh-amxkM)

`CalculateDamage` and `CalculateDefense` are implemented by calling the corresponding methods of the attack and defense objects. Here is a possible implementation of `Warrior`:

```cs
public class Warrior : Person
{
    // Warriors have one way to attack and one defense.
    public Attack Attack { get; set; }
    public Defense Defense { get; set; }

    ...

    public override double CalculateDamage() => Attack.CalculateDamage();
    public override double CalculateDefense() => Defense.CalculateDefense();
}
```

Implement the methods in `Mage` and `Rogue` accordingly.

### Fights

Create a separate class for the fight logik called `Fight`. Here is a stub for the class:

```cs
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
        // You have to implement this method yourself
        ...
    }
}
```

Implement the method `ExecuteFight` according to the game rules.

## Console App `Rpg.App`

### Test Data

To make testing easier and a bit more fun, here is some test data containing epic 😜 characters and items from our RPG game:

```cs
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
```

### Level 1

Let _Eldric the Brave_ fight agains _Seraphina the Valiant_ 100 times. Print the number of wins for each character to the console as follows (replace _..._ by the corresponding number of wins).

```txt
We let Eldric the Brave fight against Seraphina the Valiant 100 times. Here are the results:
Eldric the Brave won ... times.
Seraphina the Valiant won ... times.
```

### Level 2

Select 500 random pairs of characters from the list above and let them fight against each other (a character _cannot_ fight itself). Print the result of each fight on the screen as follows:

```txt
'Seraphina the Valiant' fought 'Thalos the Silent' and 'Seraphina the Valiant' won!
'Eldric the Brave' fought 'Liora the Enchantress' and 'Eldric the Brave' won!
'Aeliana the Shieldmaiden' fought 'Nimue the Shadow' and 'Aeliana the Shieldmaiden' won!
'Eldric the Brave' fought 'Liora the Enchantress' and 'Eldric the Brave' won!
...
```

At the end, print the character who has one the most fights as follows:

```txt
'Liora the Enchantress' has won the most fights (87)!
```
