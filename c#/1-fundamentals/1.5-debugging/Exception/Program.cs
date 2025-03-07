using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BadCall();
                
            }
            catch (System.Exception ex) //This second catch allows us to write message to user
            {
                Console.WriteLine("There was an exception thrown and caught here.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }

        private static void BadCall()
        {
            int[] ages = new int[] { 1};

            for (int i = 0; i <= ages.Length; i++)
            {
                try
                {
                    Console.WriteLine(ages[i]);
                }
                catch (System.Exception ex) //This first catch allows to write to log file
                { 
                    Console.WriteLine("We had an error.");
                    Console.WriteLine(ex.Message);
                    throw new System.Exception("This is the thrown error.");
                }
            }
        }
    }
}
