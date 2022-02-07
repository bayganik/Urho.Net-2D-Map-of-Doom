using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmDoomLibOld
{
    /// <summary>
    /// An element that has a lump name.
    /// </summary>
    public abstract class NamedElement : IElement
    {

        /// <summary>
        /// Constructor for a named element.
        /// </summary>
        /// <param name="name"></param>
        public NamedElement(string name)
        {

            // Check for a null name.
            if (name == null)
                throw new ArgumentNullException("Name cannot be null.");

            // Check for an empty name.
            if (name.Length == 0)
                throw new ArgumentException("Name cannot be empty.");

            // Set the name.
            Name = name;

        }

        /// <summary>
        /// The element's name.
        /// </summary>
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 8)
                    _name = value.Substring(0, 8);
                else
                    _name = value;
            }
        }

        #region IElement implementation

        public abstract Type Type { get; }

        #endregion

    }
}
