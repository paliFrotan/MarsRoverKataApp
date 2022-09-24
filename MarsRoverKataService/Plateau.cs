using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MarsRoverKataService
{
    public class Plateau
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        private List<int> sizePlateau = new List<int>();

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
