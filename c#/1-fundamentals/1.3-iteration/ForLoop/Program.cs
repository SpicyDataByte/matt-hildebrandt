//when you want to know position of element



for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"The value of i is {i}");
}

string data = "Matt,Celine,Kai,Kira";

List<string> firstNames = data.Split(',').ToList();

for (int i = 0; i < firstNames.Count; i++)
{
    Console.WriteLine(firstNames[i]);
}

List<decimal> money = new();

money.Add(40.28M);
money.Add(79.11M);
money.Add(4M);

decimal total = 0;

for (int i = 0; i < money.Count; i++)
{
    total += money[i];
}

Console.WriteLine($"Our total charge is {total}");