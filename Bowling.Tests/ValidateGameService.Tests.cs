using Bowling.Models;
using Bowling.Services;


namespace Bowling.Tests
{
    public class ValidateGameServiceTest
    {
        [Fact]
        public void CheckValidatyShotsNumber_Is_Null()
        {
            // Arrange
            var validateGameService = new ValidateGameService();

            // act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => validateGameService.CheckValidatyShotsNumber(null));
        }

        [Fact]
        public void CheckValidatyShotsNumber_Is_0()
        {
            // Arrange
            var validateGameService = new ValidateGameService();

            // act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => validateGameService.CheckValidatyShotsNumber(0));
        }

        [Fact]
        public void CheckValidatyShotsNumber_Is_More_Than_21()
        {
            // Arrange
            var validateGameService = new ValidateGameService();

            // act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => validateGameService.CheckValidatyShotsNumber(22));
        }
        [Fact]
        public void CheckValidatyShotsNumber_Is_Correct()
        {
            // Arrange
            var validateGameService = new ValidateGameService();

            // act & Assert
            validateGameService.CheckValidatyShotsNumber(8);
        }
        //*********************************************************************************************************************//
        //*********************************************************************************************************************//
        //*********************************************************************************************************************//
        [Fact]
        public void CheckValidatyShotsValue_Is_Incorrect_cause_letter()
        {
            // Arrange
            var validateGameService = new ValidateGameService();
            var shotsValue = new string[] { "1", "2", "a", "10" };

            // act & Assert
            Assert.Throws<FormatException>(() => validateGameService.CheckValidatyShotsValue(shotsValue));
        }

        [Fact]
        public void CheckValidatyShotsValue_Is_Incorrect_cause_value_more_than_10()
        {
            // Arrange
            var validateGameService = new ValidateGameService();
            var shotsValue = new string[] { "1", "2", "a", "10" };

            // act & Assert
            Assert.Throws<FormatException>(() => validateGameService.CheckValidatyShotsValue(shotsValue));
        }
        //*********************************************************************************************************************//
        //*********************************************************************************************************************//
        //*********************************************************************************************************************//
        [Fact]
        public void CheckValidatyFramesShotsValue_Frame10_Have_Incorrect_Shots_01()
        {
            // Arrange
            var validateGameService = new ValidateGameService();
            var shots = new List<Shot> { new Shot(9), new Shot(9), new Shot(10) };
            var frame = new Frame(10, shots);

            // act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => validateGameService.CheckValidatyFramesShotsValue(frame));
        }

        [Fact]
        public void CheckValidatyFramesShotsValue_Frame10_Have_Incorrect_Shots_02()
        {
            // Arrange
            var validateGameService = new ValidateGameService();
            var shots = new List<Shot> { new Shot(0), new Shot(9), new Shot(10) };
            var frame = new Frame(10, shots);

            // act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => validateGameService.CheckValidatyFramesShotsValue(frame));
        }

        [Fact]
        public void CheckValidatyFramesShotsValue_Frame10_Have_Incorrect_Shots_03()
        {
            // Arrange
            var validateGameService = new ValidateGameService();
            var shots = new List<Shot> { new Shot(9), new Shot(9), new Shot(10) };
            var frame = new Frame(10, shots);

            // act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => validateGameService.CheckValidatyFramesShotsValue(frame));
        }




        [Fact]
        public void CheckValidatyFramesShotsValue_Frame10_Have_Incorrect_Shots_04()
        {
            // Arrange
            var validateGameService = new ValidateGameService();
            var frame = new Frame(10, new List<Shot> { new Shot(9), new Shot(9) });

            // act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => validateGameService.CheckValidatyFramesShotsValue(frame));
        }

        [Fact]
        public void CheckValidatyFramesShotsValue_Frame10_Have_Incorrect_Shots_05()
        {
            // Arrange
            var validateGameService = new ValidateGameService();
            var shots = new List<Shot> { new Shot(0), new Shot(8), new Shot(10) };
            var frame = new Frame(10, shots);
        }

        [Fact]
        public void CheckValidatyFramesShotsValue_Frame10_Have_Incorrect_Shots_06()
        {
            // Arrange
            var validateGameService = new ValidateGameService();
            var shots = new List<Shot> { new Shot(2), new Shot(8), new Shot(10) };
            var frame = new Frame(10, shots);
        }

        [Fact]
        public void CheckValidatyFramesShotsValue_Frame10_Have_Incorrect_Shots_07()
        {
            // Arrange
            var validateGameService = new ValidateGameService();
            var shots = new List<Shot> { new Shot(0), new Shot(0), new Shot(10) };
            var frame = new Frame(10, shots);

            // act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => validateGameService.CheckValidatyFramesShotsValue(frame));
        }


        [Fact]
        public void CheckValidatyFramesShotsValue_Frame2_Have_Incorrect_Shots_01()
        {
            // Arrange
            var validateGameService = new ValidateGameService();
            var frame = new Frame(2, new List<Shot> { new Shot(9), new Shot(9)});

            // act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => validateGameService.CheckValidatyFramesShotsValue(frame));
        }

        [Fact]
        public void CheckValidatyFramesShotsValue_Frame2_Have_Incorrect_Shots_02()
        {
            // Arrange
            var validateGameService = new ValidateGameService();
            var frame = new Frame(2, null);

            // act & Assert
            Assert.Throws<NullReferenceException>(() => validateGameService.CheckValidatyFramesShotsValue(frame));
        }

    }
}