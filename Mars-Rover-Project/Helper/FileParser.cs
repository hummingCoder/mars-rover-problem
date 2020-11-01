using System;
using System.Linq;
using System.Numerics;
using Mars_Rover_Project.Enums;
using Mars_Rover_Project.Models;

namespace Mars_Rover_Project.Helper
{
    public class FileParser
    {
        private string[] _lines;
        private int _lineCursor;
        public FileParser(string[] lines)
        {
            _lines =lines;
            _lineCursor = 1;
        }

        public int[] ReadUpperRightPosition()
        {
            var upperRightPosition = _lines.ElementAt(0)?.Trim().Split(' ').Select(int.Parse).ToArray();
            return upperRightPosition;
        }

        public Rover ReadLineAsPosition()
        {
            var startPositions = _lines[_lineCursor].Trim().Split(' ');
            if (startPositions == null)
            {
                throw new ArgumentException();
            }

            var position = new Rover(int.Parse(startPositions[0]), int.Parse(startPositions[1]),
                (Directions) Enum.Parse(typeof(Directions), startPositions[2]));
            
            _lineCursor+=1;
            return position;
        }

        public string ReadLineAsCommands()
        {
            var commands = _lines.ElementAt(2).ToUpper();
            _lineCursor+=1;
            return commands;
        }
    }
}