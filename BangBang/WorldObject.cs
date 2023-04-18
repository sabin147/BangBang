using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBang
{
    public class WorldObject
    {
        public bool Lootable { get; set; }
        public string Name { get; set; }
        public bool Removable { get; set; }
        public Position Position { get; set; }

        public WorldObject (bool lootable, string name, bool removable, Position position)
        {
            Lootable = lootable;
            Name = name;
            Removable = removable;
            Position = position;
        }
    }
}
