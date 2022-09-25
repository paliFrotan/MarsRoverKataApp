using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKataService
{
    public struct Collisions
    {
        public string CollisionsCheck(Coordinate possibleMove, List<Coordinate> CollisionPoints, List<string> RoverNames, Rover rover)
        {
            foreach (Coordinate CollisionPossible in CollisionPoints)
            {
                if (CollisionPossible.X == possibleMove.X && CollisionPossible.Y == possibleMove.Y)
                {
                    return "Move aborted for " + rover.RoverName;
                }
            }
            return "Successfully moved";
        }
    }
}
