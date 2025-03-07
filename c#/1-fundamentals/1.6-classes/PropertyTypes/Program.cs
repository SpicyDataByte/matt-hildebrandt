using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new PersonModel("Hildebrandt");

            person.FirstName = "Matt";
            //person.LastName = "Hildebrandt";
            person.Age= 29;
            person.SSN = "123-45-6789";

            Console.WriteLine(person.FullName);
            Console.WriteLine(person.SSN);
            
            Console.ReadLine();
        }
    }
}
