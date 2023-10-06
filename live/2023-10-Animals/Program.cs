// Array of objects
var zoo = new Animal[] { new Cat(), new Dog(), new Bird() };
foreach (var animal in zoo)
{
    // Calls ToString
    Console.WriteLine(animal);

    // Call to abstract method
    animal.MakeSound();

    // Note: is operator to check AND convert type
    if (animal is Cat c) { c.Purr(); }
    else if (animal is Dog d) { d.Growl(); }

    foreach (var other in zoo)
    {
        // Call to abstract property
        Console.Write($"\t{animal.WhoAmI} does ");
        if (!animal.Likes(other)) { Console.Write("not "); }
        Console.WriteLine($"like {other.WhoAmI}");
    }
}

// Base class
abstract class Animal
{
    // Abstract, read-only property
    public abstract string WhoAmI { get; }

    // Abstract, read-only property
    public abstract int Legs { get; }

    // Concrete, read-write property
    public int LegsWritable { get; set; }

    // Abstract method
    public abstract void MakeSound();

    // Overridden method from Object
    override public string ToString()
    {
        return $"{WhoAmI} with {Legs} legs";
    }

    // Abstract method
    public abstract bool Likes(Animal other);
}

abstract class Mammal : Animal { }

class Cat : Mammal
{
    public Cat()
    {
        LegsWritable = 4;
    }

    public override string WhoAmI => "😺";

    public override int Legs => 4;

    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }

    public override bool Likes(Animal other)
    {
        // Note: is operator to check type
        return other is Cat;
    }

    // Method for Cat only
    public void Purr()
    {
        Console.WriteLine($"{WhoAmI} makes Purr");
    }
}

class Dog : Mammal
{
    public Dog()
    {
        LegsWritable = 4;
    }

    public override string WhoAmI => "🐶";

    public override int Legs => 4;

    public override void MakeSound()
    {
        Console.WriteLine("Woof");
    }

    public override bool Likes(Animal other)
    {
        // Note: or operator to check for multiple types
        return other is Dog or Bird;
    }

    public void Growl()
    {
        Console.WriteLine($"{WhoAmI} makes Grrr");
    }
}

class Bird : Animal
{
    public Bird()
    {
        LegsWritable = 2;
    }

    public override string WhoAmI => "🐦";

    public override int Legs => 2;

    public override void MakeSound()
    {
        Console.WriteLine("Chirp");
    }

    public override bool Likes(Animal other)
    {
        return other is Bird;
    }
}
