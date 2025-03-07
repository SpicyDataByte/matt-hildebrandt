Dictionary<int, string> employees = new Dictionary<int, string>();


while (true)
{
    Console.Write("Enter a key: ");
    string key = Console.ReadLine();
    
    if (key.ToLower() == "done")
    {
        break;
    }

    int convertedKey = int.Parse(key);

    Console.Write("Enter a name: ");
    string value = Console.ReadLine();

    employees.Add(convertedKey, value);
};

Console.Write("\nEnter a number: ");
string inputKey = Console.ReadLine();
int convertedInputKey = int.Parse(inputKey);


Console.WriteLine($"The employee name with key {convertedInputKey} is {employees[convertedInputKey]}.");

