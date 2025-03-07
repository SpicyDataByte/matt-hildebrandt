string data = "matt,celine,kai,kira";

List<string> firstNames = data.Split(',').ToList();

//var can be any type and system will figure it out

foreach (string firstName in firstNames)
{
    Console.WriteLine(firstName);
}