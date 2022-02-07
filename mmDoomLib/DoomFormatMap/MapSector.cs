using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{

    /*
     * A sector is an enclosed area made up of lines in the map. Sectors are referenced by the sidedefs 
     * linked to the enclosing linedefs. Sectors must be closed areas, as in all sidedefs that reference 
     * them must make up one or more closed shapes. Note that having unclosed sectors is possible, and can be 
     * used for a few special effects, but can cause unpredictable results,
     */
    public class MapSector
    {

        /// <summary>
        /// The floor height.
        /// </summary>
        public short FloorHeight { get; set; }

        /// <summary>
        /// The ceiling height.
        /// </summary>
        public short CeilingHeight { get; set; }

        /// <summary>
        /// The floor texture.
        /// </summary>
        public string FloorTexture { get; set; }

        /// <summary>
        /// The ceiling textue.
        /// </summary>
        public string CeilingTexture { get; set; }

        /// <summary>
        /// The light level.
        /// </summary>
        public short Light { get; set; }

        /// <summary>
        /// The action.
        /// </summary>
        public ushort Action { get; set; }

        /// <summary>
        /// The tag.
        /// </summary>
        public ushort Tag { get; set; }

    }

}
