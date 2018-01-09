using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib.Packets
{
    /// <summary>
    /// GetDiff response object. Contains the actual result of diff
    /// </summary>
    public class GetDiffResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Result of diff
        /// </summary>
        public DiffLib.DiffResult Result { get; set; }
        
    }
}
