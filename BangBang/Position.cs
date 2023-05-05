using BangBang.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBang
{
    public class Position
    {
       public int X { get; set; }
       public int Y { get; set; }

        public Position (int x, int y)
        {
            X = x;
            Y = y;
        }
        public double DistanceBetween(Creature creature)
        {
            int dx = X - creature.Position.X;
            int dy = Y - creature.Position.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
