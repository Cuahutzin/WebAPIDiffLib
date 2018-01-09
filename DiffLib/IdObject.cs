using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// Object stored in a collection (ICentralServerState)
    /// </summary>
    public class IdObject
    {
        /// <summary>
        /// Id of the created for the diff process
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Data stored
        /// </summary>
        public string Data1 { get; set; }
        /// <summary>
        /// Data stored
        /// </summary>
        public string Data2 { get; set; }
    }
}
