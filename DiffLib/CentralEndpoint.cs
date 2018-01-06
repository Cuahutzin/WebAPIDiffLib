using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// This is the implementation for the clients
    /// Clients will use this class/interface to comunicate to the endpoint
    /// </summary>
    public class CentralEndpoint : IDiffCentral
    {
        public CentralEndpoint(string urlCentralEndPoint)
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
