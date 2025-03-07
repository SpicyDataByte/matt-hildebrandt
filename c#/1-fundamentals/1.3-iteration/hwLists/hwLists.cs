//Add students to a list until no more left
//declare student outside of do loop first
List<string> studentNames = new List<string>();
string student;
do
{
    Console.Write("Add a student name to the list: ");

     student = Console.ReadLine();
    if (student.ToLower() == "done")
    {
        break;
    }
    else
    {
        studentNames.Add(student);  
    }
} while (student.ToLower() != "done");

//Then print out count of students

Console.WriteLine("\nHere are the names of students in your class:");
int studentNumber = 0;
do
{
    Console.WriteLine(studentNames[studentNumber]);
    studentNumber += 1;
} while (studentNumber < studentNames.Count());