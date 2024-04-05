namespace Invoice.Logic;

public class InvoiceCalculator(IEnumerable<Product> products, IEnumerable<Line> lines)
{
    private IEnumerable<Product> Products { get; } = products;
    private IEnumerable<Line> Lines { get; } = lines;

    private Product? GetProduct(string ean)
    {
        foreach(var product in Products)
        {
            if (product.EAN == ean)
            {
                return product;
            }
        }

        return null;
    }

    /// <summary>
    /// Calculates the total amount of the invoice.
    /// </summary>
    /// <remarks>
    /// The total amount is calculated by summing up the net total of all lines.
    /// For products that that have IsMultipack == true, the customer gets every
    /// third item for free (e.g. buy 3, pay 2; buy 5, pay 4; buy 6, pay 4, etc.). The total discount percentage must
    /// be applied before returning the total amount.
    /// </remarks>
    public decimal CalculateNetTotal()
    {
        var totalDiscountPercentage = 0m;
        foreach(var line in Lines)
        {
            if (line is DiscountLine discountLine)
            {
                totalDiscountPercentage += discountLine.Percentage;
            }
        }

        var netTotal = 0m;
        foreach(var line in Lines)
        {
            if (line is InvoiceLine invoiceLine)
            {
                var product = GetProduct(invoiceLine.EAN);
                if (product == null)
                {
                    throw new InvoiceCalculationException($"Product with EAN {invoiceLine.EAN} not found");
                }

                if (product.IsMultipack)
                {
                    var freeItems = Math.Floor(invoiceLine.Quantity / 3);
                    var totalItems = invoiceLine.Quantity - freeItems;
                    netTotal += totalItems * product.NetPrice;
                }
                else
                {
                    netTotal += invoiceLine.Quantity * product.NetPrice;
                }
            }
        }

        return netTotal * (1 - totalDiscountPercentage / 100);
    }
    
    /// <summary>
    /// Bonus exercise: Calculates the total discount amount of the invoice.
    /// </summary>
    /// <remarks>
    /// The total discount is the saved costs from multipacks plus the saved costs from the discount percentage.
    /// </remarks>
    public decimal CalculateTotalDiscount()
    {
        throw new NotImplementedException();
    }
}

public class InvoiceCalculationException : Exception
{
    public InvoiceCalculationException() { }

    public InvoiceCalculationException(string message) : base(message) { }

    public InvoiceCalculationException(string message, Exception innerException) : base(message, innerException) { }
}
