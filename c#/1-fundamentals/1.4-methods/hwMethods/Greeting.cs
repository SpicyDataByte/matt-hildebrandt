using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwMethods
{
    internal class Greeting
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome!");
        }

        public static string AskName()
        {
            Console.Write("What is your name?: ");
            string name = Console.ReadLine();
            return name;
        }

        public static void HelloName(string firstName)
        {
            Console.WriteLine($"Hello {firstName}");
        }
    }
}
