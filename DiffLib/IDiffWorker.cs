using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// IDiffWorker will first recieve the request, then to be sent to the IDiffCentral endpoint
    /// First worker will `CreateRequest(string data)` and Central will return an ID
    /// Since we already have an ID, second worker will `CreateRequest(string id, string data)` to finish that ID/process
    /// </summary>
    public interface IDiffWorker
    {
        string Id { get; }
        /// <summary>
        /// This will request to the Central endpoint. It will return the result if it succeded and ID
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        WorkerCreateRequestResult CreateRequest(string data);
        /// <summary>
        /// This will request to the Central endpoint to finish the process
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        WorkerCreateRequestResult CompleteRequest(string id, string data);
    }
}
