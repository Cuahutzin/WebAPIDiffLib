using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// IDiffCentral endpoint will handle all requests done by IDiffWorkers
    /// </summary>
    public interface IDiffCentral
    {
        /// <summary>
        /// When IDiffWorker requests, it will always check Central to create the ID.
        /// `workerId` is used for a weak attempt to deny unkown sources. (workerId is checked against a collection, 
        /// if it is not in list, it will deny the request)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="workerId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        CentralCreateRequestResult CreateRequest(string id, string workerId, string data);
        /// <summary>
        /// Client will check the status of the request (Go to StatusEnum for more info)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CentralCheckRequestResult CheckRequest(string id);
    }
}
