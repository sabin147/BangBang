using BangBang.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBang.Creatures.States
{
    public class DeadState : ICreatureState
    {
        
        private ILogger _logger;
        public DeadState(ILogger logger) 
        {
            _logger = logger;
        }
        public void HandleState(Creature creature)
        {
            World? world = World._instance;
            // Perform actions for a creature in a dead state
            if (world != null)
            {
                world.RemoveCreatureFromWorld(creature);
                _logger?.Log(TraceEventType.Information, $"{creature.Name}is dead and removed from world");
            }
            else
            {
                _logger?.Log(TraceEventType.Error, "Cannot remove a creature if the world doesn't exist");

            }
            _logger?.Log(System.Diagnostics.TraceEventType.Warning, $"{creature.Name} is in deadstate and cannot do anything and is removed from mlbbmap.");
            Console.WriteLine($"{creature.Name} is in deadstate and cannot do anything and is removed from mlbbmap.");
        }
    }
    
}
