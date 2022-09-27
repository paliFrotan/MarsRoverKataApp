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
