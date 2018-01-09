using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib.Packets
{
    /// <summary>
    /// GetDiff request object. A request to be answered by a Central server
    /// </summary>
    public class GetDiffRequest
    {
        /// <summary>
        /// WorkerId (whitelist)
        /// </summary>
        public string WorkerId { get; set; } = string.Empty;
    }
}
