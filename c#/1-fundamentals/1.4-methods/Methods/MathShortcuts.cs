using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createMethod
{
    public static class MathShortcuts
    {
        public static void Add(double x, double y)
        {
            Console.WriteLine($"The value of {x} + {y} = {x + y}");
            //double output = x + y; these lines could be used too
            //return output;
            //change void to double!!

        }

        public static void AddAll(double[] values)
        {
            //double can be used for all math including DIVIDE
            double result = 0;

            //values.Sum(); would do the same as following loop: 
            foreach (double value in values)
            {
                result += value;
            }

            Console.WriteLine($"\nThe total is {result}");
        }
    }
}
