using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKataService
{
    public class Collisions
    {
        

        public string CollisionsCheck(Coordinate possibleMove, List<Coordinate> CollisionPoints, List<string> RoverNames)
        {
            //string[] Settings = possibleMove.Split(" ");
            int NewLocationX = possibleMove.X;
            int NewLocationY = possibleMove.Y;
            int count = 0;
            
            foreach (Coordinate CollisionPossible in CollisionPoints)
            {
                if (CollisionPossible.X == NewLocationX && CollisionPossible.Y == NewLocationY)
                {
                    return ("Move aborted for " + RoverNames[count]);
                }
                count++;
            }
            return ("Successfully moved");
        }
    }
}
