using BangBang.Creatures;
using BangBang.Logging;
using BangBang.WorldObjects;
using System.Diagnostics;

namespace BangBang
{
    public class World
    {

        public static World? _instance;
        public static int DefaultMaxX { get; set; } = 100;
        public static int DefaultMaxY { get; set; } = 100;
        public int MaxX { get; set; } = DefaultMaxX;
        public int MaxY { get; set; } = DefaultMaxY;
        public List<Creature> Creatures { get; set; }
        public List<WorldObject> Objects { get; set; }
        public static ILogger _logger;

        /// <summary>
        /// Creates a new game world with the specified maximum x and y coordinates.
        /// </summary>
        /// <param name="maxX">The maximum x-coordinate of the game world.</param>
        /// <param name="maxY">The maximum y-coordinate of the game world.</param>
        public World (int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
           
            Creatures = new List<Creature>();
            Objects = new List<WorldObject>();
        }
        /// <summary>
        /// Creates a new instance of the game world with the specified maximum x and y coordinates.
        /// </summary>
        /// <param name="maxX">The maximum x-coordinate of the game world.</param>
        /// <param name="maxY">The maximum y-coordinate of the game world.</param>
        /// <returns>The newly created instance of the game world.</returns>
        public static World CreateInstance(int maxX, int maxY)
        {
            if (_instance == null)
            {
                _instance = new World(maxX, maxY);
                Logger.GetInstance().Log(TraceEventType.Information, "World is created");
            }
            else
            {
                throw new InvalidOperationException("Object instance is already created");
            }
            return _instance;
        }
        /// <summary>
        /// Sets the default maximum x and y coordinates for the game world.
        /// </summary>
        /// <param name="maxX">The new default maximum x-coordinate of the game world.</param>
        /// <param name="maxY">The new default maximum y-coordinate of the game world.</param>
        public static void SetDefaultValues(int maxX, int maxY)
        {
            DefaultMaxX = maxX;
            DefaultMaxY = maxY;
            Logger.GetInstance().Log(TraceEventType.Information, $"Default values for world are set. MaxX: {maxX}, MaxY: {maxY}");
        }
        /// <summary>
        /// Removes a creature from the game world.
        /// </summary>
        /// <param name="creature">The creature to be removed from the game world.</param>
        public void RemoveCreatureFromWorld(Creature creature)
        public void RemoveCreatureFromWorld(Creature creature)
        {
            World? world = _instance;
            if (world != null)
            {
                List<Creature> creatures = world.Creatures ?? new List<Creature>();
                if (creatures.Contains(creature))
                {
                    creatures.Remove(creature);
                }
                else
                {
                    _logger?.Log(TraceEventType.Warning, "Creature is not in the game world so it cannot be removed.");
                }
            }
            else
            {
                _logger?.Log(TraceEventType.Error, "Cannot remove creature from the world as the world is not created");
            }
        }
    }
}