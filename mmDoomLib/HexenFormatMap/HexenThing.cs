
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{

    /// <summary>
    /// A Hexen format map thing.
    /// </summary>
    public class HexenThing
    {

        /// <summary>
        /// The ID.
        /// </summary>
        public ushort Id { get; set; }

        /// <summary>
        /// The X position.
        /// </summary>
        public short X { get; set; }

        /// <summary>
        /// The Y position.
        /// </summary>
        public short Y { get; set; }

        /// <summary>
        /// The Z position.
        /// </summary>
        public short Z { get; set; }

        /// <summary>
        /// The angle.
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

        /// <summary>
        /// The thing's action.
        /// </summary>
        public byte Action { get; set; }

        /// <summary>
        /// The action's first argument.
        /// </summary>
        public byte ActionArgument1 { get; set; }

        /// <summary>
        /// The action's second argument.
        /// </summary>
        public byte ActionArgument2 { get; set; }

        /// <summary>
        /// The action's third argument.
        /// </summary>
        public byte ActionArgument3 { get; set; }

        /// <summary>
        /// The action's fourth argument.
        /// </summary>
        public byte ActionArgument4 { get; set; }

        /// <summary>
        /// The action's fifth argument.
        /// </summary>
        public byte ActionArgument5 { get; set; }

    }

}
