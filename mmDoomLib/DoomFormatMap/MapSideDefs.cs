using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{

    /*
     * A sidedef is a structure bound to a linedef in order to specify for one side of the linedef 
     * which sector to refer to, what texture to use and where, and how to display and offset that texture. 
     * Sidedefs are assigned to linedefs, not the other way around.
     */
    public class MapSideDefs
    {

        /// <summary>
        /// The X texture offset.
        /// </summary>
        public short XOffset { get; set; }

        /// <summary>
        /// The Y texture row offset.
        /// </summary>
        public short YOffset { get; set; }

        /// <summary>
        /// The upper texture's name (Top)
        /// </summary>
        public string UpperTexture { get; set; }

        /// <summary>
        /// The lower texture's name (bottom)
        /// </summary>
        public string LowerTexture { get; set; }

        /// <summary>
        /// The middle texture's name.
        /// </summary>
        public string MiddleTexture { get; set; }

        /// <summary>
        /// The sector.
        /// </summary>
        public ushort Sector { get; set; }

    }

}
