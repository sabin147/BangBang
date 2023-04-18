using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBang
{
    public class DefenceItem : WorldObject
    {
        public int ReduceHitPoint { get; set; }

        public DefenceItem(int reduceHitPoint, bool lootable, string name, bool removable, Position position) : base(lootable, name, removable, position)
        {
            ReduceHitPoint = reduceHitPoint;
        }
    }
}
