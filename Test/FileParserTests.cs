using Mars_Rover_Project.Helper;
using Xunit;

namespace Test
{
    public class FileParserTests
    {
        [Fact]
        public void ReadUpperRightPosition_ShouldPassed_WhenLineRightFormat()
        {
            var fileParser = new FileParser(new []{"5 5"});
            Assert.Equal(new []{5,5}, fileParser.ReadUpperRightPosition());
        }
        [Fact]
        public void ReadLineAsPosition_ShouldPassed_WhenLineRightFormat()
        {
            var fileParser = new FileParser(new []{"5 5","4 4 S"});
            
            Assert.Equal("4 4 S", fileParser.ReadLineAsPosition().GetPosition());
        }
        [Fact]
        public void ReadLineAsCommands_ShouldPassed_WhenLineRightFormat()
        {
            var fileParser = new FileParser(new []{"5 5","4 4 S","LMLMLMLMM"});
            Assert.Equal("LMLMLMLMM", fileParser.ReadLineAsCommands());
        }
    }
}