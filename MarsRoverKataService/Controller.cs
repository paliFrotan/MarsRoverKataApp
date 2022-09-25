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
            CommandList.Clear ();
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

        public List<Coordinate> CollisionPoints = new();
        public List<string> RoverNames = new();

        public string Execute(Rover _rover1)
        {
            var _finalOrientation = new Direction();
            var _finalLocation = new Coordinate();
            var _collisions = new Collisions();
            string message = "Successfully moved";
            string messageCollision = "Successfully moved";
            string result = string.Empty;
            for (int i = 0; i < CommandList.Count; i++)
            {
                if (CommandList[i] == Command.M)
                {
                    var _possibleMove = _rover1.MoveForward();
                       
                    messageCollision =_collisions.CollisionsCheck(_possibleMove,CollisionPoints,RoverNames,_rover1);
                    if (message != messageCollision)
                    {
                        break;
                    }
                    _finalLocation = _possibleMove;
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
            CollisionPoints.Add(_finalLocation);
            RoverNames.Add(_rover1.RoverName);
            if (message == messageCollision)
            {
                result += _finalLocation.X.ToString();
                result += " ";
                result += _finalLocation.Y.ToString();
                result += " ";
                result += _finalOrientation.ToString();
                return result;
            }
            else 
            {
                return messageCollision;
            }
        }
    }
}
