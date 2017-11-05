using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopRobo
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayStartMessage();

            var driver = new RobotMovement(new Robot());

            while (true)
            {
                string command = PromptForCommand();
                if (command.ToUpper() == "EXIT" || command.ToUpper() == "QUIT")
                {
                    Environment.Exit(0);
                }
                Console.WriteLine(driver.CommandReceived(command));
            }

        }

        private static void DisplayStartMessage()
        {
            Console.WriteLine("Sujoys tabletop Application");
            Console.WriteLine("---------");
            Console.WriteLine("");
        }

        private static string PromptForCommand()
        {
            Console.WriteLine("Please enter coomand here : ");
            return Console.ReadLine();
        }

    }
}
