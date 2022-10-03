using Bowling.Models;
using Bowling.Services;

namespace Bowling.Business
{
    public class GameBuilder
    {
        private readonly IValidateGame _validateGame;
        public GameBuilder(IValidateGame validateGame)
        {
            _validateGame = validateGame;
        }
        public Game Build(string[] shots)
        {
            if(shots == null)
                throw new NullReferenceException($"Shots paramater is null");
            if (shots.Length == 0) 
                throw new ArgumentOutOfRangeException(nameof(shots),$"Shots paramater = 0");

            _validateGame.CheckValidatyShotsNumber(shots.Length);
            _validateGame.CheckValidatyShotsValue(shots);

            var frames = CreateFrames(shots.Select(x =>uint.Parse(x)).ToList());


            return new Game(frames);
        }

        private List<Frame> CreateFrames(List<uint> shotsParsed)
        {
            var frames = new List<Frame>();
            var frameNumber = 1;
            var i = 0;
            while (i < shotsParsed.Count && frameNumber <= 10)
            {
                var shot = new Shot(shotsParsed[i]);
                var shotsList = new List<Shot>() { shot };
                var frame = new Frame(frameNumber, shotsList);

                if (frameNumber == 10)
                {
                    if (i + 1 < shotsParsed.Count) shotsList.Add(new Shot(shotsParsed[i + 1]));
                    if (i + 2 < shotsParsed.Count) shotsList.Add(new Shot(shotsParsed[i + 2]));

                    frame.ShootsList = shotsList;
                    _validateGame.CheckValidatyFramesShotsValue(frame);
                    frame.TypeIs = Frame.Type.Strike;

                    i++;
                }
                
                else if (shotsParsed[i] == 10)
                {
                    i++;
                    frame.TypeIs = Frame.Type.Strike;
                }
                else
                {

                    if (i + 1 < shotsParsed.Count) shotsList.Add(new Shot(shotsParsed[i + 1]));

                    frame.ShootsList = shotsList;

                    _validateGame.CheckValidatyFramesShotsValue(frame);

                    if (i + 1 < shotsParsed.Count && shotsList[0].Value + shotsList[1].Value == 10) frame.TypeIs = Frame.Type.Spare;

                    i += 2;
                }
                frames.Add(frame);
                frameNumber++;
            }

            return frames;
        }

    }
}
