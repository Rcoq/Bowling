using Bowling.Business;
using Bowling.Models;
using Bowling.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Tests
{
    public class GameBuilderTests
    {
        [Fact]
        public void Build_Shots_Is_Null()
        {
            // Arrange
            var validateGameServiceMock = new Mock<IValidation>();
            var gameBuilder = new GameService(validateGameServiceMock.Object);

            // act & Assert
            Assert.Throws<NullReferenceException>(() => gameBuilder.Create(null));
        }
        [Fact]
        public void Build_Shots_Is_Empty()
        {
            // Arrange
            var validateGameServiceMock = new Mock<IValidation>();
            var gameBuilder = new GameService(validateGameServiceMock.Object);


            // act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => gameBuilder.Create(Array.Empty<string>()));
        }
    }
}
