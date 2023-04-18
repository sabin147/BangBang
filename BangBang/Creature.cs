using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BangBang
{
    public class Creature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public List<AttackItem> Attacks { get; set; }
        public List<DefenceItem> Defences { get; set; }
        public Position Position { get; set; }
        public World World { get; set; }    


        public Creature(string name, int hitPoint, Position position)
        {
            Name= name;
            HitPoint= hitPoint;
            Attacks = new List<AttackItem>();
            Defences = new List<DefenceItem>();
            Position= position;
        }   
        public void Hit(Creature creature)
        {
            // Calculate hit points based on the creature's attacks and the target's defenses
            int hitPoints = Attacks.Sum(a => a.HitPoint) - creature.Defences.Sum(d => d.ReduceHitPoint);

            if (hitPoints > 0)
            {
                creature.HitPoint -= hitPoints;
                Console.WriteLine($"{Name} hits {creature.Name} for {hitPoints} damage!");
                if (creature.HitPoint <= 0)
                {
                    Console.WriteLine($"{creature.Name} has died!");
                }
            }
            else
            {
                Console.WriteLine($"{Name} misses {creature.Name}!");
            }
        }

        public void Loot(WorldObject item)
        {
            if (item.Lootable)
            {
                if (item is AttackItem attackItem)
                {
                    Attacks.Add(attackItem);
                }
            else if (item is DefenceItem defenceItem)
                {
                    Defences.Add(defenceItem);
                }
                World.Objects.Remove(item);
            }
        }

        public void ReceiveHit( int hitPoints)
        {
            HitPoint -= hitPoints;
        if (HitPoint <= 0)
        {
            Console.WriteLine($"{Name} has died!");
        }
        }

        
    }
}
