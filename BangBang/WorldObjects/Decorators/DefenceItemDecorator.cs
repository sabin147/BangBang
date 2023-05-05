using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBang.WorldObjects.Decorators
{
    public class DefenceItemDecorator : ItemDecorator,IDefenceItem
    {
        protected int _extraReductionPoints;

        public DefenceItemDecorator(IDefenceItem defenceItem, int extraReductionPoints) : base(defenceItem)
        {
            _extraReductionPoints = extraReductionPoints;
        }

        public override int GetReduceHitPoints()
        {
            return base.GetReduceHitPoints() + _extraReductionPoints;
        }
        
    }
}
