﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKataService
{
    public class Rover
    {
        public Rover()
        {
        }
        private char _position = 'N';
        
        public char RoverFacingDirection(char roverCommand)
        {
            if(roverCommand == 'L') 
            {
                _position = 'W';
            };
            if (roverCommand == 'R')
            {
                _position = 'E';
            };
            return _position;
        }

    }
}
