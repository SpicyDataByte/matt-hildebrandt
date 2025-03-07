using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwInstantiatedClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Address> addresses = new List<Address>();

            Address address= new Address();
            address.StreetNumber = 334; 
            address.StreetName = "Redberry Rd.";
            address.PostalCode = "S7K 4W7";
            address.City = "Saskatoon";
            address.Country = "Canada";

            addresses.Add(address);
            
            Console.WriteLine(addresses);
            
            foreach (Address a in addresses)
            {
                Console.WriteLine(a.StreetNumber);
                Console.WriteLine(a.StreetName);
                Console.WriteLine(a.PostalCode);
                Console.WriteLine(a.City);
                Console.WriteLine(a.Country);
            }
            
            Console.ReadLine();

        }
    }
}
