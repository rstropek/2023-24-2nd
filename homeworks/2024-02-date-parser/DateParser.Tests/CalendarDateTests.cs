namespace RocketLander.Tests;

public class CalendarDateTests
{
    [Theory]
    [InlineData("")]
    [InlineData("12345")]
    [InlineData("12345678901234567890")]
    public void Throws_ArgumentOutOfRangeException(string dateString)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => CalendarDate.Parse(dateString));
    }

    [Theory]
    [InlineData("Trralalala")]
    [InlineData("31.12.....")]
    [InlineData("1a.12.2021")]
    [InlineData("10.1a.2021")]
    [InlineData("10.12.20a1")]
    [InlineData("10.02.-100")]
    [InlineData("+1.02.2021")]
    [InlineData("01/02/2021")]
    public void Throws_FormatException(string dateString)
    {
        Assert.Throws<FormatException>(() => CalendarDate.Parse(dateString));
    }

    [Theory]
    [InlineData("32.01.2021")]
    [InlineData("15.13.2021")]
    [InlineData("30.02.2021")]
    public void Throws_InvalidDateException(string dateString)
    {
        Assert.Throws<InvalidDateException>(() => CalendarDate.Parse(dateString));
    }

    [Theory]
    [InlineData("29.02.2021")]
    [InlineData("29.02.2023")]
    [InlineData("29.02.2100")]
    public void Throws_InvalidDateException_leapyear(string dateString)
    {
        Assert.Throws<InvalidDateException>(() => CalendarDate.Parse(dateString));
    }

    [Theory]
    [InlineData("01.01.2021", 2021, 1, 1)]
    [InlineData("31.12.2021", 2021, 12, 31)]
    [InlineData("01.01.0000", 0, 1, 1)]
    [InlineData("31.12.9999", 9999, 12, 31)]
    [InlineData("28.02.2023", 2023, 2, 28)]
    public void Sucessful_parse(string dateString, int year, int month, int day)
    {
        var date = CalendarDate.Parse(dateString);
        Assert.Equal(year, date.Year);
        Assert.Equal(month, date.Month);
        Assert.Equal(day, date.Day);
    }

    [Theory]
    [InlineData("29.02.2020", 2020, 2, 29)]
    [InlineData("29.02.2024", 2024, 2, 29)]
    [InlineData("29.02.2000", 2000, 2, 29)]
    public void Sucessful_parse_leapyear(string dateString, int year, int month, int day)
    {
        var date = CalendarDate.Parse(dateString);
        Assert.Equal(year, date.Year);
        Assert.Equal(month, date.Month);
        Assert.Equal(day, date.Day);
    }
}