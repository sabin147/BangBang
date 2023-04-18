using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBang
{
    public class AttackItem : WorldObject
    {
        public int HitPoint { get; set; }
        public int Range { get; set; }

        public AttackItem(int hitPoint, int range, bool lootable, string name, bool removable, Position position) : base(lootable, name, removable, position)
        {
            HitPoint = hitPoint;
            Range = range;  
        }


    }
}
