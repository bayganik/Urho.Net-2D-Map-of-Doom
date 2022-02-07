using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{

    /*
     * things are used to represent players, monsters, pick-ups, and projectiles. 
     * Inside the game, these are known as actors. There are three ways to get an actor into your map. 
     * Most things are actors, so the names are often used interchangeably. A few things, however, are not actors, 
     * such as player start points.
     */
    public class MapThing
    {

        /// <summary>
        /// The X position.
        /// </summary>
        public short X { get; set; }

        /// <summary>
        /// The Y position.
        /// </summary>
        public short Y { get; set; }

        /// <summary>
        /// The starting angle
        /// </summary>
        public ushort Angle { get; set; }

        /// <summary>
        /// The type.
        /// </summary>
        public ushort Type { get; set; }

        /// <summary>
        /// The spawn flags.
        /// </summary>
        public ushort Flags { get; set; }

    }

}
