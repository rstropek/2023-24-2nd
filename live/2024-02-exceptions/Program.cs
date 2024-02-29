ExplicitException();
//ArgumentException(null);
//ArgumentException(-1);
//ImplicitException1(1, 0);
//ImplicitException2();
//ImplicitException3();
//ThrowMyException();

void ExplicitException()
{
    throw new NotImplementedException();
    // throw new ApplicationException("This is an application exception");
    // throw new InvalidOperationException("This is an invalid operation exception");
}

void ArgumentException(int? val)
{
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
    return divisor / dividend;
}

void ImplicitException2()
{
    ImplicitException2();
}

int ImplicitException3()
{
    var numbers = new string[5];
    return numbers[0].Length;
}

void CatchAllExceptions()
{
    try
    {
        ExplicitException();
    }
    catch
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
        Console.WriteLine($"Exception caught: {ex.Message}");
    }
}

void CatchSpecificExceptions()
{
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
    catch (Exception ex)
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
        throw;
    }
}

void FinallyBlock()
{
    try
    {
        ExplicitException();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception caught: {ex.Message}");
    }
    finally
    {
        Console.WriteLine("Finally block executed");
    }
}

void ThrowMyException()
{
    try
    {
        throw new MyException();
    }
    catch (MyException ex)
    {
        Console.WriteLine($"MyException caught: {ex.Message}");
    }
}

class MyException : Exception
{
    public MyException() : base("Rocket crashed into the ground") { }

    public MyException(string message) : base(message) { }

    public MyException(string message, Exception innerException) : base(message, innerException) { }
}
