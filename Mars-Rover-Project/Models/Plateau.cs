using System.Numerics;

namespace Mars_Rover_Project.Models
{
    public class Plateau
    {
        public Plateau(int[] upperRightCoordinates)
        {
            UpperRightCoordinates = upperRightCoordinates;
        }

        public int[] UpperRightCoordinates { get; set; }
    }
}