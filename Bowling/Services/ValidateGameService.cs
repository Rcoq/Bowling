using Bowling.Models;

namespace Bowling.Services
{
    public class ValidateGameService : IValidateGame
    {

        //public bool GameIsValid() { return true; }
        //public bool ShotNumberIsValid(int numberShoot)
        //{
        //    var isValid = true;
        //    if (numberShoot <= 0 || numberShoot > 21) isValid = false;

        //    return isValid;
        //}
        //public bool ShotValueIsValid(string shootValue)
        //{
        //    bool success = int.TryParse(shootValue, out int number);

        //    if (!success || number < 0 || number > 10) return false;

        //    return success;
        //}

        ////*****************************************************************
        //// The shot is valid if
        //// ==> shot is a strike (shift right +1)
        //// ==> shot is not a strike and the sum of two next shots is less than 11 (shift right + 2)
        ////*****************************************************************
        //public bool ShotsListIsValid(List<Shot> shotsList)
        //{
        //    var cursor = 0;
        //    while (cursor < shotsList.Count)
        //    {
        //        //if (shotIsAStrike(shotsList[cursor].ShootValue))
        //        //{
        //        //    cursor++;
        //        //}
        //        //else if (TwoShotsSumIsValid(cursor, shotsList))
        //        //{
        //        //    cursor += 2;
        //        //}
        //        //else return false;
        //    }
        //    return true;
        //}

        //private static bool shotIsAStrike(uint shotValue) {
        //    if (shotValue == 10) return true;
        //    else return false;
        //}

        //private static bool TwoShotsSumIsValid(int cursor, List<Shot> shotsList)
        //{
        //    //if (cursor + 1 < shotsList.Count && ((shotsList[cursor].ShootValue + shotsList[cursor + 1].ShootValue) > 10))
        //    //{
        //    //    return false;
        //    //}
        //    if (true) return true;
        //    else return true;
        //}

        //public void ValidateGame(Game game)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool CheckShotNumber(int shootNumber)
        //{
        //    throw new NotImplementedException();
        //}
        public void CheckValidatyShotsNumber(int? shootNumber)
        {
            if (shootNumber == null || shootNumber < 1 || shootNumber > 21)
                throw new ArgumentOutOfRangeException(nameof(shootNumber), shootNumber, "Number of shots must be beteween 1 and 21");
        }

        public void CheckValidatyShotsValue(string[] shots)
        {
            var badShotExists = shots.FirstOrDefault(x => uint.TryParse(x, out uint number) == false);

            if (badShotExists != null)
                throw new FormatException($"This shot value '{badShotExists}' is incorrect");

            badShotExists = shots.FirstOrDefault(x => uint.Parse(x) >10);

            if (badShotExists != null)
                throw new ArgumentOutOfRangeException(nameof(badShotExists), badShotExists, "Shot value must be beteween 0 and 10");

        }
        public void CheckValidatyFramesShotsValue(Frame frame)
        {
            if (frame == null)
                throw new NullReferenceException($"Frrame is null");
            // The specific case is the frame number 10 if it has 3 shot and the first it is not a strike
            // 8 - 2 - 10 is valid
            // 8 - 0 - 10 is no valid
            else if (frame.Id == 10 && frame.ShootsList.Count == 3)
            {
                if(frame.ShootsList[0].Value != 10) {
                    var shotsValue = frame.ShootsList[0].Value + frame.ShootsList[1].Value;
                    if (shotsValue != 10)
                    {
                        throw new ArgumentOutOfRangeException("Lastest Frame", $"{frame.ShootsList[0].Value}-{frame.ShootsList[1].Value}-{frame.ShootsList[2].Value}", $"The shots value of latest frame is incorrect");
                    }
                }
            }
            else
            {
                if (frame.ShootsList[0].Value != 10)
                {
                    var sum = frame.ShootsList.Sum(x => x.Value);
                    if (sum > 10)
                    {
                        throw new ArgumentOutOfRangeException("Sum of frame", sum, $"The Sum of the frame {frame.Id} is more than 10");
                    }
                }
            }
        }
    }
}
