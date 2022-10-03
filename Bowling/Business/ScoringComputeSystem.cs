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
        public static void Compute(Game game) { 
            for(int i=0; i < game.FramesList.Count; i++)
            {

            }
        
        }


        private int StrikeCompute() { return 0; }
        private int SpareCompute() { return 0; }
        private int NormalComput() { return 0; }
    }
}
