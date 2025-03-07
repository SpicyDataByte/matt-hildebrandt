//Only runs one line under else if no curly brace
//add return to stop program

//bool isComplete = true;

//if(isComplete)
//{
//    Console.WriteLine("Statement True");
//    Console.WriteLine("a second true line");
//}
//else
//{
//    Console.WriteLine("Statement False");
//}

Console.WriteLine("What is your name?");
string? firstName = Console.ReadLine();

if (firstName.ToLower() == "matt")
{
    Console.WriteLine("Hi Dad");
}
else
{
    Console.WriteLine($"Hello {firstName}");
}