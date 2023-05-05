using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBang.Creatures.States
{
    public interface ICreatureState
    {
        void HandleState(Creature creature);
    }
}
