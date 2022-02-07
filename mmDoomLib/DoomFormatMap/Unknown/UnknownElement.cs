
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{

    /// <summary>
    /// An unknown element. An element should default to this if no other type
    /// matches are found.
    /// </summary>
    public class UnknownElement : NamedElement
    {

        /// <summary>
        /// Constructor for an unknown element.
        /// </summary>
        /// <param name="name"></param>
        public UnknownElement(string name, byte[] data) : base(name)
        {

            // Set the data.
            Data = data;

        }

        /// <summary>
        /// The element's raw data.
        /// </summary>
        public byte[] Data { get; set; }

        #region IElement implementation

        public override Type Type { get { return typeof(UnknownElement); } }

        #endregion

    }

}
