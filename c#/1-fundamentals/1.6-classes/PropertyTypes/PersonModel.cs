using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTypes
{
    public class PersonModel
    {
        public string FirstName { private get; set; }
        public string LastName { get; private set; }
        //use birthday in real world to allow calculation for when you get older
        //------------------------------------------------------------------
        public PersonModel(string lastName)
        {
            LastName = lastName;
        }

        //Overloading
        public PersonModel() 
        { 

        }
        //-------------------------------------------------------------
        //Auto Prop
            //public int Age { get; set; }

        //Full Prop
        private int _age; //private backing field. Should not manipulate directly. 
        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 0 && value < 126) // allows you to make sure data you put in is good data
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", "Age needs to be in a valid range.");
                }
            }
        }

        //----------------------------------------------------------
        public string FullName
        {
            get 
            { 
                return $"{FirstName} {LastName}";
            }
        }
        //------------------------------------------------------
        private string _password;
        public string Password
        {
            set { _password = value; }
        }
            
        
            //eg SSN = 123-45-6789 = 11 characters
            private string _ssn;
            public string SSN
            {
                get 
                {
                    string output = "***-**-" + _ssn.Substring(_ssn.Length - 4);
                    return output; 
                }
                set { _ssn = value; }

            }
      

    }
}
