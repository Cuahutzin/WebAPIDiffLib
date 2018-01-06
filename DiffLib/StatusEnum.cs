using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    public enum StatusEnum
    {
        /// <summary>
        /// OK = Request was processed
        /// </summary>
        OK,
        /// <summary>
        /// ID = Request is still processing (worker needs to send the other info)
        /// </summary>
        Pending,
        /// <summary>
        /// workerId is not allowed to do requests
        /// </summary>
        Unauthorized,
        /// <summary>
        /// ID has not been created
        /// </summary>
        IdNotCreated,
    }
}
