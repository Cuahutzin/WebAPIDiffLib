using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// Offset instance created by a diff process
    /// </summary>
    public class DiffOffset
    {
        /// <summary>
        /// Index of byte array where the offset starts
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// Length of mismatch
        /// </summary>
        public int Length { get; set; } = 1;
    }
}
