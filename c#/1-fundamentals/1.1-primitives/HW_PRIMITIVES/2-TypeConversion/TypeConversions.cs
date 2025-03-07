Console.WriteLine("Hi what is your age?");
string? ageText = Console.ReadLine();
int age = int.Parse(ageText);
int future25 = age + 25;
int past25 = age - 25;
Console.WriteLine($"In 25 years you will be {future25}.");
Console.WriteLine($"25 years ago you were {past25}.");
