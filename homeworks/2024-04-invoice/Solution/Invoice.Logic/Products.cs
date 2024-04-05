using System.Globalization;

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
        if (lines.Length == 0)
        {
            throw new ProductImportException("No lines to import");
        }

        var header = lines[0].Split(',');

        if (header.Length != 6)
        {
            throw new ProductImportException("Invalid header");
        }

        if (header[0] != "EAN" ||
            header[1] != "Name" ||
            header[2] != "VATPercentage" ||
            header[3] != "NetPrice" ||
            header[4] != "UnitOfMeasure" ||
            header[5] != "IsMultiPack")
        {
            throw new ProductImportException("Invalid header");
        }

        var products = new List<Product>();
        for (var i = 1; i < lines.Length; i++)
        {
            var line = lines[i].Split(',');

            if (line.Length != 6)
            {
                throw new ProductImportException($"Invalid line {i}");
            }

            // Note: CultureInfo.InvariantCulture ensures that the english
            // number format is used.
            if (!decimal.TryParse(line[3], CultureInfo.InvariantCulture, out var netPrice) || netPrice < 0)
            {
                throw new ProductImportException($"Invalid NetPrice in line {i}");
            }

            if (line[4] is not "pcs" and not "kg")
            {
                throw new ProductImportException($"Invalid UnitOfMeasure in line {i}");
            }

            if (!bool.TryParse(line[5], out var isMultipack))
            {
                throw new ProductImportException($"Invalid IsMultiPack in line {i}");
            }

            if (!decimal.TryParse(line[2], CultureInfo.InvariantCulture, out var vatPercentage) || vatPercentage is not 10 and not 20)
            {
                throw new ProductImportException($"Invalid VATPercentage in line {i}");
            }

            products.Add(new Product(
                line[0],
                line[1],
                line[2] switch {
                    "10" => VATPercentage.Reduced,
                    "20" => VATPercentage.Standard,
                    _ => throw new ProductImportException($"Invalid VATPercentage in line {i}")
                },
                netPrice,
                line[4] switch {
                    "pcs" => UnitOfMeasure.Pieces,
                    "kg" => UnitOfMeasure.Kilograms,
                    _ => throw new ProductImportException($"Invalid UnitOfMeasure in line {i}")
                },
                isMultipack
            ));
        }

        return products;
    }
}

public class ProductImportException : Exception
{
    public ProductImportException() { }

    public ProductImportException(string message) : base(message) { }

    public ProductImportException(string message, Exception innerException) : base(message, innerException) { }
}
