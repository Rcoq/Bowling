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
            var validateGameServiceMock = new Mock<IValidateGame>();
            var gameBuilder = new GameBuilder(validateGameServiceMock.Object);

            // act & Assert
            Assert.Throws<NullReferenceException>(() => gameBuilder.Build(null));
        }
        [Fact]
        public void Build_Shots_Is_Empty()
        {
            // Arrange
            var validateGameServiceMock = new Mock<IValidateGame>();
            var gameBuilder = new GameBuilder(validateGameServiceMock.Object);


            // act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => gameBuilder.Build(Array.Empty<string>()));
        }
        //*********************************************************************************************************************//
        //*********************************************************************************************************************//
        //*********************************************************************************************************************//

        //[Fact]
        //public void Build_Failed_Shots_Number_Is_Incorrect()
        //{
        //    // Arrange
        //    var validateGameServiceMock = new Mock<IValidateGame>();
        //    var gameBuilder = new GameBuilder(validateGameServiceMock.Object);

        //    validateGameServiceMock.Setup(x => x.CheckValidatyShotsNumber(22)).Throws<ArgumentOutOfRangeException>();

        //    gameBuilder.Build(new string[] { "2", "1", "10", "0", "10", "4", "2", "0", "10", "6", "2", "0", "10", "6", "4", "8", "2", "9", "10", "10", "10", "10" });
        //    validateGameServiceMock.Verify(x => x.CheckValidatyShotsNumber(22));
        //}
        //[Fact]

        //public void Build_Failed_Shots_Values_Is_Incorrect()
        //{
        //    // Arrange
        //    var validateGameServiceMock = new Mock<IValidateGame>();
        //    var gameBuilder = new GameBuilder(validateGameServiceMock.Object);
        //    var paramaters = new string[] { "a", "1", "10", "0", "10", "4", "2", "0", "10", "6", "2", "0", "10", "6", "4", "8", "2" };

        //    validateGameServiceMock.Setup(x => x.CheckValidatyShotsValue(paramaters)).Throws<FormatException>();

        //    gameBuilder.Build(paramaters);
        //    validateGameServiceMock.Verify(x => x.CheckValidatyShotsValue(paramaters), Times.Once);
        //}

    }
}
