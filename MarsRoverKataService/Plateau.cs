
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
            for (int i = 0; i < PlateauSizeList.Length; i++)
                sizePlateau.Add(Convert.ToInt32(PlateauSizeList[i]) + 1);
            MaxX = sizePlateau[0];
            MaxY = sizePlateau[1];
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
