namespace ServiceFeeCalculator.Level4;

public abstract class RepairJob
{
    public string Description { get; set; } = "";
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool Successful { get; set; }

    // Tipp: All repair costs depend on the duration in hours. 
    // You can offer a helper property for calculating the duration.
    protected double Duration => (End - Start).TotalHours;

    public abstract decimal CalculateFee();
}

public abstract class TeamRepairJob : RepairJob
{
    public int NumberOfMechanics { get; set; } = 1;

    public override decimal CalculateFee() => CalculateFeeSingleMechanic() * NumberOfMechanics;

    protected abstract decimal CalculateFeeSingleMechanic();
}

public class BasicRepairJob : TeamRepairJob
{
    // Done by a junior mechanic
    // 5€ per started quarter of an hour
    // Must be paid even if repairing was not possible
    // Basic repair jobs are sometimes done by more than one mechanic

    protected override decimal CalculateFeeSingleMechanic()
    {
        var quarters = (int)Math.Ceiling(Duration * 4);
        return quarters * 5 * NumberOfMechanics;
    }
}

public class RegularRepairJob : TeamRepairJob
{
    // Done by a *senior mechanic*
    // 80€ per started hour
    // Must be paid even if repairing was not possible

    // Note the different syntax compared to BasicRepairJob.
    // This is another way to write the same thing.
    protected override decimal CalculateFeeSingleMechanic() => (int)Math.Ceiling(Duration) * 80;
}

public class ComplexRepairJob : RepairJob
{
    // Done by a *master mechanic*
    // 500€ if repaired within four hours (no rounding to full hours)
    // Flat fee of 800€ if it takes longer
    // Nothing is to pay if repairing was not possible

    public override decimal CalculateFee()
    {
        if (Duration <= 4)
        {
            return 500;
        }

        return 800;
    }
}
