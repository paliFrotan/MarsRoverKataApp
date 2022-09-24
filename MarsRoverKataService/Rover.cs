using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKataService
{
    public class Rover
    {
        public Direction Orientation { get; set; }
        public Coordinate Location;
        //public Command Execute { get; set; }

        public Rover()
        {
           // Orientation = Direction;
            Location = new Coordinate();
        }
        public void RoverSettings(string initialpositionAndDirection)
        {
            string[] Settings = initialpositionAndDirection.Split(" ");
            if (initialpositionAndDirection.Length == 0) 
            { // throwexception
            };
            if (Settings[2] == "N")
            {
                Orientation = Direction.N;
            }
            if (Settings[2] == "S")
            {
                Orientation = Direction.S;
            }
            if (Settings[2] == "E")
            {
                Orientation = Direction.E;
            }
            if (Settings[2] == "W")
            {
                Orientation = Direction.W; 
            }
            //Location = new Coordinate() { X = int.Parse(Settings[0]), Y = int.Parse(Settings[1]) };
            Location.X = int.Parse(Settings[0]);
            Location.Y = int.Parse(Settings[1]);
        }

        
        

        public Coordinate MoveForward(Rover rover)
        {
           /* if (Orientation == Direction.N)
            {
                Location = Location.AdjustYBy(rover, 1);
            }
            if (Orientation == Direction.S)
            {
                Location = Location.AdjustYBy(rover, -1);
            }*/
            if (rover.Orientation == Direction.E)
            {
               Location.X = rover.Location.X + 1;
               Location.Y = rover.Location.Y;
               Orientation = rover.Orientation;
                //Location = Location.AdjustXBy(rover, 1);
            }
           /* if (Orientation == Direction.W)
            {
                Location = Location.AdjustXBy(rover,-1);
            }*/
            return Location;
        }
        public Direction TurnLeft(Rover rover)
        {
            if (rover.Orientation == Direction.N)
            {
                rover.Orientation = Direction.W;
            }
            else if (rover.Orientation == Direction.W)
            {
                rover.Orientation = Direction.S;
            }
            else if (rover.Orientation == Direction.S)
            {
                rover.Orientation = Direction.E;
            }
            else if (rover.Orientation == Direction.E)
            {
                rover.Orientation = Direction.N;
            }
            return rover.Orientation;
        }
        public Direction TurnRight(Rover rover)
        {
            if (rover.Orientation == Direction.N)
            {
                rover.Orientation = Direction.E;
            }
            else if (rover.Orientation == Direction.E)
            {
                rover.Orientation = Direction.S;
            }
            else if (rover.Orientation == Direction.S)
            {
                rover.Orientation = Direction.W;
            }
            else if (rover.Orientation == Direction.W)
            {
                rover.Orientation = Direction.N;
            }
            return rover.Orientation;
        }
    }
}
