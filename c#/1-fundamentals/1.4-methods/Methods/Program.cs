// in .Net 6 all the methods are local to static Void main by default
using createMethod;
////could do using static createMethod.SampleMethods;
////or using static System.Console;
////be careful tho as can cause ambiguous calls

////Naming is CRITICAL so renamed to ConsoleMessages
////ctl + j allows you to change the method


////-----Call a Method + Parameters
ConsoleMessages.SayMyBoy();
ConsoleMessages.SayHiName("Matt");

for (int i = 0; i < 10; i++)
{
    Console.WriteLine("-----------------");
    ConsoleMessages.SayMyBoy();
    ConsoleMessages.SayHiName("Celine");
}

////-----Method Parameters
//Console.WriteLine("What is your name: "); //this line is now in GetUserName
string name = ConsoleMessages.GetUserName(); //Console.ReadLine(); is now in GetUserName

ConsoleMessages.SayHiName(name);

Console.WriteLine("------------------");

ConsoleMessages.SayGoodbye();

Console.ReadLine();
//////----Math Methods

////MathShortcuts.Add(5, 8);
//////// if a return variable is specified in method then
//////-----------Return Data
//////double result = MathShortcuts.Add(5,3); // makes debugging easier
//////Console.WriteLine($"the result is {result}");

////double[] vals = new double [] { 1, 2, 3, 4, 5, 6, 7, 8 };
////MathShortcuts.AddAll(vals);


////-----------Tuple: Use _ to ignore a return 
//(string firstName, string lastName) fullname  = ConsoleMessages.GetFullName();
//Console.WriteLine($"firstname: {fullname.firstName}");
//Console.WriteLine($"lastname: {fullname.lastName}");

////eliminates the need for "out" in int.TryParse(ageText, out int age)
