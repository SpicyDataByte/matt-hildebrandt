//Ask user for first name
//keep adding names until no more
//loop and say hello name

List<string> namesList = new();

while (true) 
{

    Console.Write("Type done to finish. What is your name?: ");
    string firstNames = Console.ReadLine();
    if (firstNames.ToLower() == "done")
    {
        break;
    }
    
    namesList.Add(firstNames);
}
Console.WriteLine();

foreach (string name in namesList)
{
    Console.WriteLine($"Hello {name}");
}