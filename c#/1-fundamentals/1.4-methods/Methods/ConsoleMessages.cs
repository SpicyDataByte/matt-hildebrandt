using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//could use namespace without first set of {}. Saves horizontal space.
namespace createMethod
{
    public class ConsoleMessages //public = anyone can use; internal = anyone in project; private = anyone in this scope;
    {
        public static void SayMyBoy() //void = returns nothing
        {
   
            Console.WriteLine("My Boy.");
        }

        public static void SayHiName(string firstName) //void = returns nothing
        {
            Console.WriteLine($"Hello {firstName}!");
            Console.WriteLine("Hope you are have a good day");
        }


        public static string GetUserName()
        {
            Console.Write("What is your name: ");
            string name = Console.ReadLine();
            Console.WriteLine();

            return name;
        }

        //public static (string fname, string lname) GetFullName()
        //{
        //    Console.WriteLine("What your first name? ");
        //    string firstName = Console.ReadLine();

        //    Console.WriteLine("What is your last name? ");
        //    string lastName = Console.ReadLine();

        //    return (firstName, lastName);
        //}

        public static void SayGoodbye()
        {
            Console.WriteLine("Goodbye, my user.");
            Console.WriteLine("Thank you for visiting");
            Console.WriteLine("I cannot wait to see you again");
        }
    }


}
