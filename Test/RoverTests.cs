using System;
using Mars_Rover_Project.Enums;
using Mars_Rover_Project.Models;
using Xunit;

namespace Test
{
    public class RoverTests
    {
        [Fact]
        public void Start_ShouldPassed_WhenInsidePlateauBounds()
        {
            var position = new Rover(1, 2, Directions.N);
            var plateau = new Plateau(new []{5,5});
            position.Start(plateau, "LMLMLMLMM");

            const string expected = "1 3 N";
            Assert.Equal(expected, position.GetPosition());
        }
        [Fact]
        public void Start_ShouldOutOfRangeException_WhenPlateauBoundsPassed()
        {
            var position = new Rover(1, 6, Directions.N);
            var plateau = new Plateau(new []{5,5});
            
            var result = Record.Exception(()=>position.Start(plateau, "LMLMLMLMM"));
            var exception = Assert.IsType<IndexOutOfRangeException>(result);
        }
        [Fact]
        public void Start_ShouldArgumentException_WhenInvalidArgument()
        {
            var position = new Rover(1, 2, Directions.N);
            var plateau = new Plateau(new []{5,5});
            
            var result = Record.Exception(()=>position.Start(plateau, "LMLMLMLMS"));
            var exception = Assert.IsType<ArgumentException>(result);
        }
        
    }
}