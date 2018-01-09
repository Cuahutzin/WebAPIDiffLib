using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// Central server state interface
    /// </summary>
    public interface ICentralServerState
    {
        /// <summary>
        /// Inserts id into a collection
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string NewId(string data);
        /// <summary>
        /// Completes an id with the missing data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        bool CompleteId(string id, string data);
        /// <summary>
        /// Returns the stored object based on id from a collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IdObject Get(string id);
    }
}
