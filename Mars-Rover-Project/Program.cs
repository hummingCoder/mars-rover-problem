using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mars_Rover_Project.Enums;
using Mars_Rover_Project.Helper;
using Mars_Rover_Project.Models;

namespace Mars_Rover_Project
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var fileName = Path.Combine(Directory.GetCurrentDirectory(), "../../../data.txt");
            
                var lines = await ReadLinesAsync(fileName);
                
                var fileParser = new FileParser(lines);

                var upperRightPoints = fileParser.ReadUpperRightPosition();

                var plateau = new Plateau(upperRightPoints);

                var position1 = fileParser.ReadLineAsPosition();

                var moves1 = fileParser.ReadLineAsCommands();
            
                var position2 = fileParser.ReadLineAsPosition();
                
                var moves2 = fileParser.ReadLineAsCommands();

                position1.Start(plateau, moves1);
                position1.PrintPosition();
                position2.Start(plateau, moves2);
                position2.PrintPosition();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static async Task<string[]> ReadLinesAsync(string filePath)
        {
            var lines = await File.ReadAllLinesAsync(filePath);
            return lines;
        }
    }
}