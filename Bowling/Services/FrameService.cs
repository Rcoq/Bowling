using Bowling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Services
{
    public class FrameService
    {
        public List<Frame> CreateList(List<Shot> shots)
        {
            if (shots == null || shots.Count == 0)
                throw new ArgumentOutOfRangeException(nameof(shots), $"The shots list is not valid. ShotsList = 0");

            var frames = new List<Frame>();
            var frameNumber = 1;
            var i = 0;
            while (i < shots.Count && frameNumber <= 10)
            {
                var shot = shots[i];
                var shotsList = new List<Shot>() { shot };
                var frame = new Frame(frameNumber, shotsList);

                // If Frame.id == 10
                if (frameNumber == 10)
                {
                    // Frame 10 has three shots
                    if (i + 2 < shots.Count)
                    {
                        frames.Add(Create(frameNumber, new List<Shot>() { shot, shots[i + 1], shots[i + 2] }));
                        i += 2;
                    }
                    // Frame 10 has two shots
                    else if (i + 1 < shots.Count)
                    {
                        frames.Add(Create(frameNumber, new List<Shot>() { shot, shots[i + 1] }));
                        i += 2;
                    }
                    else
                    {
                        frames.Add(Create(frameNumber, new List<Shot>() { shot }));
                        i++;
                    }
                }
                // If Frame.id != 10 && If shot != strike
                else
                {
                    // Frame has two shots
                    if (i + 1 < shots.Count)
                    {
                        frame = Create(frameNumber, new List<Shot>() { shot, shots[i + 1] });
                        i += 2;
                    }
                    // Frame has one 
                    else
                    {
                        frame = Create(frameNumber, new List<Shot>() { shot });
                        i++;
                    }
                    frames.Add(frame);
                }
                frameNumber++;
            }
            return frames;

        }
        public Frame Create(int id, List<Shot> shots, Frame.Type type = Frame.Type.Normal)
        {

            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id),$"The frame {id} is not valid. Id is under 0. Value : {id}");
            else if(shots == null || shots.Count == 0)
                throw new ArgumentOutOfRangeException(nameof(shots),$"The frame {id} is not valid. ShotsList = 0");


            var frame = new Frame(id, shots, type);

            // Check Validity for the frame 10
            if (frame.Id == 10)
            {
                if (frame.TypeIs == Frame.Type.Strike && (frame.ShootsList.Count != 3 || frame.Score > 30)) 
                    throw new ArgumentOutOfRangeException(nameof(frame.Id), $"The frame {frame.Id} is not valid.");
                if (frame.TypeIs == Frame.Type.Spare && (frame.ShootsList.Count != 3 || frame.Score > 20)) 
                    throw new ArgumentOutOfRangeException(nameof(frame.Id), $"The frame {frame.Id} is not valid.");
                if (frame.TypeIs == Frame.Type.Normal && frame.ShootsList.Count > 2 && frame.Score < 10) 
                    throw new ArgumentOutOfRangeException(nameof(frame.Id), $"The frame {frame.Id} is not valid.");
            }
            // Check Validty for the frame under 10
            // Check Strike Validity
            else if (frame.TypeIs == Frame.Type.Strike && (frame.ShootsList.Count > 1 || frame.Score != 10))
            {
                throw new ArgumentOutOfRangeException(nameof(frame.Score), frame.Score, $"The Sum of the frame {frame.Id} is not equal 10. Value : {frame.Score}");
            }
            // Check Spare Validity
            else if (frame.TypeIs == Frame.Type.Spare && shots.Count != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(frame.TypeIs), frame.TypeIs, $"The type of the frame {frame.Id} is incorrect. Value {frame.TypeIs} and number shot is {frame.ShootsList.Count} ");
            }
            else if(frame.TypeIs == Frame.Type.Spare && frame.Score != 10)
            {
                throw new ArgumentOutOfRangeException(nameof(frame.Score), frame.Score, $"The Sum of the frame {frame.Id} is more than 10. Value : {frame.Score}");

            }
            // Check Normal shoots Validity
            else if (frame.TypeIs == Frame.Type.Normal && frame.Score > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(frame.Score), frame.Score, $"The Sum of the frame {frame.Id} is more than 10. Value : {frame.Score}");
            }

            if(frame.TypeIs == Frame.Type.Normal)
            {
                if (shots.Count == 2 && frame.Score == 10)
                    frame.TypeIs = Frame.Type.Spare;

                else if (shots.Count == 1 && frame.Score == 10)
                    frame.TypeIs = Frame.Type.Strike;
            }

            return frame;
        }

    }
}

