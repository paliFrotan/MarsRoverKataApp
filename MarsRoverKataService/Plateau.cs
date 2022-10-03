
namespace MarsRoverKataService
{
    public class Plateau
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public Plateau() { }
        public void PlateauSettings(string PlateauSizeInput) 
        {
            string[] PlateauSizeList = PlateauSizeInput.Split(" ");
            string x = PlateauSizeList[0];
            string y = PlateauSizeList[1];
            if (int.TryParse(x, out int maxx) && int.TryParse(y, out int maxy))
            {
                
                if (maxx <= 1 || maxy <= 1)
                {
                    MaxX = 6;
                    MaxY = 6;
                }
                MaxY = maxy;
                MaxX = maxx;

            }
            MaxX = 6;
            MaxY = 6;
        }

        public bool IsCoordinateWithin(Coordinate _location)
        {
            var x = int.Parse(_location.X.ToString());
            var y = int.Parse(_location.Y.ToString());
            return (x < MaxX && x > -1 && y < MaxY && y > -1);
            
        }
        public int MaxRoversAllowed()
        {
            return (int.Parse((MaxX * MaxY / 2 ).ToString()));
        }

    }
}
