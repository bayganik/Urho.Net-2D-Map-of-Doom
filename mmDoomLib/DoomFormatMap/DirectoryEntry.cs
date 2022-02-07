using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{

    /// <summary>
    /// An entry for a lump in the WAD's directory.
    /// </summary>
    public class DirectoryEntry
    {

        /// <summary>
        /// Constructor for a directory entry.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="name"></param>
        public DirectoryEntry(int offset, int size, string name)
        {
            _offset = offset;
            _size = size;
            _name = name;
        }

        /// <summary>
        /// The lump's offset.
        /// </summary>
        public int Offset { get { return _offset; } }
        private readonly int _offset;

        /// <summary>
        /// The lump's size in bytes.
        /// </summary>
        public int Size { get { return _size; } }
        private readonly int _size;

        /// <summary>
        /// The lump's name.
        /// </summary>
        public string Name { get { return _name; } }
        private readonly string _name;


    }

}
