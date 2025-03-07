
//string firstName = "Tim";
int age = 1;

switch(age)
{
    case >= 0 and < 18:
        Console.WriteLine("child");
        break;
    case >= 18 and < 66:
        Console.WriteLine("You should have a job");
        break;
    case >= 66:
        Console.WriteLine("Hopefully you are retired");
        break;
    default:
        Console.WriteLine("Age not in range");
        break;
}