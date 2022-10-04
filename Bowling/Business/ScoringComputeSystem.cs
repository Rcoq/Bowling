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
        public void Compute(Game game) {
            uint score = 0;
            for (int i = 0; i < game.FramesList.Count; i++)
            {
                if (game.FramesList[0].TypeIs == Frame.Type.Strike)
                {
                    score += StrikeCompute();

                    if (i + 1 < game.FramesList.Count && game.FramesList[0].TypeIs == Frame.Type.Strike )
                        score += StrikeCompute();
                }
                else if (game.FramesList[i].TypeIs == Frame.Type.Spare) {
                    if (i + 1 < game.FramesList.Count)
                        score += SpareCompute(game.FramesList[i], game.FramesList[i+1]);
                    else
                        score += NormalCompute(game.FramesList[i]);
                }
                else
                { 
                    score += NormalCompute(game.FramesList[i]);
                }
                Console.WriteLine(score);
            }

        }

        public uint ComputeFrame(Frame frame)
        {
            return 0;
        }


        private uint StrikeCompute() { return 10; }
        private uint SpareCompute(Frame firstFrame, Frame? secondFrame) {

            return NormalCompute(firstFrame) + (secondFrame != null ? secondFrame.ShootsList[0].Value : 0) ;
        }
        private uint NormalCompute(Frame frame) { 
            return frame.ShootsList.Count == 2 ? frame.ShootsList[0].Value + frame.ShootsList[1].Value : frame.ShootsList[0].Value; 
        }
    }
}
