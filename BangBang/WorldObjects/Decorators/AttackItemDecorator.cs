using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBang.WorldObjects.Decorators
{
    public class AttackItemDecorator : ItemDecorator, IAttackItem
    {
        protected int _extraHitPoints;


        public AttackItemDecorator(IAttackItem attackItem, int extraHitPoints) : base(attackItem)
        {
            _extraHitPoints = extraHitPoints;
        }

        public override int GetHitPoints()
        {
            return base.GetHitPoints() + _extraHitPoints;
        }
    }
}
