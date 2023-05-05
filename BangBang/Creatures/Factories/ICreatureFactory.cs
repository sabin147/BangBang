using BangBang.Creatures;
using BangBang.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBang.Creatures.Factories
{
    public interface ICreatureFactory
    {
        Creature CreateCreature(string name, ILogger logger, int health, Position position);
    }

}
