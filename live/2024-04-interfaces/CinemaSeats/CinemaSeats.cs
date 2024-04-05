using System.Security.Cryptography;

namespace CinemaSeats;

public abstract class Ticket(int row, int seat)
{
    public int Row { get; } = row;
    public int Seat { get; } = seat;

    public virtual decimal Price => Row switch {
        <= 3 => 10m,
        <= 7 => 12m,
        _ => 15m,
    };
}

public class VipTicket(int row, int seat) : Ticket(row, seat)
{
    public override decimal Price => 30m;
}

public class ChildTicket(int row, int seat) : Ticket(row, seat)
{
    public override decimal Price => base.Price / 2;
}
