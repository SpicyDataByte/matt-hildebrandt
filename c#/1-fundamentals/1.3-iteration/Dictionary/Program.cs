Dictionary<string, string> lookup = new Dictionary<string, string>();

lookup["animal"] = "Not a human";
lookup["fish"] = "Not a human that swims";
lookup["human"] = "Us";

Console.WriteLine($"The definition of fish is: {lookup["fish"]}");

Dictionary<int, string> employees = new Dictionary<int, string>();
employees[19] = "Matt H";
employees[25] = "Kai";

Console.WriteLine($"The employee with ID number 25 is {employees[25]}");

Dictionary<string, int> dayOfWeek = new Dictionary<string, int>();

dayOfWeek["Wednesday"] = 4;
dayOfWeek["Thursday"] = 5;
dayOfWeek["Friday"] = 6;

Console.WriteLine($"Wednesday is the {dayOfWeek["Wednesday"]} day of week");




