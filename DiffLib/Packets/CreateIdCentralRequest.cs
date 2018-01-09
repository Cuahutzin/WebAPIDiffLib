using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib.Packets
{
    /// <summary>
    /// CreateId request object. A request to be answered by a Central server.
    /// </summary>
    public class CreateIdCentralRequest
    {
        /// <summary>
        /// WorkerId (whitelist)
        /// </summary>
        public string WorkerId { get; set; } = string.Empty;
        /// <summary>
        /// Data to be saved for a later diff process (base64 encoded byte array)
        /// </summary>
        public string Data { get; set; } = string.Empty;
    }
}
