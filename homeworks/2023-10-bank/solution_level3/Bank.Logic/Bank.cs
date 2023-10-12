namespace Bank.Logic;

public abstract class Account
{
    public string AccountNumber { get; set; } = "";
    public string AccountHolder { get; set; } = "";
    public decimal Balance { get; set; }

    public abstract bool IsAllowed(Transaction t);

    public bool TryExecute(Transaction t)
    {
        if (IsAllowed(t))
        {
            Balance += t.Amount;
            return true;
        }

        return false;
    }
}

public class Savings : Account
{
    public override bool IsAllowed(Transaction t)
    {
        return t.AccountNumber == AccountNumber
            && (Balance + t.Amount) is >= 0 and <= 100_000_000;
    }
}

public class CheckingAccount : Account
{
    public override bool IsAllowed(Transaction t)
    {
        return t.AccountNumber == AccountNumber
            && Math.Abs(t.Amount) <= 10_000
            && (Balance + t.Amount) is >= -10_000 and <= 10_000_000;
    }
}

public class BusinessAccount : Account
{
    public override bool IsAllowed(Transaction t)
    {
        return t.AccountNumber == AccountNumber
            && Math.Abs(t.Amount) <= 100_000
            && (Balance + t.Amount) is >= -1_000_000 and <= 100_000_000;
    }
}

public class FixedDeposite : Account
{
    public DateOnly OpeningDate { get; set; }
    public DateOnly FixedUntil { get; set; }

    public override bool IsAllowed(Transaction t)
    {
        return t.AccountNumber == AccountNumber
            && ((t.Amount >= 0 && DateOnly.FromDateTime(t.Timestamp.Date) == OpeningDate)
                || (t.Amount < 0 && DateOnly.FromDateTime(t.Timestamp.Date) >= FixedUntil))
            && (Balance + t.Amount) is >= 0 and <= 10_000_000;
    }
}

public class Transaction
{
    public string AccountNumber { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime Timestamp { get; set; }
    public decimal Amount { get; set; }
}
