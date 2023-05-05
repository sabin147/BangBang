using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Xml.Linq;
using BangBang.Creatures.States;
using BangBang.Logging;
using BangBang.WorldObjects;

namespace BangBang.Creatures
{
    public class Creature 
    {
       
        private static ILogger? _logger;
        public static int DefaultHealth { get; set; } = 100;
        public static int DefaultDamage { get; set; } = 100;
        public string Name { get; set; }
        public int Health { get; set; } = DefaultHealth;
        public int Damage { get; set; } = DefaultDamage;
        public List<IAttackItem> Attacks { get; set; }
        public List<IDefenceItem> Defences { get; set; }    
        public Position Position { get; set; }
        public World World { get; set; }
        public ICreatureState State { get; set; } = new HurtState(_logger);

        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class with the specified name, logger, health, and position.
        /// </summary>
        /// <param name="name">The name of the creature.</param>
        /// <param name="logger">The logger to use.</param>
        /// <param name="health">The starting health of the creature.</param>
        /// <param name="position">The starting position of the creature in the world.</param>
        public Creature(string name, ILogger logger, int health, Position position)
        {
            Name = name;
            _logger = logger;
            Health = health;
            Attacks = new List<IAttackItem>();
            Defences = new List<IDefenceItem>();
            Position = position;
        }

        /// <summary>
        /// Updates the state of the creature.
        /// </summary>
        /// <param name="State">The new state of the creature.</param>
        public void UpdateState(ICreatureState State)
        {
            State.HandleState(this);
        }
        /// <summary>
        /// Sets the default values for all creatures.
        /// </summary>
        /// <param name="defaultDamage">The default damage.</param>
        /// <param name="defaultHeath">The default health.</param>
        public static void SetDefaultValues(int defaultDamage, int defaultHeath)
        {
            DefaultDamage = defaultDamage;
            DefaultHealth = defaultHeath;
            _logger?.Log(TraceEventType.Information, $"Default values for creature are set. Default damage: {defaultDamage}, default health: {defaultHeath}");
        }
        
        public bool Dead
        {
            get { return Health <= 0; }
        }

        public int GetHitPoints()
        {
            return Attacks.Sum(a => a.GetHitPoints());
        }

        public int GetReductionPoints()
        {
            return Defences.Sum(d => d.GetReduceHitPoints());
        }

        //public void AddItem(WorldObject item)
        //{
        //    if (item.Lootable)
        //    {
        //        if (item is AttackItem attackItem)
        //        {
        //            Attacks.Add(attackItem);
        //        }
        //        else if (item is DefenceItem defenceItem)
        //        {
        //            Defences.Add(defenceItem);
        //        }

        //        World.Objects.Remove(item);
        //    }
        //}

        /// <summary>
        /// The method calculates hit points based on the creature's attacks and the target's defenses.
        /// If the creature has no weapon to attack with, it logs the message and returns.
        /// Otherwise, it logs the total attack and defense of the creature and the target, calculates the net damage,
        /// and decreases the target's health by the net damage. If the target's health drops to or below zero,
        /// the method updates the target's state to DeadState.
        /// </summary>
        /// <param name="creature">The target creature to be hit</param>
        public void Hit(Creature creature)
        {
            // Calculate hit points based on the creature's attacks and the target's defenses
            //int hitPoints = Attacks.Sum(a => a.Health) - creature.Defences.Sum(d => d.Health);


            if (!Attacks.Any())
            {

                _logger?.Log(TraceEventType.Information, ($"{Name} has no weapon to attack with"));
                Console.WriteLine($"nothing to attack with " + $"!");
                return;
            }
            else
            {
                int hitPoints = GetHitPoints() - creature.GetReductionPoints();
               // int hitPoints = Attacks.Sum(a => a.HitPoint) - creature.Defences.Sum(d => d.ReduceHitPoint);
                _logger?.Log(TraceEventType.Information, ($"{Name} total attack is {GetHitPoints()}"));
                Console.WriteLine($"{Name} total attack is {GetHitPoints()}");
                _logger?.Log(TraceEventType.Information, ($"{creature.Name} total defence is {creature.GetReductionPoints()}"));
                Console.WriteLine($"{creature.Name} total defence is {creature.GetReductionPoints()}");
                Console.WriteLine($"{Name} net damage is {hitPoints}");
                _logger?.Log(TraceEventType.Warning, ($"{Name} net  damage is {hitPoints}"));

                if (hitPoints > 0)
                {
                    creature.Health -= hitPoints;
                    _logger?.Log(TraceEventType.Warning, ($"{Name} hits {creature.Name} for {hitPoints} damage!"));
                    Console.WriteLine($"{Name} hits {creature.Name} for {hitPoints} damage!");
                    Console.WriteLine($"{creature.Name} has {creature.Health} health left");
                    _logger?.Log(TraceEventType.Warning, ($"{creature.Name} has {creature.Health} health left"));
                    creature.UpdateState(new HurtState(_logger));
                }
                else
                {
                    _logger?.Log(TraceEventType.Information, ($"{Name} misses {creature.Name}!"));
                    Console.WriteLine($"{Name} misses to kill {creature.Name}!");
                }

                if (creature.Health <= 0)
                {
                    creature.UpdateState(new DeadState(_logger));
                   // _logger?.Log(TraceEventType.Warning, ($"{creature.Name} has died!"));
                    // World.Creatures.Remove(creature);
                   //_logger?.Log(TraceEventType.Warning, ($"{creature.Name} is in dead state! and has been removed from world "));
                }
                else
                {
                    Console.WriteLine($"{creature.Name} has now {creature.Health} health left");
                    _logger?.Log(TraceEventType.Warning, ($"{creature.Name} has now {creature.Health} health left"));
                }

            }
        }
        
        //public void ReceiveHit(int hitPoints, Creature creature)
        //{
        //    if (hitPoints > 0)
        //    {
        //        creature.Health -= hitPoints;
        //        _logger?.Log(TraceEventType.Warning, ($"{Name} hits {creature.Name} for {hitPoints} damage!"));
        //        Console.WriteLine($"{Name} hits {creature.Name} for {hitPoints} damage!");
        //    }
        //    if (creature.Health <= 0)
        //    {

        //        //World.Creatures.Remove(creature);
        //        _logger?.Log(TraceEventType.Warning, ($"{creature.Name} has died!"));
        //        _logger?.Log(TraceEventType.Information, ($"{creature.Name} has been removed from world"));
        //        Console.WriteLine($"{creature.Name}  has died! and removed from the world");
        //    }

        //    else
        //    {
        //        _logger?.Log(TraceEventType.Warning, ($"{Name} misses {creature.Name}!"));
        //        Console.WriteLine($"{creature.Name} has {creature.Health} health left");
        //        Console.WriteLine($"{Name} misses to kill {creature.Name}!");
        //    }
        //Health -= health;
        //if (Health <= 0)
        //{
        //    Console.WriteLine($"{Name} has died!");
        //    Logger.GetInstance().Log(TraceEventType.Information, $"Creature --- {creature.Name} --- is dead");
        //}
        //}
    }
}
