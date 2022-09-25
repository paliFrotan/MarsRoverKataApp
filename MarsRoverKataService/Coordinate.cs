using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKataService
{
    public struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        

        public Coordinate AdjustXBy(int adjustment)
        {
            return new Coordinate { X = X + adjustment, Y = Y };
        }
        
        public Coordinate AdjustYBy(int adjustment)
        {
            return new Coordinate { X = X, Y = Y + adjustment };
        }
    } 
    
}
