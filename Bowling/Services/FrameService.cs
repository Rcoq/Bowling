using Bowling.Models;

namespace Bowling.Services
{
    public class FrameService
    {
        public List<Frame> CreateList(List<Shot> shots)
        {
            if (shots == null || shots.Count == 0)
                throw new ArgumentOutOfRangeException(nameof(shots), $"The shots list is not valid. Shots List = 0");

            var frames = new List<Frame>();
            var frameNumber = 1;
            var i = 0;
            while (i < shots.Count && frameNumber <= 10)
            {
                var shot = shots[i];
                var type = Frame.Type.Normal;

                // If Frame.id == 10
                if (frameNumber == 10)
                {
                    // Frame 10 has three shots
                    if (i + 2 < shots.Count)
                    {
                        if ((shots[i].Value + shots[i + 1].Value) == 10)
                            type = Frame.Type.Spare;
                        else if (shots[i].Value == 10)
                            type = Frame.Type.Strike;

                        frames.Add(Create(frameNumber, new List<Shot>() { shot, shots[i + 1], shots[i + 2] }, type));
                        i += 2;
                    }
                    // Frame 10 has two shots
                    else if (i + 1 < shots.Count)
                    {
                        if (shots[i].Value != 10 && (shots[i].Value + shots[i+1].Value) == 10)
                            type = Frame.Type.Spare;

                        frames.Add(Create(frameNumber, new List<Shot>() { shot, shots[i + 1] }, type));
                        i += 2;
                    }
                    else
                    {
                        if(shots[i].Value == 10)
                            type = Frame.Type.Strike;

                        frames.Add(Create(frameNumber, new List<Shot>() { shot }, type));
                        i++;
                    }
                }
                // If Frame.id != 10 && If shot != strike
                else if (shots[i].Value == 10)
                {
                    frames.Add(Create(frameNumber, new List<Shot>() { shot }, Frame.Type.Strike));
                    i++;
                }
                else
                {
                    // Frame has two shots
                    if (i + 1 < shots.Count)
                    {
                        if ((shots[i].Value + shots[i + 1].Value) == 10)
                            type = Frame.Type.Spare;
                        frames.Add(Create(frameNumber, new List<Shot>() { shot, shots[i + 1] }, type));
                        i += 2;
                    }
                    // Frame has one 
                    else
                    {
                        if (shots[i].Value == 10)
                            type = Frame.Type.Strike;
                        frames.Add(Create(frameNumber, new List<Shot>() { shot }, type));
                        i++;
                    }
                }
                frameNumber++;
            }
            return frames;

        }
        public Frame Create(int id, List<Shot> shots, Frame.Type type)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id),$"The frame {id} is not valid. Id is under 0. Value : {id}");
            else if(shots == null || shots.Count == 0)
                throw new ArgumentOutOfRangeException(nameof(shots),$"The frame {id} is not valid. ShotsList = 0");


            var frame = new Frame(id, shots, type);

            // Check Validity for the frame 10
            if (frame.Id == 10)
            {
                if (frame.TypeIs == Frame.Type.Strike && (frame.Score != 10)) 
                    throw new ArgumentOutOfRangeException(nameof(frame.Id), $"The frame {frame.Id} is not valid.");
                if (frame.TypeIs == Frame.Type.Spare && (frame.ShootsList.Count <2 || frame.Score < 10)) 
                    throw new ArgumentOutOfRangeException(nameof(frame.Id), $"The frame {frame.Id} is not valid.");
            }
            // Check Validty for the frame under 10
            // Check Strike Validity
            else if (frame.TypeIs == Frame.Type.Strike && frame.ShootsList.Count > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(frame.ShootsList), frame.ShootsList, $"The frame {frame.Id} is a strike but the ShootsList = {frame.ShootsList.Count}");
            }
            else if (frame.TypeIs == Frame.Type.Strike && frame.Score != 10)
            {
                throw new ArgumentOutOfRangeException(nameof(frame.Score), frame.Score, $"The frame {frame.Id} is a strike but the Score =  {frame.Score}");
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

            return frame;
        }

    }
}

