
bool isValidAge;
//test 2 things inside a while loop?
int age;// can now access variable outside of do loop

do
{
    Console.Write("What is your age: ");
    string ageText = Console.ReadLine();

    isValidAge = int.TryParse(ageText, out age);

    if (isValidAge == false)
    {
        Console.WriteLine("That is an invalid age.\n");
    }
} while (isValidAge == false);


// increment to 10 and then stop

int testNumber = 1;

do
{
    Console.WriteLine(testNumber);
    testNumber += 1;
}while(testNumber <= 10);


do
{
    //run the code at least once
} while (true);

while (true) // check the condition first
{
    //run the code 0 or more times
}