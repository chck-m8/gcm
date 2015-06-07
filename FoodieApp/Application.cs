using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodie.Main.Interface;

namespace Foodie.Main
{
    public class Application : IApplication
    {
        public void Run()
        {
            string input = "";
            try
            {
                Console.Write("Input: ");
                input = Console.ReadLine();
                while (input.ToLower() != "exit")
                {
                    var output = new MealTaker(input).Output();
                    Console.WriteLine("Output: {0}", output);
                    Console.WriteLine();
                    Console.WriteLine(@"Please enter another meal or enter 'exit' to quit.");
                    Console.WriteLine();
                    Console.Write("Input: ");
                    input = Console.ReadLine();

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("---------An Error has occurred---------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }        
        }
    }
}
