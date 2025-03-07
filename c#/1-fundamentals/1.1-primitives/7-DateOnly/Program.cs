//This is only for .Net 6 and beyond

//Use for when you just want the date
DateTime today = DateTime.Now;

DateOnly birthday = DateOnly.Parse("6/11/1998");

//Console.WriteLine(birthday.ToString("MMMM dd, yyyy"));


Console.WriteLine($"Today DateTime format: {today}");
Console.WriteLine($"Today Date format: {today.Date}");
Console.WriteLine($"Another date in DateOnly format: {birthday}");