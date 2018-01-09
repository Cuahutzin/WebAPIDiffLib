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
    public class CompleteIdResponse
    {
        /// <summary>
        /// Holds the Id.
        /// </summary>
        public string Id { get; set; } = string.Empty;
    }
}
