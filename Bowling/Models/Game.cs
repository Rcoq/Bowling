namespace Bowling.Models
{
    public class Game
    {
        private readonly List<Frame> _framesList;
        public Game(List<Frame> framesList)
        {
            _framesList = framesList;
        }
        public List<Frame> FramesList => _framesList;
    }
}
