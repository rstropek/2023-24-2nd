namespace TrainSwitching.Logic;

public class SwitchingOperation
{
    public int TrackNumber { get; set; }

    public int OperationType { get; set; }

    public int Direction { get; set; }

    public int? WagonType { get; set; }

    public int? NumberOfWagons { get; set; }
}