using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib.Packets
{
    /// <summary>
    /// CreateId request object. A request to be answered by a Worker server
    /// </summary>
    public class CreateIdWorkerRequest
    {
        /// <summary>
        /// Data will be passed to a Central server (base64 encoded byte array)
        /// </summary>
        public string Data { get; set; } = string.Empty;
    }
}
