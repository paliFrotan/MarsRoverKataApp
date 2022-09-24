using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarsRoverKataService
{
    public class Controller
    {
        
        public Controller() 
        { 
        }
        public List<Command> CommandList = new List<Command>();
        public void SetCommands(string Commands)
        {
            char[] commands = Commands.ToCharArray();
            foreach (char character in commands)
            {
                if (character == 'L')
                    CommandList.Add(Command.L);
                if (character == 'R')
                    CommandList.Add(Command.R);
                if (character == 'M')
                    CommandList.Add(Command.M);
            }


        }
        public string Execute(Plateau plateau, Rover rover)
        {

            var _rover = new Rover();
            
            var _finalOrientation = new Direction();
            var _finalLocation = new Coordinate();
            string result = string.Empty;
            for (int i = 0; i < CommandList.Count; i++)
            {
                if (CommandList[i] == Command.M)
                {
                    _finalLocation = _rover.MoveForward(rover);
                    _finalOrientation = _rover.Orientation;

                }
                if (CommandList[i] == Command.L)
                {
                    _finalOrientation = _rover.TurnLeft(rover);
                }
                if (CommandList[i] == Command.R)
                {
                    _finalOrientation = _rover.TurnRight(rover);
                }

            }
            result += _finalLocation.X.ToString();
            result += " ";
            result += _finalLocation.Y.ToString();
            result += " ";
            result += _finalOrientation.ToString();
            return result;
        }

    }
}
