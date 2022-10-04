using Bowling.Models;
using Bowling.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Tests
{
    public class FrameServiceTest
    {
        [Fact]
        public void Create_Frame_Is_A_Strike()
        {
            // Arrange
            var shotsList = new List<Shot>() { new Shot(10) };
            var frameService = new FrameService();

            // Act
            var frame = frameService.Create(1, shotsList, Frame.Type.Strike);

            // Assert
            Assert.Equal(10, frame.Score);
            Assert.Equal(Frame.Type.Strike, frame.TypeIs);
            int count = frame.ShootsList.Count;
            Assert.Equal(1, count);
        }
        [Fact]
        public void Create_Frame_Is_A_Strike_With_2_Shots()
        {
            // Arrange
            var shotsList = new List<Shot>() { new Shot(10), new Shot(2) };
            var frameService = new FrameService();

            // Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => frameService.Create(1, shotsList, Frame.Type.Strike));

        }

        [Fact]
        public void Create_Frame_Is_A_Strike_With_one_Shots_different_than_10()
        {
            // Arrange
            var shotsList = new List<Shot>() { new Shot(2) };
            var frameService = new FrameService();

            // Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => frameService.Create(1, shotsList, Frame.Type.Strike));

        }

        //[Fact]
        //public void Create_Frame_Is_A_Spare_With_one_Shots_different_than_10()
        //{
        //    // Arrange
        //    var shotsList = new List<Shot>() { new Shot(2) };
        //    var frameService = new FrameService();

        //    // Act && Assert
        //    Assert.Throws<ArgumentOutOfRangeException>(() => frameService.Create(1, shotsList, Frame.Type.Strike));

        //}
    }
}
