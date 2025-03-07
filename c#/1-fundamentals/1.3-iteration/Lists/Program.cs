// list doesnt require you declare how big it needs to be before hand
// uses Count instead of length
List<string> firstNames = new List<string>();

firstNames.Add("Matt");
firstNames.Add("Celine");
firstNames.Add("Kai");
firstNames.Add("Kira");

Console.WriteLine(firstNames[firstNames.Count - 1]);

// List<T> = generic

string data = "Avs,Jets,Flames";
List<string> lastNames = data.Split(',').ToList();

Console.WriteLine(lastNames[lastNames.Count - 1]);
lastNames.Add("Sabres");
Console.WriteLine(lastNames[lastNames.Count - 1]);
