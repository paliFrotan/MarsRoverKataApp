using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKataService
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
      
       /* public Coordinate AdjustXBy(Rover rover, int adjustment)
        {
            int oldX = rover.Location.X;

            return new Coordinate { X = oldX + adjustment, Y = Y };
            
        }
        public Coordinate AdjustYBy(Rover rover, int adjustment)
        {
            int oldY = rover.Location.Y;
            return new Coordinate { X = X, Y = oldY + adjustment };
        }*/
    } 
    
}

