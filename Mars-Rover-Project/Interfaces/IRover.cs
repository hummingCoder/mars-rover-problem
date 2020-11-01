using Mars_Rover_Project.Models;

namespace Mars_Rover_Project.Interfaces
{
    public interface IRover
    {
        void Start(Plateau plateau, string moves);
    }
}