using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffLib.Packets;

namespace DiffLib.Endpoints
{
    public class WorkerEndpoint
    {
        protected IRouteConf Conf { get; private set; }
        protected ISender Sender { get; private set; }

        public WorkerEndpoint(IRouteConf conf, ISender sender)
        {
            Conf = conf;
            Sender = sender;
        }

        public Task<Packets.CreateIdResponse> CreateIdAsync(byte[] dx)
        {
            string data = Convert.ToBase64String(dx);
            return Sender.PostAsync<CreateIdResponse, CreateIdWorkerRequest>(Conf.CreateIdPath, new CreateIdWorkerRequest() { Data = data });
        }
        
        public Task<Packets.CompleteIdResponse> CompleteIdAsync(string id, byte[] dx)
        {
            string data = Convert.ToBase64String(dx);
            return Sender.PostAsync<CompleteIdResponse, CompleteIdWorkerRequest>(Conf.GetCompleteIdPath(id), new CompleteIdWorkerRequest() { Data = data });
        }
        
    }
}
