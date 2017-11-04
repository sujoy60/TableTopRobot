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

            var driver = new RobotMovements(new Robot());

            //while (true)
            //{
                string command = PromptForCommand();
                if (command.ToUpper() == "EXIT" || command.ToUpper() == "QUIT")
                {
                    Environment.Exit(0);
                }
                Console.WriteLine(driver.Command(command));
            //}
            //string  instructionEntered = Console.ReadLine().ToString().ToUpper();
            //switch (instructionEntered)
            //    {
            //        case "PLACE":
            //        string evaluateInstruction
            //        break;

            //        case "MOVE":
            //        break;
        
            //        case "RIGHT":
            //        break;
               
            //        case "REPORT":
            //        Console.WriteLine("Case 1");
            //        break;

            //        default:
            //        Console.WriteLine ("Invalid command.");
            //        break;
            //    };
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
