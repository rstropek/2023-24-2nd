using Invoice.Logic;

namespace Invoice.Tests
{
    public class InvoiceLineImporterTests
    {
        [Fact]
        public void Import_InvoiceLine_Success()
        {
            var importer = new LineImporter();
            var line = "IL,3548769012345,2.5";
            var result = importer.Import(line);
            Assert.IsType<InvoiceLine>(result);
        }

        [Fact]
        public void Import_DiscountLine_Success()
        {
            var importer = new LineImporter();
            var line = "D,5";
            var result = importer.Import(line);
            Assert.IsType<DiscountLine>(result);
        }

        [Fact]
        public void Import_EmptyLine_ThrowsException()
        {
            var importer = new LineImporter();
            var line = "";
            Assert.Throws<InvoiceLineImportException>(() => importer.Import(line));
        }

        [Fact]
        public void Import_MissingData_ThrowsException()
        {
            var importer = new LineImporter();
            var line = "IL";
            Assert.Throws<InvoiceLineImportException>(() => importer.Import(line));
        }

        [Fact]
        public void Import_InvoiceLineMissingData_ThrowsException()
        {
            var importer = new LineImporter();
            var line = "IL,3548769012345";
            Assert.Throws<InvoiceLineImportException>(() => importer.Import(line));
        }

        [Fact]
        public void Import_QuantityNotNumber_ThrowsException()
        {
            var importer = new LineImporter();
            var line = "IL,3548769012345,abc";
            Assert.Throws<InvoiceLineImportException>(() => importer.Import(line));
        }

        [Fact]
        public void Import_DiscountLineMissingData_ThrowsException()
        {
            var importer = new LineImporter();
            var line = "D";
            Assert.Throws<InvoiceLineImportException>(() => importer.Import(line));
        }

        [Fact]
        public void Import_PercentageNotNumber_ThrowsException()
        {
            var importer = new LineImporter();
            var line = "D,abc";
            Assert.Throws<InvoiceLineImportException>(() => importer.Import(line));
        }

        [Fact]
        public void Import_UnknownLineType_ThrowsException()
        {
            var importer = new LineImporter();
            var line = "XYZ,3548769012345,2.5";
            Assert.Throws<InvoiceLineImportException>(() => importer.Import(line));
        }
    }
}