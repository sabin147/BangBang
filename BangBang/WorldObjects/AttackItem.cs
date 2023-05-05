using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBang.WorldObjects
{
    public class AttackItem : WorldObject,IAttackItem
    {
        public int HitPoint { get; set; }
        public int Range { get; set; }
       
        public AttackItem(int hitPoint, int range, string name, Position position) : base(name,position)
        {
            HitPoint = hitPoint;
            Range = range;
            
                       
        }


        public virtual int GetHitPoints()
        {
            return HitPoint;
        }
    }
}
