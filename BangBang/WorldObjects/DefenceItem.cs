using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BangBang.WorldObjects
{
    public class DefenceItem : WorldObject, IDefenceItem
    {
        public virtual int ReduceHitPoint { get; set; } 
        
        
        public DefenceItem(int reduceHitPoint,string name, Position position) : base(name,position)
        {
            ReduceHitPoint = reduceHitPoint;
        }
        public int GetReduceHitPoints()
        {
            return ReduceHitPoint;
        }
    }
}
