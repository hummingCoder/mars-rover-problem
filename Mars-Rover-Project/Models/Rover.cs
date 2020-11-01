using System;
using Mars_Rover_Project.Enums;
using Mars_Rover_Project.Interfaces;

namespace Mars_Rover_Project.Models
{
    public class Rover : IRover
    {
        public Rover(int x, int y, Directions direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        private int X { get; set; }
        private int Y { get; set; }
        private Directions Direction { get; set; }


        private void Rotate90DegreesLeft()
        {
            Direction = Direction switch
            {
                Directions.N => Directions.W,
                Directions.S => Directions.E,
                Directions.E => Directions.N,
                Directions.W => Directions.S,
                _ => Direction
            };
        }

        private void Rotate90DegreesRight()
        {
            Direction = Direction switch
            {
                Directions.N => Directions.E,
                Directions.S => Directions.W,
                Directions.E => Directions.S,
                Directions.W => Directions.N,
                _ => Direction
            };
        }

        private void MoveInSameDirection()
        {
            switch (Direction)
            {
                case Directions.N:
                    Y += 1;
                    break;
                case Directions.S:
                    Y -= 1;
                    break;
                case Directions.E:
                    X += 1;
                    break;
                case Directions.W:
                    X -= 1;
                    break;
                default:
                    Console.Write("Geçerli bir yön değil.");
                    break;
            }
        }

        public void Start(Plateau plateau, string moves)
        {
            if (X < 0 || X > plateau.UpperRightCoordinates[0] || Y < 0 || Y > plateau.UpperRightCoordinates[1])
            {
                throw new IndexOutOfRangeException(
                    $"{plateau.UpperRightCoordinates[0]} , {plateau.UpperRightCoordinates[1]} dışında bir nokta seçtiniz.");
            }

            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        MoveInSameDirection();
                        break;
                    case 'L':
                        Rotate90DegreesLeft();
                        break;
                    case 'R':
                        Rotate90DegreesRight();
                        break;
                    default:
                        throw new ArgumentException($"{move} geçerli bir hareket değil.");
                        break;
                }
            }
        }

        public void PrintPosition()
        {
            Console.WriteLine($"\n{X} {Y} {Direction.ToString()}");
        }

        public string GetPosition()
        {
            return $"{X} {Y} {Direction.ToString()}";
        }
    }
}