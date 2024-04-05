namespace Invoicer.Abstractions;

public interface ITaxable
{
    decimal TaxRate { get; }
    
    decimal NetAmount { get; }

    decimal GrossAmount => NetAmount * (1 + TaxRate);
}
