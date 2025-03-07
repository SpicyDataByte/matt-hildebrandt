
try
{
    ThrowException();
}
catch (Exception ex)
{
    Console.WriteLine($"An exception was caught. This is the message: \n{ex.Message}");
    Console.WriteLine();
    Console.WriteLine($"This is the stack trace: \n{ex.StackTrace}");
}


static void ThrowException()
{
    throw new Exception("This is an example exception.");
}