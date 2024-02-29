namespace DateParser.Tests;


public class CalendarResponseBuilderTests
{
    [Fact]
    public void BuildResponse_ValidDate_ReturnsValidDateMessage()
    {
        var response = CalendarResponseBuilder.BuildResponse("01.02.2022");
        Assert.Equal("The date is valid. It is the 01.02.2022.", response);
    }

    [Fact]
    public void BuildResponse_InvalidLength_ReturnsInvalidLengthMessage()
    {
        var response = CalendarResponseBuilder.BuildResponse("01.01.22");
        Assert.Equal("Date string has invalid length", response);
    }

    [Fact]
    public void BuildResponse_InvalidFormat_ReturnsInvalidFormatMessage()
    {
        var response = CalendarResponseBuilder.BuildResponse("01/01/2022");
        Assert.Equal("Date string has invalid format", response);
    }

    [Fact]
    public void BuildResponse_InvalidDate_ReturnsInvalidDateMessage()
    {
        var response = CalendarResponseBuilder.BuildResponse("30.02.2022");
        Assert.Equal("The date is invalid", response);
    }
}