using Bowling.Business;
using Bowling.Models;
using Bowling.Services;

namespace Bowling.Tests
{
    public  class ScoringComputeSystemTest
    {

        // Test ComputeGame() method
        [Fact]
        public void Compute_With_A_Game_Equal_Null() {
            // Arrange
            var scoringComputeSystem = new ScoringComputeSystem();

            // Act Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => scoringComputeSystem.ComputeGame(null));

        }
        [Fact]
        public void Compute_With_A_Valid_Game_Equal_131()
        {

            // Arrange
            var shots = new string[] {"1","2","10","0","10","4","2","0","10","6","2","0","10","6","4","8","2","2","8","8"};
            var shotService = new ShotService();
            var frameService = new FrameService();
            var gameService = new  GameService();
            var scoringComputeSystem = new ScoringComputeSystem();

            // Act
            var score = scoringComputeSystem.ComputeGame(gameService.Create(frameService.CreateList(shotService.CreateList(shots))));

            // Assert
            Assert.Equal<uint>(131, score);
        }

        [Fact]
        public void Compute_With_A_Valid_Game_Equal_109()
        {

            // Arrange
            var shots = new string[] { "0", "10", "1", "7", "0", "10", "0", "2", "0", "10", "6", "0", "10", "0", "10", "6", "2", "0", "10", "2" };
            var shotService = new ShotService();
            var frameService = new FrameService();
            var gameService = new GameService();
            var scoringComputeSystem = new ScoringComputeSystem();

            // Act
            var score = scoringComputeSystem.ComputeGame(gameService.Create(frameService.CreateList(shotService.CreateList(shots))));

            // Assert
            Assert.Equal<uint>(109, score);
        }

        [Fact]
        public void Compute_With_A_Valid_Game_Equal_35()
        {

            // Arrange
            var shots = new string[] { "5","2","10","7","0","4"};
            var shotService = new ShotService();
            var frameService = new FrameService();
            var gameService = new GameService();
            var scoringComputeSystem = new ScoringComputeSystem();

            // Act
            var score = scoringComputeSystem.ComputeGame(gameService.Create(frameService.CreateList(shotService.CreateList(shots))));

            // Assert
            Assert.Equal<uint>(35, score);
        }

        /*******************************************************************************************************************************************************/
        /*******************************************************************************************************************************************************/
        /*******************************************************************************************************************************************************/


        // Test NormalCompute() method

        [Fact]
        public void NormalCompute_With_A_Null_Frame()
        {

            // Arrange
            var scoringComputeSystem = new ScoringComputeSystem();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => scoringComputeSystem.NormalCompute(null));

        }

