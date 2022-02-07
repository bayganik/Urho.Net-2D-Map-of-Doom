using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{

    /// <summary>
    /// A Doom format map.
    /// </summary>
    public class MapElement : NamedElement
    {

        /// <summary>
        /// Constructor for a Doom format map.
        /// </summary>
        /// <param name="name"></param>
        public MapElement(string name) : base(name)
        {
            MapName = name;
        }
        public string MapName { get; set; }
        /// <summary>
        /// The map's things.
        /// </summary>
        public IList<MapThing> Things { get; set; }

        /// <summary>
        /// The map's lines.
        /// </summary>
        public IList<MapLineDefs> LineDef { get; set; }

        /// <summary>
        /// The map's sides.
        /// </summary>
        public IList<MapSideDefs> SideDef { get; set; }

        /// <summary>
        /// The map's vertexes.
        /// </summary>
        public IList<MapVertex> Vertexes { get; set; }

        /// <summary>
        /// The map's segments.
        /// </summary>
        public byte[] Segments { get; set; }

        /// <summary>
        /// The map's subsectors.
        /// </summary>
        public byte[] SubSectors { get; set; }

        /// <summary>
        /// The map's nodes.
        /// </summary>
        public byte[] Nodes { get; set; }

        /// <summary>
        /// The map's sectors.
        /// </summary>
        public IList<MapSector> Sectors { get; set; }

        /// <summary>
        /// The map's reject table.
        /// </summary>
        public byte[] RejectTable { get; set; }

        /// <summary>
        /// The map's blockmap.
        /// </summary>
        public byte[] Blockmap { get; set; }

        #region IElement implementation

        public override Type Type { get { return typeof(MapElement); } }

        #endregion

    }

}
