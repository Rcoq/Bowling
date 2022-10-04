using Bowling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Services
{
    public  class ShotService
    {
        public List<Shot> CreateList(string[] shots)
        {
            if (shots == null || shots.Length == 0)
                throw new ArgumentOutOfRangeException();

            var shotsList = new List<Shot>();
            foreach (var shot in shots)
            {
                shotsList.Add(Create(shot));
            }
            return shotsList;
        }
        public Shot Create(string shot)
        {
            if (!uint.TryParse(shot, out uint value))
                throw new FormatException($"Shot value is incorrect. Actule value {shot}");

            var shotParsed = uint.Parse(shot);
            if (shotParsed > 10)
                throw new ArgumentOutOfRangeException(nameof(shot), shotParsed, "Shot value must be beteween 0 and 10");

            return new Shot(shotParsed);
        }
    }
}
