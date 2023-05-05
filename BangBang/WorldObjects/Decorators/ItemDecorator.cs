using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBang.WorldObjects.Decorators
{
    public abstract class ItemDecorator : IAttackItem, IDefenceItem
    {



        protected IAttackItem _attackItem;
        protected IDefenceItem _defenceItem;



        public ItemDecorator(IAttackItem attackItem)
        {
            _attackItem = attackItem;
        }

        public ItemDecorator(IDefenceItem defenceItem)
        {
            _defenceItem = defenceItem;
        }

        public virtual int GetHitPoints()
        {
            return _attackItem.GetHitPoints();
        }

        public virtual int GetReduceHitPoints()
        {
            return _defenceItem.GetReduceHitPoints();
        }
    }
}
