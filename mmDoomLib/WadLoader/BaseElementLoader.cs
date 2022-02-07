
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{

    /// <summary>
    /// An element loader.
    /// </summary>
    public abstract class BaseElementLoader
    {

        /// <summary>
        /// Whether the loader can load the element given to it.
        /// </summary>
        /// <param name="reader">The file reader.</param>
        /// <param name="entries">A list of all entries, the current one being index 0.</param>
        /// <returns>The number of entries consumed, or 0 if it cannot be loaded.</returns>
        public abstract int CanLoad(BinaryReader reader, IList<DirectoryEntry> entries);

        /// <summary>
        /// Loads and returns the element.
        /// </summary>
        /// <param name="reader">The file reader.</param>
        /// <param name="entries">A list of entries consumed by the CanLoad method.</param>
        /// <returns>The element.</returns>
        public abstract IElement Load(BinaryReader reader, IList<DirectoryEntry> entries);

        /// <summary>
        /// Converts a character array to a string, trimming off any '\0' 
        /// characters in the process.
        /// </summary>
        /// <param name="chars">The character array to convert.</param>
        /// <returns>The formatted string.</returns>
        protected string FormatString(char[] chars)
        {

            return new string(chars).TrimEnd('\0');
            
        }

    }

}
