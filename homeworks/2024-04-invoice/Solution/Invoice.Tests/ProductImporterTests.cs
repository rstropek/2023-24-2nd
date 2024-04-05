using Invoice.Logic;

public class ProductImporterTests
{
    [Fact]
    public void Import_WithValidLines_ReturnsProducts()
    {
        var lines = """
            EAN,Name,VATPercentage,NetPrice,UnitOfMeasure,IsMultiPack
            3548769012345,Apples,20,1.50,kg,false
            4567129034587,Bananas,20,0.30,kg,false
            9821345678901,Bread,20,2.00,pcs,false
            8976543210987,Cheese,20,5.00,kg,false
            6754890123678,Chicken Breasts,20,8.00,kg,false
            1234567890123,Tomatoes,20,1.20,kg,false
            8912345670123,Rice,20,2.50,pcs,true
            4587091234567,Eggs (Dozen),20,2.50,pcs,false
            6753091287456,Butter 250g,20,3.00,pcs,false
            2109876543987,Orange Juice,20,1.80,pcs,true
            1098765432901,Mineral Water (6-pack),20,3.50,pcs,true
            5678932104987,Chocolate Bar,20,1.20,pcs,false
            8709234567812,Ground Beef,20,7.00,kg,false
            1234567890234,Spaghetti,20,1.50,pcs,true
            8790234561876,Shampoo,20,4.50,pcs,false
            4567891230789,Toilet Paper (Pack of 4),20,3.00,pcs,false
            2145638901278,AA Batteries (Pack of 8),20,5.50,pcs,false
            2145689701234,Yogurt,20,0.80,pcs,false
            8745690123456,Salad Mix,20,2.00,pcs,false
            5678901234012,Steak,20,15.00,kg,false
            5678901238901,Applesauce,20,1.50,pcs,false
            9012345678902,Potatoes,20,0.80,kg,false
            1234012345678,Orange (Net),20,0.60,pcs,true
            4012345678901,Almonds,20,3.50,kg,false
            7890123456789,Coffee,20,6.00,pcs,true
            """.Split("\n");

        var importer = new ProductImporter();

        var products = importer.Import(lines);

        Assert.Equal(25, products.Count());
        Assert.Equal("3548769012345", products.First().EAN);
        Assert.Equal("Apples", products.First().Name);
        Assert.Equal(VATPercentage.Standard, products.First().VATPercentage);
        Assert.Equal(1.50m, products.First().NetPrice);
        Assert.Equal(UnitOfMeasure.Kilograms, products.First().UnitOfMeasure);
        Assert.False(products.First().IsMultipack);
    }

    [Fact]
    public void Import_WithEmptyLines_ThrowsProductImportException()
    {
        var lines = Array.Empty<string>();

        var importer = new ProductImporter();

        Assert.Throws<ProductImportException>(() => importer.Import(lines));
    }

    [Fact]
    public void Import_WithInvalidHeader_ThrowsProductImportException()
    {
        var lines = new string[]
        {
            "InvalidHeader"
        };

        var importer = new ProductImporter();

        Assert.Throws<ProductImportException>(() => importer.Import(lines));
    }

    [Fact]
    public void Import_WithInvalidLine_ThrowsProductImportException()
    {
        var lines = new string[]
        {
            "EAN,Name,VATPercentage,NetPrice,UnitOfMeasure,IsMultiPack",
            "InvalidLine"
        };

        var importer = new ProductImporter();

        Assert.Throws<ProductImportException>(() => importer.Import(lines));
    }

    [Fact]
    public void Import_WithInvalidNetPrice_ThrowsProductImportException()
    {
        var lines = new string[]
        {
            "EAN,Name,VATPercentage,NetPrice,UnitOfMeasure,IsMultiPack",
            "1234567890123,Product1,Standard,InvalidNetPrice,pcs,false"
        };

        var importer = new ProductImporter();

        Assert.Throws<ProductImportException>(() => importer.Import(lines));
    }

    [Fact]
    public void Import_WithInvalidUnitOfMeasure_ThrowsProductImportException()
    {
        var lines = new string[]
        {
            "EAN,Name,VATPercentage,NetPrice,UnitOfMeasure,IsMultiPack",
            "1234567890123,Product1,Standard,100,InvalidUnitOfMeasure,false"
        };

        var importer = new ProductImporter();

        Assert.Throws<ProductImportException>(() => importer.Import(lines));
    }

    [Fact]
    public void Import_WithInvalidIsMultiPack_ThrowsProductImportException()
    {
        var lines = new string[]
        {
            "EAN,Name,VATPercentage,NetPrice,UnitOfMeasure,IsMultiPack",
            "1234567890123,Product1,Standard,100,pcs,InvalidIsMultiPack"
        };

        var importer = new ProductImporter();

        Assert.Throws<ProductImportException>(() => importer.Import(lines));
    }

    [Fact]
    public void Import_WithInvalidVATPercentage_ThrowsProductImportException()
    {
        var lines = new string[]
        {
            "EAN,Name,VATPercentage,NetPrice,UnitOfMeasure,IsMultiPack",
            "1234567890123,Product1,InvalidVATPercentage,100,pcs,false"
        };

        var importer = new ProductImporter();

        Assert.Throws<ProductImportException>(() => importer.Import(lines));
    }

    [Fact]
    public void Import_WithNegativePrice_ThrowsProductImportException()
    {
        var lines = new string[]
        {
            "EAN,Name,VATPercentage,NetPrice,UnitOfMeasure,IsMultiPack",
            "1234567890123,Product1,Standard,-100,pcs,false"
        };

        var importer = new ProductImporter();

        Assert.Throws<ProductImportException>(() => importer.Import(lines));
    }
}