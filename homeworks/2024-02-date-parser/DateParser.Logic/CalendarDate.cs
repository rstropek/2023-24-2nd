namespace DateParser.Logic;

public class CalendarDate(int year, int month, int day)
{
    public int Year { get; private set; } = year;
    public int Month { get; private set; } = month;
    public int Day { get; private set; } = day;

    /// <summary>
    /// Parses the given date string into a CalendarDate object.
    /// </summary>
    /// <param name="dateString">Date string to parse</param>
    /// <returns>
    /// Calendar date object
    /// </returns>
    /// <remarks>
    /// Parses a date expression from a string in the format "dd.MM.yyyy".
    /// dd, MM, and yyyy must be numbers. The resulting date must be a valid date.
    /// Note leap years: A year is a leap year if it is divisible by 4.
    /// However, if the year is a century year (ending in 00), it must 
    /// also be divisible by 400 to be a leap year.
    /// Note that you MUST NOT use methods from DateTime or related classes.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if the date string is empty or the date string does not have a
    /// length of 10 characters.
    /// </exception>
    /// <exception cref="InvalidDateException">
    /// Thrown if the date string is syntactically valid, but the date itself is invalid (e.g. February 30th)
    /// </exception>
    /// <exception cref="FormatException">
    /// Thrown if the date string is not in the expected format
    /// </exception>
    public static CalendarDate Parse(string dateString)
    {
        // TODO: Implement this method
        throw new NotImplementedException();
    }
}

public static class CalendarResponseBuilder
{
    /// <summary>
    /// Tries to parse the given date string and returns a response string.
    /// </summary>
    /// <param name="date">Date string to parse</param>
    /// <returns>
    /// One of the following responses:
    /// - "The date is valid. It is the dd.MM.yyyy." (replace dd, MM, yyyy with the actual date)
    /// - "Date string has invalid length" (in case of ArgumentOutOfRangeException)
    /// - "Date string has invalid format" (in case of FormatException)
    /// - "The date is invalid" (in case of InvalidDateException)
    /// </returns>
    public static string BuildResponse(string dateString)
    {
        // TODO: Implement this method
        throw new NotImplementedException();
    }
}

public class InvalidDateException : Exception
{
    public InvalidDateException() { }

    public InvalidDateException(string message) : base(message) { }

    public InvalidDateException(string message, Exception innerException) : base(message, innerException) { }
}
