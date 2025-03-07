// array with 3 names
string[] firstName = new string[] {"Matt", "Kai", "Celine"};
//ask to select a number
bool isValidNumber;
int number;

do
{
    Console.Write("Select a whole number?: ");
    string numberText = Console.ReadLine();
    isValidNumber = int.TryParse(numberText, out number);

    if (isValidNumber == false)
    {
        Console.WriteLine("That is a invalid number.\n");
    }
    else if (number < 0 || number > 2)
    {
        Console.WriteLine("That number is out of range, select a whole number between 0 and 2.\n ");
    }
} while (isValidNumber == false || number < 0 || number > 2);


// return the number related to array element

Console.WriteLine($"{firstName[number]} is the {number + 1} element in the array");