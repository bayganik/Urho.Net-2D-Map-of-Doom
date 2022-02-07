using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace mmDoomLibOld
{

    /// <summary>
    /// An unknown element loader.
    /// </summary>
    class UnknownElementLoader : BaseElementLoader
    {

        #region ElementLoader implementation

        public override int CanLoad(BinaryReader reader, IList<DirectoryEntry> entries)
        {

            // As this is an unknown element, always return 1.
            return 1;

        }

        public override IElement Load(BinaryReader reader, IList<DirectoryEntry> entries)
        {

            // Get the lump. There is guaranteed to be exactly one lump in the
            // list.
            DirectoryEntry lump = entries[0];

            // Set the reader's position to the beginning of the lump.
            reader.BaseStream.Position = lump.Offset;

            // Construct and return an unknown element.
            return new UnknownElement(entries[0].Name, reader.ReadBytes(lump.Size));

        }

        #endregion

    }

}
