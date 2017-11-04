using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopRobo
{
    class RobotMovement
    {
        public RobotMovement(Robot robo)
        {
            this.Robot = robo;
        }

        public Robot Robot { get; set; }

        private Instructions GetInstruction(string command, ref InstructionsReceived args)
        {
            InstructionsReceived result;
            string argString = "";

            int parseArgsSeperator = command.IndexOf(" ");
            if (parseArgsSeperator > 0)
            {
                argString = command.Substring(parseArgsSeperator + 1);
                command = command.Substring(0, parseArgsSeperator);
            }
            command = command.ToUpper();

            if (Enum.TryParse<Instructions>(command, true, out result))
            {
                if (result == Instructions.Place)
                {
                    if (!TryParsePlaceArgs(argString, ref args))
                    {
                        result = Instructions.Invalid;
                    }
                }
            }
            else
            {
                result = Instructions.Invalid;
            }
            return result;
        }

        private bool TryParsePlaceArgs(string argString, ref Instructions args)
        {
            var argParts = argString.Split(',');
            int x, y;
            Facing facing;

            if (argParts.Length == 3 &&
                TryGetCoordinate(argParts[0], out x) &&
                TryGetCoordinate(argParts[1], out y) &&
                TryGetFacingDirection(argParts[2], out facing))
                {
                args = new FinalizePositionInstructions
                        { X=x,Y=y,Facing = facing };
                //X = x,
                //Y = y,
                //Facing = facing

                return true;
                }
                return false;
        }

        private bool TryGetCoordinate(string coordinate, out int coordinateValue)
        {
            return int.TryParse(coordinate, out coordinateValue);
        }

        private bool TryGetFacingDirection(string direction, out Facing facing)
        {
            return Enum.TryParse<Facing>(direction, true, out facing);
        }


        public string CommandReceived(string command)
        {
            //string instructionEntered = Console.ReadLine().ToString().ToUpper();
            string response = "";
            Instructions args = null;
            var instructionEntered = GetInstruction(command, ref args);


            switch (instructionEntered)
            {
                case Instructions.Place:

                    var placeArgs = (FinalizePositionInstructions)args;
                    if (Robot.Place(placeArgs.X, placeArgs.Y, placeArgs.Facing))
                    {
                        response = "Done.";
                    }
                    break;

                case "MOVE":
                    break;

                case "RIGHT":
                    break;

                case "REPORT":
                    Console.WriteLine("Case 1");
                    break;

                default:
                    Console.WriteLine("Invalid command.");
                    break;
            };

        }
    }
}
