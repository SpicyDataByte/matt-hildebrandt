using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantiatedClass
{
    internal class PersonModel
    {
    //These don't work well with binding and reflection:
        //public string firstName;
        //public string lastName;
        //public string emailAddress; 
    //Auto properties: get - returns value, set - sets value; Naming Convention is PascalCase for external variables
                                                             //camelCase for internal variables
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool HasBeenGreeted { get; set; }
    }
}
