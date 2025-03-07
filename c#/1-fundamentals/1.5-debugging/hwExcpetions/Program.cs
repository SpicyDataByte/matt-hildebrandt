// throw an excpetion after 5 iterations and catch the exception


for (int i = 1; i < 10; i++)
{
	try
	{    
        if (i == 5)
		{
            throw new Exception("An exception has occurred at iteration: " + i);
		}
		Console.WriteLine("Iteration: " + i);
	}
	catch (Exception e)
	{

		Console.WriteLine("Caught exception: " + e.Message);
	}


	
    
}