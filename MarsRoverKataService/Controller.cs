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
         
        public List<Command> CommandList = new ();
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
        public string Execute(Rover _rover1)
        {
            var _finalOrientation = new Direction();
            var _finalLocation = new Coordinate();
            string result = string.Empty;
            for (int i = 0; i < CommandList.Count; i++)
            {
                if (CommandList[i] == Command.M)
                {
                    _finalLocation = _rover1.MoveForward();
                    _finalOrientation = _rover1.Orientation;

                }
                if (CommandList[i] == Command.L)
                {
                    _finalOrientation = _rover1.TurnLeft();
                    _finalLocation = _rover1.Location;
                }
                if (CommandList[i] == Command.R)
                {
                    _finalOrientation = _rover1.TurnRight();
                    _finalLocation = _rover1.Location;
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
