using Bowling.Models;
using Bowling.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Tests
{
    public class ShotServiceTest
    {
        // Test Creat() method       
 
        [Fact]
        public void Create_Shots_List_With_Null_Array_Shots()
        {
            // Arrange
            var shotService = new ShotService();

            // act & Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() => shotService.CreateList(null));
        }

        [Fact]
        public void Create_Shots_List_With_Empty_Array_Shot()
        {
            // Arrange
            var shotService = new ShotService();

            // act & Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() => shotService.CreateList(Array.Empty<string>()));
        }
        [Theory]
        [InlineData("a")]
        [InlineData("-1")]
        public void Creating_Shot_With_Bad_value_1(string shot)
        {
            // Arrange
            var shotService = new ShotService();

            // act & Assert 
            Assert.Throws<FormatException>(() => shotService.Create(shot));
        }

        [Fact]
        public void Creating_Shot_With_Bad_value_2()
        {
            // Arrange
            var shot = "12";
            var shotService = new ShotService();

            // act & Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() => shotService.Create(shot));
        }

        [Theory]
        [InlineData("0")]
        [InlineData("5")]
        [InlineData("10")]
        public void Creating_Shot_With_Right_value_2(string shot)
        {
            // Arrange
            var shotService = new ShotService();

            // act & Assert 
            Assert.Equal<uint>(uint.Parse(shot), shotService.Create(shot).Value);
        }
    }
}
