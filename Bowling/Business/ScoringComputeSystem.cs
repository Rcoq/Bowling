using Bowling.Models;
using Bowling.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Business
{
    public class ScoringComputeSystem
    {
        public uint ComputeGame(Game game) {

            if (game == null)
                throw new ArgumentOutOfRangeException($"Impossible to compute game is null");

            uint score = 0;
            for (int i= 0; i < game.FramesList.Count; i++)
            {
                if (game.FramesList[i].TypeIs == Frame.Type.Strike)
                {
                    var frames = new List<Frame>() { game.FramesList[i] };

                    if (i + 1 < game.FramesList.Count) 
                    {
                        frames.Add(game.FramesList[i + 1]);
                        if(i + 2 < game.FramesList.Count && game.FramesList[i + 1].TypeIs == Frame.Type.Strike)
                            frames.Add(game.FramesList[i + 2]);

                    }

                    score += StrikeCompute(frames);
                }
                else if (game.FramesList[i].TypeIs == Frame.Type.Spare)
                {
                    var frames = new List<Frame>() { game.FramesList[i] };

                    if (i + 1 < game.FramesList.Count) frames.Add(game.FramesList[i + 1]);

                    score += SpareCompute(frames);
                }
                else
                {
                    score += NormalCompute(game.FramesList[i]);
                }

                var shot1 = game.FramesList[i].ShootsList[0].Value;
                var shot2 = game.FramesList[i].ShootsList.Count == 2 ? game.FramesList[i].ShootsList[1].Value : ' ';
                Console.WriteLine($"Frame {game.FramesList[i].Id} -- shot1 : {shot1} -- shot2 : {shot2} -- Score : {score}");

            }
            return score;
        }


        public uint StrikeCompute(List<Frame> frames)
        {
            if (frames == null || frames[0].TypeIs != Frame.Type.Strike)
                throw new ArgumentOutOfRangeException($"Impossible to compute Frame is null");


            uint score = 0;
            foreach(Frame frame in frames)
            {
                score += (uint)frame.Score;
            }

            return score;
        }

        public uint SpareCompute(List<Frame> frames) {

            if (frames == null || frames[0].TypeIs != Frame.Type.Spare)
                throw new ArgumentOutOfRangeException($"Impossible to compute Frame is null");


            return (uint)frames[0].Score + (frames.Count == 2 ? frames[1].ShootsList[0].Value : 0) ;
        }
        public uint NormalCompute(Frame frame) { 

            if(frame == null || frame.TypeIs != Frame.Type.Normal)
                throw new ArgumentOutOfRangeException($"Impossible to compute Frame is null");

            return (uint) frame.Score; 
        }
    }
}
