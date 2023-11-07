namespace PhoneTariff.Logic;

public abstract class Tariff
{
    public abstract decimal CalculateFee(double megabytes);
}

public abstract class TariffWithBaseFee : Tariff
{
    public decimal MonthlyFee { get; set; }
}

public class FlatFee : TariffWithBaseFee
{
    public override decimal CalculateFee(double _) => MonthlyFee;
}

public class PayAsYouGo : Tariff
{
    public decimal PricePerMegabyte { get; set; }

    public override decimal CalculateFee(double megabytes)
        => PricePerMegabyte * (decimal)megabytes;
}

public class Mixed : TariffWithBaseFee
{
    public double IncludedMegabytes { get; }
    public decimal PricePerMegabyte { get; }

    public Mixed(decimal monthlyFee, double includedMegabytes, decimal pricePerMegabyte)
    {
        MonthlyFee = monthlyFee;
        IncludedMegabytes = includedMegabytes;
        PricePerMegabyte = pricePerMegabyte;
    }

    public override decimal CalculateFee(double megabytes)
    {
        var fee = MonthlyFee;
        if (megabytes > IncludedMegabytes)
        {
            fee += (decimal)(megabytes - IncludedMegabytes) * PricePerMegabyte;
        }

        return fee;
    }
}