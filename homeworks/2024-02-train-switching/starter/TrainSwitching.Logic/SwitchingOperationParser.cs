namespace TrainSwitching.Logic;

public static class SwitchingOperationParser
{
    /// <summary>
    /// Parses a line of input into a <see cref="SwitchingOperation"/>.
    /// </summary>
    /// <param name="inputLine">Line to parse. See readme.md for details</param>
    /// <returns>The parsed switching operation</returns>
    public static SwitchingOperation Parse(string inputLine)
    {
        // TODO: Implement this method
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Parses the given input bytes into a SwitchingOperation.
    /// </summary>
    /// <param name="inputBytes">Input bytes, structure see comments below</param>
    /// <returns>Switching operation</returns>
    public static SwitchingOperation Parse(byte[] inputBytes)
    {
        // inputBytes[0]:
        // * 4 bits for track number
        // * 4 bits for operation type
        // inputBytes[1]:
        // * 1 bit for direction
        // * Last 7 bits:
        //   * if operation is add, 7 bits for wagon type
        //   * if operation is remove, 7 bits for number of wagons
        //   * if operation is train leave, 7 zero bits

        // TODO: Implement this method
        throw new NotImplementedException();
    }
}