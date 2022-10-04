using Bowling.Models;
using Bowling.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Tests
{
    public class GameServiceTest
    {
     
        // Test Creat() method       
        [Fact]
        public void Create_Games_With_Null_Lists_Frame()
        {
            // Arrange
            var gameService = new GameService();

            // act & Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() => gameService.Create(null));
        }

        [Fact]
        public void Create_Games_With_Empty_Lists_Frame()
        {
            // Arrange
            var gameService = new GameService();

            // act & Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() => gameService.Create(new List<Frame>()));
        }

    }
}
