using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace hwStaticClasses
{
    public static class Math
    {
        public static double Add(double x, double y)
        {
            double output = x + y;
            return output;
        }

        public static double Sub(double x, double y)
        {
            double output = x - y;
            return output;
        }
        
        public static double Multiply(double x, double y)
        {
            double output = x * y;
            return output;
        }
        public static double Divide(double x, double y)
        
        {
            double output = (x / y); 
            return output;
        }
    }
}
