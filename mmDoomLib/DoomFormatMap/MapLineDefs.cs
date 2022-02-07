using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{
    /*
     * Linedefs are what make up the 'shape' (for lack of a better word) of your map. 
     * Every linedef is between two vertices and contains one or two sidedefs (which contain texture data). 
     * There are two major purposes of linedefs. The first is to give your map a definitive boundary between the 
     * player and the void (any area of a map behind a one-sided linedef is considered void space), 
     * and the second is to trigger action specials.
     */

    public class MapLineDefs
    {

        /// <summary>
        /// The line's starting vertex.
        /// </summary>
        public ushort StartVertex { get; set; }

        /// <summary>
        /// The line's ending vertex.
        /// </summary>
        public ushort EndVertex { get; set; }

        /// <summary>
        /// The flags.
        /// </summary>
        public ushort Flags { get; set; }

        /// <summary>
        /// The action.
        /// </summary>
        public ushort Action { get; set; }          //aka Special

        /// <summary>
        /// The tag.
        /// </summary>
        public ushort Tag { get; set; }

        /// <summary>
        /// The line's right side.
        /// </summary>
        public ushort RightSide { get; set; }       //aka Sidenum0

        /// <summary>
        /// The line's left side.
        /// </summary>
        public ushort LeftSide { get; set; }        //aka Sidenum1

    }

}
