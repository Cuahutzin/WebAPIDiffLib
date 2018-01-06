using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// Implementation for the worker client
    /// </summary>
    public class Worker : IDiffWorker
    {
        public string Id { get; set; }

        //string IDiffWorker.Id => throw new NotImplementedException();

        public Worker(string id, CentralEndpoint centralEndpoint, ISender sender)
        {

        }

        WorkerCreateRequestResult IDiffWorker.CreateRequest(string data)
        {
            throw new NotImplementedException();
        }

        WorkerCreateRequestResult IDiffWorker.CompleteRequest(string id, string data)
        {
            throw new NotImplementedException();
        }
    }
}
