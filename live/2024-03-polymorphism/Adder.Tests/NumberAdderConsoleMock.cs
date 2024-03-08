namespace Adder.Tests;

public class NumberAdderConsoleMock(string[] inputs) : NumberAdderConsole
{
    public List<string> Outputs { get; } = [];

    private int NumberOfReadLineCommands { get; set; }

    public override string ReadLine()
    {
        Assert.True(NumberOfReadLineCommands < inputs.Length, "ReadLine called too many times");
        return inputs[NumberOfReadLineCommands++];
    }

    public override void WriteLine(string value) => Outputs.Add(value);
}
