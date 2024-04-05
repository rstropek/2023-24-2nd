namespace Invoice.Logic;

public abstract class Line { }

public class InvoiceLine(string ean, decimal quantity) : Line
{
    public string EAN { get; } = ean;
    public decimal Quantity { get; } = quantity;
}

public class DiscountLine(decimal percentage) : Line
{
    public decimal Percentage { get; } = percentage;
}

public class LineImporter
{
    /// <summary>
    /// Imports an invoice line or a discount line from the given string.
    /// </summary>
    /// <param name="line">Line of text read from a file that should be imported</param>
    /// <returns>
    /// Line of an invoice or a discount
    /// </returns>
    /// <exception cref="InvoiceLineImportException">Thrown when the import fails</exception>
    /// <remarks>
    /// The import can fail unter the following conditions:
    /// - <paramref name="line"/> is empty
    /// - A line contains invalid data (missing column, empty column, wrong data type, negative values)
    /// In all cases, the exception message should contain a meaningful error message.
    /// </remarks>
    public Line Import(string line)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Imports an invoice and discount lines from the given string array.
    /// </summary>
    /// <param name="lines">Lines read from a file that should be imported</param>
    /// <returns>
    /// Collection of lines and discounts
    /// </returns>
    /// <exception cref="InvoiceLineImportException">Thrown when the import fails</exception>
    /// <remarks>
    /// The import can fail unter the following conditions:
    /// - <paramref name="lines"/> is empty
    /// - The header line is missing or contains invalid column names or the order of columns is wrong
    /// - A line contains invalid data (missing column, empty column, wrong data type, negative values)
    /// - The same EAN appears multiple times in the lines
    /// In all cases, the exception message should contain a meaningful error message.
    /// </remarks>
    public IEnumerable<Line> Import(string[] lines)
    {
        throw new NotImplementedException();
    }
}

public class InvoiceLineImportException : Exception
{
    public InvoiceLineImportException() { }

    public InvoiceLineImportException(string message) : base(message) { }

    public InvoiceLineImportException(string message, Exception innerException) : base(message, innerException) { }
}

