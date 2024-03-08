namespace Adder;

public class NumberAdder
{
    public int Add(int value) => checked(Sum += value);

    public int Sum { get; private set; }
}
