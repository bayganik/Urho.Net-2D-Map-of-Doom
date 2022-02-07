using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{

    /// <summary>
    /// A Hexen format map line.
    /// </summary>
    public class HexenLine
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

        /// <summary>
        /// The tag.
        /// </summary>
        public ushort Tag { get; set; }

        /// <summary>
        /// The line's right side.
        /// </summary>
        public ushort RightSide { get; set; }

        /// <summary>
        /// The line's left side.
        /// </summary>
        public ushort LeftSide { get; set; }

    }

}
