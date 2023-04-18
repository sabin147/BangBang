namespace BangBang
{
    public class World
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public List<Creature> Creatures { get; }
        public List<WorldObject> Objects { get; }

        public World (int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            Creatures = new List<Creature>();
            Objects = new List<WorldObject>();
        }
    }
}