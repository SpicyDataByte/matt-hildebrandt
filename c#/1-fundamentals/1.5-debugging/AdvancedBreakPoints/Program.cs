using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedBreakPoints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunsALot();
            Console.ReadLine(); 
        }

        private static void RunsALot()
        {
            long total = 0;
            int test = 0;

            for (int i = -1000; i <= 1000; i++)
            {
                total += i; //Put Breakpoint Conditions or Actions: HitCount or Expression here and to find the issue faster.
                try
                {
                    test = 5 / i;
                }
                catch 
                {

                    Console.WriteLine("An exception "); ;
                }
            }

            Console.WriteLine($"The total is {total}");
        }
    }
}
