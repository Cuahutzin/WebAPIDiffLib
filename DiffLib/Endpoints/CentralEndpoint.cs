using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffLib.Packets;

namespace DiffLib.Endpoints
{
    public class CentralEndpoint
    {
        public string Id { get; private set; }
        protected IRouteConf Conf { get; private set; }
        protected ISender Sender { get; private set; }

        public CentralEndpoint(string id, IRouteConf conf, ISender sender)
        {
            Id = id;
            Conf = conf;
            Sender = sender;
        }

        public Task<Packets.CreateIdResponse> CreateIdAsync()
        {
            return Sender.PostAsync<CreateIdResponse, CreateIdRequest>(Conf.CreateIdPath, new CreateIdRequest() { WorkerId = Id });
        }

        public Task<Packets.CompleteIdResponse> CompleteIdAsync(string id)
        {
            return Sender.PostAsync<CompleteIdResponse, CompleteIdRequest>(Conf.GetCompleteIdPath(id), new CompleteIdRequest() { WorkerId = Id });
        }

        public Task<Packets.GetDiffResponse> GetDiffAsync(string id)
        {
            return Sender.PostAsync<GetDiffResponse, GetDiffRequest>(Conf.GetResultPath(id), new GetDiffRequest() { WorkerId = Id });
        }
    }
}
