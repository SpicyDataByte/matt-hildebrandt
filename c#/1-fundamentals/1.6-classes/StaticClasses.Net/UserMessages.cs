using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClasses.Net
{
    public class UserMessages
    {
        public static void ApplicationsStartMessage(string firstName)
        {
            Console.Clear();    
            Console.WriteLine("Welcome to the Static Class Demo App");

            int hourofDay = DateTime.Now.Hour;  

            if (hourofDay < 12) 
            {
                Console.WriteLine($"Good Morning {firstName}!");
            }
            else if (hourofDay < 19)
            {
                Console.WriteLine($"Good Afternoon {firstName}!");
            }
            else
            {
                Console.WriteLine($"Good evening {firstName}!");
            }
        }

        public static void PrintResultMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine("Thank you for using our app to calculate for you.");
        }

        

        

    }
}
