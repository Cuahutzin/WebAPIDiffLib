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
        public string Id { get; private set; }
        protected IRouteConf Conf { get; private set; }
        protected ISender Sender { get; private set; }

        public WorkerEndpoint(string id, IRouteConf conf, ISender sender)
        {
            Id = id;
            Conf = conf;
            Sender = sender;
        }

        public Task<Packets.CreateIdResponse> CreateIdAsync(string data)
        {
            return Sender.PostAsync<CreateIdResponse, CreateIdRequest>(Conf.CreateIdPath, new CreateIdRequest() { WorkerId = Id, Data = data });
        }

        public Task<Packets.CompleteIdResponse> CompleteIdAsync(string id, string data)
        {
            return Sender.PostAsync<CompleteIdResponse, CompleteIdRequest>(Conf.GetCompleteIdPath(id), new CompleteIdRequest() { WorkerId = Id, Data = data });
        }
    }
}
