namespace MarsRoverKataService
{
    public class Collisions
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
