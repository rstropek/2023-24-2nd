//ExplicitException();
//CallLevel1();
//ArgumentException(null);
//ArgumentException(-1);
ImplicitException1(1, 0);
//ImplicitException2();
//ImplicitException3();
//MethodsThatThrow();
//MethodsThatDoNotThrow();
//ThrowMyException();
//CatchAllExceptions();
//CatchAllExceptionsAndAccessException();
//CatchSpecificExceptions();
//CatchWithFilter();
//RethrowException();
//FinallyBlock();

void ExplicitException()
{
    // NOTE: This is how you explicitly throw an exception
    throw new NotImplementedException();

    // There are many different exceptions types. Make yourself familiar
    // with them: https://learn.microsoft.com/en-us/dotnet/standard/exceptions/#common-exceptions and subsequent
    // throw new ApplicationException("This is an application exception");
    // throw new InvalidOperationException("This is an invalid operation exception");
}

void CallLevel3()
{
    // This throw statement will end CallLevel3
    throw new ApplicationException("This is an application exception");
}

void CallLevel2()
{
    // There is no try-catch block here, so the exception will be thrown to the caller
    CallLevel3();
}

void CallLevel1()
{
    // This try-catch block will catch the exception thrown by CallLevel3
    try
    {
        Console.WriteLine("Before");
        CallLevel2();
        Console.WriteLine("After");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception caught: {ex.Message}");
    }
}

void ArgumentException(int? val)
{
    // Here you see exceptions related to invalid arguments

    if (val is null)
    {
        throw new ArgumentNullException(nameof(val));
    }

    if (val < 0)
    {
        throw new ArgumentException("Value must be greater than 0", nameof(val));
    }
}

int ImplicitException1(int divisor, int dividend)
{
    // Sometimes, operations implicitely throw exceptions.
    // Here: Division by zero
    return divisor / dividend;
}

void ImplicitException2()
{
    // Here: Endless recursion (stack overflow)
    ImplicitException2();
}

int ImplicitException3()
{
    // Here: Null reference
    var numbers = new string[5];
    return numbers[0].Length;
}

void MethodsThatThrow()
{
    // Class libraries often contain different versions of methods. Some throw exceptions,
    // some don't. Here: Parse throws an exception if the string is not a number.
    var number = int.Parse("abc");

    // NOTE!!!!!
    // Do use exceptions for EXCEPTIONAL conditions. Do NOT use exceptions for regular control flow.
}

void MethodsThatDoNotThrow()
{
    // Here: TryParse does NOT throw an exception if the string is not a number.
    if (!int.TryParse("abc", out var number))
    {
        Console.WriteLine("Invalid number");
    }
}

void CatchAllExceptions()
{
    // Exceptions can be caught in a try-catch block. The catch block will handle all exceptions
    // that appeared in the try block (or in methods called from the try block).
    try
    {
        ExplicitException();
    }
    catch // This catches all types of exceptions
    {
        Console.WriteLine($"Exception caught");
    }
}

void CatchAllExceptionsAndAccessException()
{
    try
    {
        ExplicitException();
    }
    catch (Exception ex)
    {
        // This catches all types of exceptions. Additionally, we can access the
        // exception object in the catch block. This can be useful for e.g. logging.
        Console.WriteLine($"Exception caught: {ex.Message}");
    }
}

void CatchSpecificExceptions()
{
    // Here you see how to catch SPECIFIC exceptions.
    try
    {
        ExplicitException();
    }
    catch (NotImplementedException ex)
    {
        Console.WriteLine($"NotImplementedException caught: {ex.Message}");
    }
    catch (ApplicationException ex)
    {
        Console.WriteLine($"ApplicationException caught: {ex.Message}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"InvalidOperationException caught: {ex.Message}");
    }
    catch (Exception ex) // This catches all other exceptions
    {
        Console.WriteLine($"Exception caught: {ex.Message}");
    }
}

void CatchWithFilter()
{
    // You can even add filter conditions to catch blocks.
    try
    {
        throw new ApplicationException("My spaceship exploded");
    }
    catch (Exception ex) when (ex.Message.Contains("spaceship"))
    {
        Console.WriteLine($"Exception caught: {ex.Message}");
    }
}

void RethrowException()
{
    try
    {
        ExplicitException();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception caught: {ex.Message}");

        // You can rethrow the exception. This is useful if you want to log the exception
        // and then let it "bubble up" to the caller.
        throw;
    }
}

void FinallyBlock()
{
    try
    {
        // Open a file here
        ExplicitException();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception caught: {ex.Message}");
    }
    finally
    {
        // Close the file

        // The finally block is executed no matter if an exception was thrown or not.
        // It is useful for cleanup code (e.g. closing a previously opened file or database connection).
        Console.WriteLine("Finally block executed");
    }
}

void ThrowMyException()
{
    // You can create custom exception types by deriving from Exception.
    // Here, we throw and catch a custom exception type.
    try
    {
        throw new MyException("This is the reason of the exception: ...");
    }
    catch (MyException ex)
    {
        Console.WriteLine($"MyException caught: {ex.Message}");
    }
}

class MyException : Exception
{
    public MyException() : base("Something bad happened, I don't know exactly what") { }

    public MyException(string message) : base(message) { }

    public MyException(string message, Exception innerException) : base(message, innerException) { }
}
