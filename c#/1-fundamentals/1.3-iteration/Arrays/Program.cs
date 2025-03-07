// 0 based counting

    string [] firstNames = new string[5];

    Console.WriteLine(firstNames);

firstNames[0] = "Matt";
firstNames[1] = "Celine";
firstNames[2] = "Kai";
firstNames[3] = "Kira";
firstNames[4] = "Lyndsey";
int test = 0;

    Console.WriteLine($"The firstNames are {firstNames[0]}, {firstNames[1]}, {firstNames[2]}, {firstNames[3]}, {firstNames[4]}");

foreach (string name in firstNames)
{
    Console.WriteLine($"This is part of a foreach loop: {name} ");
}

firstNames[0] = "Matthew";

Console.WriteLine(firstNames[0]);
Console.WriteLine(firstNames[test]);

//single quote identifies a char
//double quotes identifies a string

string data = "1,2,3,4,5";

    string[] stringNames = data.Split(',');

    Console.WriteLine(stringNames[1]); // display second element

Console.WriteLine(stringNames[firstNames.Length - 1]); //grabs last element in array

Console.WriteLine(firstNames.Length); //# of elements in array

// ----------------store data quickly in array

string[] lastNames = new string[] {"lol", "yut", "qwee" };