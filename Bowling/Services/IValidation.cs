using Bowling.Models;

namespace Bowling.Services
{
    public interface IValidation
    {
        public void CheckValidatyShotsNumber(int? shootNumber);
        public void CheckValidatyShotsValue(string[] shots);

        public void CheckValidatyFramesShotsValue(Frame frame);
    }
}
