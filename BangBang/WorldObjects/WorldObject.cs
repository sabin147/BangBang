using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BangBang.Logging;


namespace BangBang.WorldObjects
{
    public class WorldObject
    {
        
        public string Name { get; set; }
        public bool Removable { get; set; }
        public bool Lootable { get; set; }
        public Position Position { get; set; }

        public WorldObject( string name, Position position)
        {
            Name = name;
            Position = position;
        }
    }
}
