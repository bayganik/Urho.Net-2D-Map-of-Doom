using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{

    /*
     * Vertices are used by the LINEDEFS and SEGS lumps
     */

    public class MapVertex
    {

        /// <summary>
        /// The X position.
        /// </summary>
        public short X { get; set; }

        /// <summary>
        /// The Y position.
        /// </summary>
        public short Y { get; set; }
        
        public MapVertex()
        {

        }
        public MapVertex(short _x, short _y)
        {
            X = _x;
            Y = _y;
        }
    }

}
