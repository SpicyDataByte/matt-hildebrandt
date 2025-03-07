Console.WriteLine("What is you age");

string? ageText = Console.ReadLine();
Console.WriteLine(ageText + 15); // Concats because ageText is still a string

//int age = int.Parse(ageText); // get the int from string


bool isValidInt = int.TryParse(ageText, out int age); //avoids system crash by testing if its valid int first

Console.WriteLine($"This is valid: {isValidInt}. The number was {age}.");
Console.WriteLine(age + 15);

//cast

double testDouble = age;
Console.WriteLine($"testDouble = {testDouble}");
decimal testDecimal = (decimal) testDouble;
Console.WriteLine($"testDecimal = {testDecimal}");