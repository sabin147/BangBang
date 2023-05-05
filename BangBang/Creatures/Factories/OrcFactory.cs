using BangBang.Creatures;
using BangBang.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBang.Creatures.Factories
{
    public class OrcFactory : ICreatureFactory
    {
        public Creature CreateCreature(string name, ILogger logger, int health, Position position)
        {
            var creature = new Creature(name, logger, health, position);
            return creature;
        }
    }
}
