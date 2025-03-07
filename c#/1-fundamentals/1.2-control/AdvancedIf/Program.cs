
Console.Write("What is your first name: ");
string? firstName = Console.ReadLine();

// ? used to decalre a nullable type, (Can be null)
Console.Write("What is your last name: ");
string? lastName = Console.ReadLine();

if (firstName.ToLower() == "matt" &&
    lastName.ToLower() == "hildebrandt")
{
    Console.WriteLine("Hi Dad");
}
else
{ 
    Console.WriteLine("Hi Person"); 
}

//else if runs if first condition false