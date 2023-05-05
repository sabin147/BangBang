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

        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x">The X-coordinate of the position.</param>
        /// <param name="y">The Y-coordinate of the position.</param>
        public Position (int x, int y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// Calculates the Euclidean distance between this position and the position of the specified creature.
        /// </summary>
        /// <param name="creature">The creature whose position will be used to calculate the distance.</param>
        /// <returns>The Euclidean distance between this position and the position of the specified creature.</returns>
        public double DistanceBetween(Creature creature)
        {
            int dx = X - creature.Position.X;
            int dy = Y - creature.Position.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
