
namespace MarsRoverKataService
{
    public class Plateau
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        private readonly List<int> sizePlateau = new ();

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
                    MaxX = 5;
                    MaxY = 5;
                }
                MaxY = maxy;
                MaxX = maxx;

            }
            MaxX = 5;
            MaxY = 5;
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
