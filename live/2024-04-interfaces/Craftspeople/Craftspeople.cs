namespace Craftspeople;

public abstract class CraftspersonEffort(decimal hours)
{
    public decimal Hours { get; } = hours;

    public abstract decimal PricePerHour { get; }

    public virtual decimal TotalPrice => Hours * PricePerHour;
}

public enum DayType
{
    Regular,
    Saturday,
    Sunday,
};

public class JuniorCraftspersonEffort(decimal hours, DayType specialDay) : CraftspersonEffort(hours)
{
    public override decimal PricePerHour => specialDay switch {
        DayType.Regular => 50m,
        DayType.Saturday => 50m * 1.5m,
        DayType.Sunday => 50m * 2m,
        _ => throw new InvalidOperationException("Invalid day type, this should NEVER happen"),
    };

    public override decimal TotalPrice => Math.Ceiling(Hours) * PricePerHour;
}

public class MasterCraftspersonEffort(decimal hours) : CraftspersonEffort(hours)
{
    public override decimal PricePerHour => 150m;

    public override decimal TotalPrice => Hours switch {
        <= 4 => Math.Round(PricePerHour) * PricePerHour,
        _ => 4m * PricePerHour
    };
}