        [Fact]
        public void NormalCompute_With_A_Bad_Frame_TypeFrame_Is_Incorret()
        {

            // Arrange
            var frame = new Frame(1, new List<Shot>() { new Shot(2), new Shot(5) }, Frame.Type.Spare);
            var scoringComputeSystem = new ScoringComputeSystem();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => scoringComputeSystem.NormalCompute(frame));

        }

        [Fact]
        public void NormalCompute_With_A_Right_Frame1()
        {

            // Arrange
            var frame = new Frame(1,new List<Shot>(){ new Shot(2), new Shot(5) }, Frame.Type.Normal);
            var scoringComputeSystem = new ScoringComputeSystem();

            // Act & Assert
            Assert.Equal<uint>(7, scoringComputeSystem.NormalCompute(frame));

        }

        [Fact]
        public void NormalCompute_With_A_Right_Frame2()
        {

            // Arrange
            var frame = new Frame(1, new List<Shot>() { new Shot(2) }, Frame.Type.Normal);
            var scoringComputeSystem = new ScoringComputeSystem();

            // Act & Assert
            Assert.Equal<uint>(2, scoringComputeSystem.NormalCompute(frame));

        }

        /*******************************************************************************************************************************************************/
        /*******************************************************************************************************************************************************/
        /*******************************************************************************************************************************************************/


        // Test SpareCompute() method

        [Fact]
        public void SpareCompute_With_A_Null_Frame()
        {

            // Arrange
            var scoringComputeSystem = new ScoringComputeSystem();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => scoringComputeSystem.SpareCompute(null));

        }

        [Fact]
        public void SpareCompute_With_A_Bad_Frame_TypeFrame_Is_Incorret()
        {

            // Arrange
            var frame1 = new Frame(1, new List<Shot>() { new Shot(2), new Shot(8) }, Frame.Type.Strike);
            var frame2 = new Frame(2, new List<Shot>() { new Shot(2), new Shot(6) }, Frame.Type.Spare);
            var scoringComputeSystem = new ScoringComputeSystem();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => scoringComputeSystem.SpareCompute(new List<Frame>() { frame1, frame2 }));

        }

        [Fact]
        public void NormalCompute_With_A_Right_Lisr_Frames_1()
        {

            // Arrange
            var frame1 = new Frame(1, new List<Shot>() { new Shot(2), new Shot(8) }, Frame.Type.Spare);
            var frame2 = new Frame(2, new List<Shot>() { new Shot(2), new Shot(6) }, Frame.Type.Spare);

            // Act
            var scoringComputeSystem = new ScoringComputeSystem();

            // Assert 
            Assert.Equal<uint>(12, scoringComputeSystem.SpareCompute(new List<Frame>() { frame1,frame2}));

        }


        [Fact]
        public void NormalCompute_With_A_Right_List_Frames_2()
        {

            // Arrange
            var frame1 = new Frame(1, new List<Shot>() { new Shot(2), new Shot(8) }, Frame.Type.Spare);


            // Act
            var scoringComputeSystem = new ScoringComputeSystem();

            // Assert
            Assert.Equal<uint>(10, scoringComputeSystem.SpareCompute(new List<Frame>() { frame1  }));

        }

        [Fact]
        public void NormalCompute_With_A_Right_List_Frames_3()
        {

            // Arrange
            var frame1 = new Frame(1, new List<Shot>() { new Shot(2), new Shot(8) }, Frame.Type.Spare);
            var frame2 = new Frame(2, new List<Shot>() { new Shot(3) }, Frame.Type.Normal);

            // Act
            var scoringComputeSystem = new ScoringComputeSystem();

            // Assert
            Assert.Equal<uint>(13, scoringComputeSystem.SpareCompute(new List<Frame>() { frame1, frame2}));

        }


        /*******************************************************************************************************************************************************/
        /*******************************************************************************************************************************************************/
        /*******************************************************************************************************************************************************/

        // Test StrikeCompute() method

        [Fact]
        public void StrikeCompute_With_A_Null_Frame()
        {

            // Arrange
            var scoringComputeSystem = new ScoringComputeSystem();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => scoringComputeSystem.StrikeCompute(null));

        }

        [Fact]
        public void StrikeCompute_With_A_Bad_Frame_TypeFrame_Is_Incorret()
        {

            // Arrange
            var frame1 = new Frame(1, new List<Shot>() { new Shot(2), new Shot(8) }, Frame.Type.Spare);
            var frame2 = new Frame(2, new List<Shot>() { new Shot(2), new Shot(6) }, Frame.Type.Spare);
            var scoringComputeSystem = new ScoringComputeSystem();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => scoringComputeSystem.StrikeCompute(new List<Frame>() { frame1, frame2 }));

        }

        [Fact]
        public void StrikeCompute_With_A_Right_List_Frames1()
        {

            // Arrange
            var frame1 = new Frame(1, new List<Shot>() { new Shot(10)}, Frame.Type.Strike);
            var frame2 = new Frame(2, new List<Shot>() { new Shot(10)},  Frame.Type.Strike);
            var frame3 = new Frame(3, new List<Shot>() { new Shot(10)},  Frame.Type.Strike);

            // Act
            var scoringComputeSystem = new ScoringComputeSystem();

            // Assert
            Assert.Equal<uint>(30, scoringComputeSystem.StrikeCompute(new List<Frame>() { frame1, frame2,frame3 }));


        }

        [Fact]
        public void StrikeCompute_With_A_Right_List_Frames2()
        {

            // Arrange
            var frame1 = new Frame(1, new List<Shot>() { new Shot(10) }, Frame.Type.Strike);
            var frame2 = new Frame(2, new List<Shot>() { new Shot(2), new Shot(3) }, Frame.Type.Normal);

            // Act
            var scoringComputeSystem = new ScoringComputeSystem();

            // Assert
            Assert.Equal<uint>(15, scoringComputeSystem.StrikeCompute(new List<Frame>() { frame1, frame2 }));


        }
    }
}
