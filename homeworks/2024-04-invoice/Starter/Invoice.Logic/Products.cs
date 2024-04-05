namespace Invoice.Logic;

public enum UnitOfMeasure
{
    Pieces,
    Kilograms,
}

public enum VATPercentage
{
    Reduced = 10,
    Standard = 20,
}

public record Product(
    string EAN,
    string Name,
    VATPercentage VATPercentage,
    decimal NetPrice,
    UnitOfMeasure UnitOfMeasure,
    bool IsMultipack
);

public class ProductImporter
{
    /// <summary>
    /// Imports products from the given lines.
    /// </summary>
    /// <param name="lines">Lines read from a file that should be imported</param>
    /// <returns>
    /// Collection of products
    /// </returns>
    /// <exception cref="ProductImportException">Thrown when the import fails</exception>
    /// <remarks>
    /// The import can fail unter the following conditions:
    /// - <paramref name="lines"/> is empty
    /// - The header line is missing or contains invalid column names or the order of columns is wrong
    /// - A line contains invalid data (missing column, empty column, wrong data type, negative values)
    /// - IsMultiPack is true when unit of measure is not Pieces
    /// In all cases, the exception message should contain a meaningful error message.
    /// </remarks>
    public IEnumerable<Product> Import(string[] lines)
    {
        throw new NotImplementedException();
    }
}

public class ProductImportException : Exception
{
    public ProductImportException() { }

    public ProductImportException(string message) : base(message) { }

    public ProductImportException(string message, Exception innerException) : base(message, innerException) { }
}
