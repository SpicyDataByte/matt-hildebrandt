using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            try
            {
                //First_NotImplementedMethod();
                Second_DifferentMethod();
                Console.Write("What is your name: ");
                name = Console.ReadLine();
                Third_ComplexMethod(name);
                Fourth_SimpleMethod();
            }

            catch (NotImplementedException) // catch the name of the Exception should be same as what's in First_
            {
                Console.WriteLine("You forgot to finish your code!!!");
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine("Output for Argument Exception");
                Console.WriteLine(ex.Message);  // Output of the thrown exception. 
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine("You should not be calling this method.");
                Console.WriteLine(ex.Message);
            }

            catch (Exception ex) when (name.ToLower() == "matt") // The default catch for exceptions thrown.  
            {
                Console.WriteLine("You used Matt's name");
                //Console.WriteLine(ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            finally
            {
                Console.WriteLine("I always run");
            }

            Console.ReadLine(); 
        
        }

        private static void First_NotImplementedMethod()
        {
            //throw new NotImplementedException();
            throw new NotImplementedException();
        }

        private static void Second_DifferentMethod()
        {
            Console.WriteLine("This is the different method working properly.");

        }
        private static void Third_ComplexMethod(string name)
        {
            if (name.ToLower() == "matt")
            {
                 throw new InsufficientMemoryException("Matt doesnt use this method. Too Big."); //Can be any Exception
            }
            else
            {
                throw new ArgumentException("This person isn't Matt");
            }
        }

        private static void Fourth_SimpleMethod()
        {
            throw new InvalidOperationException("You should not be calling the SimpleMethod");      
        }


    }
}
