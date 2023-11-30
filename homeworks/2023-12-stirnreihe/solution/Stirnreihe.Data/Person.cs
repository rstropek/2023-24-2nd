namespace Stirnreihe.Data;

public class Person(string firstName, string lastName, int height)
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public int Height { get; set; } = height;

    public override string ToString()
    {
        return $"{LastName}, {FirstName} ({Height} cm)";
    }
}
