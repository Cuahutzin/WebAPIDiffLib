using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// Interface of CentralServer
    /// </summary>
    public interface ICentralServer
    {
        /// <summary>
        /// Creates an id to be used to complete the diff process
        /// </summary>
        /// <param name="workerId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        string CreateId(string workerId, string data);
        /// <summary>
        /// Completes the id with the missing data
        /// </summary>
        /// <param name="workerId"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        bool CompleteId(string workerId, string id, string data);
        /// <summary>
        /// Diff operation and returns a diff result
        /// </summary>
        /// <param name="workerId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        DiffResult GetDiff(string workerId, string id);
    }
}
