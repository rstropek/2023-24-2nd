namespace Stirnreihe.Data;

public class Node(Person person, Node? next = null)
{
    public Person Person { get; set; } = person;
    public Node? Next { get; set; } = next;
}
