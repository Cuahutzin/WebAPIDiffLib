using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// This is the implementation for the server
    /// Central server will be using this class
    /// </summary>
    public class CentralImplementation : IDiffCentral
    {
        public CentralImplementation(IList<string> workerIds)
        {

        }

        CentralCheckRequestResult IDiffCentral.CheckRequest(string id)
        {
            throw new NotImplementedException();
        }

        CentralCreateRequestResult IDiffCentral.CreateRequest(string id, string workerId, string data)
        {
            throw new NotImplementedException();
        }
    }
}
