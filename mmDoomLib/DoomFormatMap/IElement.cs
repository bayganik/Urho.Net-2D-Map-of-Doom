using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{
    /// <summary>
    /// An element inside a WAD.
    /// </summary>
    public interface IElement
    {

        /// <summary>
        /// The type of the element.
        /// </summary>
        Type Type { get; }

    }
}
