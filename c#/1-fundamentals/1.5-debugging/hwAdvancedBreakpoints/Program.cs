using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwAdvancedBreakpoints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 0;

            for (int i = 1; i < 100; i++)
            {
                total += i; 
                try
                {
                    if (i == 73)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("An Error"); 
                    
                }
             
                Console.WriteLine(i);
              
            }
        Console.ReadLine();
        }

    }
}
