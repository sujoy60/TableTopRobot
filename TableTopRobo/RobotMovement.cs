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
            this.RobotObj = robo;
        }

        public Robot RobotObj { get; set; }

        public string CommandReceived(string command)
        {
            string response = "";
            InstructionsReceived args = null;
            var instruction = GetInstruction(command, ref args);

            switch (instruction)
            {
                case Instructions.Place:
                    //FinalizePositionInstructions f1 = new FinalizePositionInstructions();
                    var placeArgs = (FinalizePositionInstructions)args;
                    if (RobotObj.Place(placeArgs.X, placeArgs.Y, placeArgs.Facing))
                    //Robot r1 = new Robot();
                    //var boolReturned = r1.Place(placeArgs.X, placeArgs.Y, placeArgs.Facing);
                    //r1.Place(0,0,Facing.East); //
                    //if ((boolReturned))
                    {
                        response = "Done.";
                    }
                    else
                    {
                        response = RobotObj.LastError;
                    }
                    break;
                case Instructions.Move:
                    if (RobotObj.Move())
                    {
                        response = "Done.";
                    }
                    else
                    {
                        response = RobotObj.LastError;
                    }
                    break;
                case Instructions.Left:
                    if (RobotObj.Left())
                    {
                        response = "Done.";
                    }
                    else
                    {
                        response = RobotObj.LastError;
                    }
                    break;
                case Instructions.Right:
                    if (RobotObj.Right())
                    {
                        response = "Done.";
                    }
                    else
                    {
                        response = RobotObj.LastError;
                    }
                    break;
                case Instructions.Report:
                    response = RobotObj.Report();
                    break;
                default:
                    response = "Invalid command.";
                    break;
            }
            return response;

        }

        private Instructions GetInstruction(string command, ref InstructionsReceived args)
        {
            Instructions result;
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

        private bool TryParsePlaceArgs(string argString, ref InstructionsReceived args)
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


   
    }
}
