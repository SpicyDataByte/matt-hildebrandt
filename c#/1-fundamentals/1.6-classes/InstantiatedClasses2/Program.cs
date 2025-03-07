using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantiatedClasses2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Building a house from the blueprint
            PersonModel person = new PersonModel();

            List<PersonModel> people = new List<PersonModel>();

            // Variable holds the street address
            person = new PersonModel();
            person.firstName = "Matt";
            people.Add(person);

            person = new PersonModel();
            person.firstName = "Celine";
            people.Add(person);

            foreach (PersonModel p in people)
            {
                Console.WriteLine(p.firstName);
            }

            Console.ReadLine();

        }
    }
}
