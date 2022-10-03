namespace Bowling.Models
{
    public class Shot
    {
        private readonly uint _value;
        public Shot(uint value)
        {
            _value = value;
        }
        public uint Value => _value;
    }
}
