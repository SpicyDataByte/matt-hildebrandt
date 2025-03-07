//returns computer's local
//USA standard is MM/DD
//Other places will be d/MM
using System.Globalization;

DateTime today = DateTime.UtcNow;//Keep in mind code may run on a server in a different timezone

Console.WriteLine(today);
Console.WriteLine(today.ToString("D")); //short date

////DateTime birthday = DateTime.Parse("25/4/2020");// Wont work, specify locale
//DateTime birthday = DateTime.Parse("4/25/2020");// Will work
//Console.WriteLine(birthday);

////Standardize the DateTime format
//DateTime standardDateTime = DateTime.ParseExact("6/11/1998", "d/M/yyyy", CultureInfo.InvariantCulture);
//Console.WriteLine(standardDateTime);