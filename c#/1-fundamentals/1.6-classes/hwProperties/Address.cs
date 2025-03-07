using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwProperties
{
    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress
        {
            get
            {
                return $"{StreetAddress},\n{City},\n{Province},\n{PostalCode}";
            }
        }
    }
}
