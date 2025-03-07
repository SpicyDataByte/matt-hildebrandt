using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Address address= new Address();

            address.StreetAddress = "334 Redberry Rd.";
            address.City = "Saskatoon";
            address.Province = "Saskatchewan";
            address.PostalCode = "S7K 4W7";

            Console.WriteLine(address.FullAddress);

            Console.ReadLine();

        }
    }
}
