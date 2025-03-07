//Take a list of names csv no space

//Loop through and print hello name

Console.WriteLine("List some names in following format name1,name2,name3:");
string firstNames = Console.ReadLine();

List<string> listNames = firstNames.Split(',').ToList();

for (int i = 0; i < listNames.Count; i++)
{
    Console.WriteLine($"Hello {listNames[i]} ");
}