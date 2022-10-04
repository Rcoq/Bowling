namespace Bowling.Models
{
    public class Frame
    {
        public enum Type { Strike, Spare, Normal }

        private readonly int _id;
        private Type _type;
        private List<Shot> _shotsList;

        public Frame(int id, List<Shot> shotsList, Type type)
        {
            _shotsList = shotsList;
            _id = id;
            _type = type;
        }

        public int Id => _id;
        public Type TypeIs { get => _type; set => _type = value; }
        public long Score => _shotsList.Sum(x => x.Value);

        public List<Shot> ShootsList { get => _shotsList; set => _shotsList = value != null ? value : throw new ArgumentException("ShotList can not be null"); }
    }
}
