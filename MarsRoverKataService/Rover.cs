
namespace MarsRoverKataService
{
    public class Rover
    {
        public Direction Orientation { get; set; }
        public Coordinate Location { get; set; }
        public string RoverName { get; set; }
        
        public Rover(int RoverId)
        {
            // default position
            RoverName = "RoverModel" + RoverId;
            Orientation = Direction.N;
            Location = new Coordinate() { X = 0, Y = 0 };
        }
        public string RoverSettings(string initialpositionAndDirection, Plateau plateau)
        {
            string[] Settings = initialpositionAndDirection.Split(" ");
            if (initialpositionAndDirection.Length == 0) 
            { // throwexception
            };
            if (Settings[2] == "N"  )
            {
                Orientation = Direction.N;
            }
            if (Settings[2] == "S"  )
            {
                Orientation = Direction.S;
            }
            if (Settings[2] == "E"  )
            {
                Orientation = Direction.E;
            }
            if (Settings[2] == "W"  )
            {
                Orientation = Direction.W; 
            }
            if (Settings[2] != "N" && Settings[2] != "S" && Settings[2] != "E" && Settings[2] != "W")
                return "Setting of Rover aborted due to inaccurate Orientation setting";
            string x = Settings[0];
            string y = Settings[1];
            if (int.TryParse(x, out int Xcoord) && int.TryParse(y, out int Ycoord))
            {
                if (Xcoord < 0)
                    Settings[0] = "0";
                if (Ycoord < 0)
                    Settings[1] = "0";
                Location = new Coordinate() { X = Xcoord, Y = Ycoord };
                if (!plateau.IsCoordinateWithin(Location))
                {
                    return "Setting of "+ RoverName+" aborted because outside Plateau Area";

                }
                return "Settings Applied Successfully";
            }
            return "Setting of "+ RoverName+" aborted due to inaccurate Co-ords";
        }

        public Coordinate MoveForward()
        {
            if (Orientation == Direction.N)
            {
                Location = Location.AdjustYBy(1);
            }
            if (Orientation == Direction.S)
            {
                Location = Location.AdjustYBy(-1);
            }
            if (Orientation == Direction.E)
            {
               Location = Location.AdjustXBy(1);
            }
            if (Orientation == Direction.W)
            {
                Location = Location.AdjustXBy(-1);
            }
            return Location;
        }
        public Direction TurnLeft()
        {
            if (Orientation == Direction.N)
            {
                Orientation = Direction.W;
            }
            else if (Orientation == Direction.W)
            {
                Orientation = Direction.S;
            }
            else if (Orientation == Direction.S)
            {
                Orientation = Direction.E;
            }
            else if (Orientation == Direction.E)
            {
                Orientation = Direction.N;
            }
            return Orientation;
        }
        public Direction TurnRight()
        {
            if (Orientation == Direction.N)
            {
                Orientation = Direction.E;
            }
            else if (Orientation == Direction.E)
            {
                Orientation = Direction.S;
            }
            else if (Orientation == Direction.S)
            {
                Orientation = Direction.W;
            }
            else if (Orientation == Direction.W)
            {
                Orientation = Direction.N;
            }
            return Orientation;
        }
    }
}
