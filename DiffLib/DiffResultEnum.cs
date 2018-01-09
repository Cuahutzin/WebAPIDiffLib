using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// Types of results from diff
    /// </summary>
    public enum DiffResultEnum
    {
        /// <summary>
        /// Length and content are equal
        /// </summary>
        Equal,
        /// <summary>
        /// Length are not equal. Diff cannot be done
        /// </summary>
        NotEqualSize,
        /// <summary>
        /// Length are equal. Content is not.
        /// </summary>
        SameSize_ContentNotEqual
    }
}
