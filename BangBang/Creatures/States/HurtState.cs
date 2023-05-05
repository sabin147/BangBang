using BangBang.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BangBang.Creatures.States
{
    public class HurtState : ICreatureState
    {
        private ILogger? _logger;
        public HurtState(ILogger? logger)
        {
            _logger = logger;
        }

        public void HandleState(Creature creature)
        {
            // Perform actions for a creature in a hurt state
            Console.WriteLine($"{creature.Name} is hurt and trying to heal itself...");
            _logger?.Log(System.Diagnostics.TraceEventType.Information, $"{creature.Name} is hurt and trying to heal itself...");
            creature.Health += 10; // Heal by 10 hit points
            Console.WriteLine($"{creature.Name} has healed itself and now has {creature.Health} health points.");
            _logger?.Log(System.Diagnostics.TraceEventType.Information, $"{creature.Name} has healed itself and now has {creature.Health} health points.");
            // Check if the creature should transition to a different state
            if (creature.Health <= 0)
            {
                
                creature.State = new DeadState(_logger); // Change the creature's state to DeadState
                Console.WriteLine($"{creature.Name} has died!");
                _logger?.Log(System.Diagnostics.TraceEventType.Information, $"{creature.Name} exits from hurt state and enters DeadState");
            }
        }
    }
}
