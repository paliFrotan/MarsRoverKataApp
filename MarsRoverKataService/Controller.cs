using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarsRoverKataService
{
    public class Controller
    {
        
        public Controller() 
        { 
        }

        public List<int> ControlSizePlateau(string PlateauSizeInput)
        {
            string[] PlateauSizeList = PlateauSizeInput.Split(" ");
            List<int> resultList = new List<int>();
            for (int i = 0; i < PlateauSizeList.Length; i++)
                resultList.Add(Convert.ToInt32(PlateauSizeList[i])+1);
            return resultList; 
                
        }
    }
}
