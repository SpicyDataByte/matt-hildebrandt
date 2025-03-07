// ask for name

//if tim call professor

//else student

//do until exit
string firstName;

do
{
    Console.Write("What is name?: ");
    firstName = Console.ReadLine();

    if (firstName.ToLower() == "tim")
    {
        Console.WriteLine("Hello Professor.");
    }
    else if (firstName.ToLower() == "exit")
    {
        return;
    }
    else
    {
        Console.WriteLine("Hello Student.");
    }
} while (firstName.ToLower() != "exit");