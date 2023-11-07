namespace PhoneTariff.Logic;

public class Usage
{
    public string Type { get; set; } = "";
    public DateTime TimeStamp { get; set; }
    public double CallLength { get; set; }
    public double Megabytes { get; set; }
}

// public record Usage(string Type, DateTime TimeStamp, double CallLength, double Megabytes);

public static class Importer
{
    public static Usage[] ImportUsage(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        var usage = new Usage[lines.Length - 1];
        for (var i = 1; i < lines.Length; i++)
        {
            var line = lines[i].Split(',');
            var u = new Usage
            {
                Type = line[0],
                TimeStamp = DateTime.Parse(line[1]),
                CallLength = double.Parse(line[2]),
                Megabytes = double.Parse(line[3])
            };
            usage[i - 1] = u;
        }

        return usage;
    }
}
