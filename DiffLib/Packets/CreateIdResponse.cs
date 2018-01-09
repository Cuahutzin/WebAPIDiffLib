using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib.Packets
{
    /// <summary>
    /// Response object
    /// </summary>
    public class CreateIdResponse
    {
        /// <summary>
        /// Holds the created id to be later used for Complete and GetDiff operations
        /// </summary>
        public string Id { get; set; } = string.Empty;
    }
}
