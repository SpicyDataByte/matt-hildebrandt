string firstName = string.Empty;
string lastName = string.Empty;
string filePath = string.Empty;

firstName = "Tim";
lastName = "Corey";
//filePath = "C:\\Temp\\Demo";
filePath = @"C:\Temp\Demo";
//firstName = "123";

//Console.WriteLine(firstName + " " + lastName);

string testString = $@"The file for {firstName} is at C:\SampleFiles";

// String interpolation
Console.WriteLine($"Hello {firstName} {lastName}");
Console.WriteLine(filePath);
Console.WriteLine(testString);