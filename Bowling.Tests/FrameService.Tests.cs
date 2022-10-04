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
        //Test CreatList() method 
        [Fact]
        public void Create_Shots_List_With_Null_List_Shot()
        {
            // Arrange
            var frameService = new FrameService();

            // act & Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() => frameService.CreateList(null));
        }

        [Fact]
        public void Create_Frame_List_With_Empty_List_Shot()
        {
            // Arrange
            var frameService = new FrameService();

            // act & Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() => frameService.CreateList(new List<Shot>()));
        }

        /*******************************************************************************************************************************************************/
        /*******************************************************************************************************************************************************/
        /*******************************************************************************************************************************************************/

        // Test Creat() method       
        [Fact]
        public void Frame1_Is_A_Strike_With_2_Shots()
        {
            // Arrange
            var shotsList = new List<Shot>() { new Shot(10), new Shot(2) };
            var frameService = new FrameService();

            // Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => frameService.Create(1, shotsList, Frame.Type.Strike));

        }

        [Fact]
        public void Frame1_Is_A_Strike_With_A_Score_More_Than_10()
        {
            // Arrange
            var shotsList = new List<Shot>() { new Shot(2) };
            var frameService = new FrameService();

            // Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => frameService.Create(1, shotsList, Frame.Type.Strike));

        }

        [Fact]
        public void Frame1_Is_A_Spare_With_Only_Shot()
        {
            // Arrange
            var shotsList = new List<Shot>() { new Shot(2) };
            var frameService = new FrameService();

            // Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => frameService.Create(1, shotsList, Frame.Type.Strike));

        }

        [Fact]
        public void Frame1_Is_A_Spare_With_A_Score_More_Than_10()
        {
            // Arrange
            var shotsList = new List<Shot>() { new Shot(2) };
            var frameService = new FrameService();

            // Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => frameService.Create(1, shotsList, Frame.Type.Spare));

        }

        [Fact]
        public void Frame10_Is_A_Spare_With_Two_Shots()
        {
            // Arrange
            var shotsList = new List<Shot>() { new Shot(7), new Shot(2) };
            var frameService = new FrameService();

            // Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => frameService.Create(10, shotsList, Frame.Type.Strike));

        }

        [Fact]
        public void Frame10_Is_A_Normal_With_Two_Shots_Bad_Value()
        {
            // Arrange
            var shotsList = new List<Shot>() { new Shot(9), new Shot(9) };
            var frameService = new FrameService();

            // Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => frameService.Create(10, shotsList, Frame.Type.Normal));

        }

        [Fact]
        public void Frame10_Is_A_Strike_With_Two_Shots_Bad_Value()
        {
            // Arrange
            var shotsList = new List<Shot>() { new Shot(8), new Shot(9), new Shot(1) };
            var frameService = new FrameService();

            // Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => frameService.Create(10, shotsList, Frame.Type.Normal));

        }
    }
}
