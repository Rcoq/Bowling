using Bowling.Models;

namespace Bowling.Services
{
    public class GameService
    {

        public Game Create(List<Frame> frames)
        {
            if (frames == null || frames.Count == 0)
                throw new ArgumentOutOfRangeException(nameof(frames), $"The game is not valid. Frames List = 0");

            return new Game(frames);
        }
    }
}
