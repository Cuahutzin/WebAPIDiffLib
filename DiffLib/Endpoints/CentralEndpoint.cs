using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffLib.Packets;

namespace DiffLib.Endpoints
{
    public class CentralEndpoint : ICentralEndpoint, IDisposable
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

        public Task<Packets.CreateIdResponse> CreateIdAsync(byte[] dx)
        {
            string data = Convert.ToBase64String(dx);
            return Sender.PostAsync<CreateIdResponse, CreateIdCentralRequest>(Conf.CreateIdPath, new CreateIdCentralRequest() { WorkerId = Id, Data = data });
        }

        public Task<Packets.CompleteIdResponse> CompleteIdAsync(string id, byte[] dx)
        {
            string data = Convert.ToBase64String(dx);
            return Sender.PostAsync<CompleteIdResponse, CompleteIdCentralRequest>(Conf.GetCompleteIdPath(id), new CompleteIdCentralRequest() { WorkerId = Id, Data = data });
        }

        public Task<Packets.CreateIdResponse> CreateIdAsync(string data)
        {
            return Sender.PostAsync<CreateIdResponse, CreateIdCentralRequest>(Conf.CreateIdPath, new CreateIdCentralRequest() { WorkerId = Id, Data = data });
        }

        public Task<Packets.CompleteIdResponse> CompleteIdAsync(string id, string data)
        {
            return Sender.PostAsync<CompleteIdResponse, CompleteIdCentralRequest>(Conf.GetCompleteIdPath(id), new CompleteIdCentralRequest() { WorkerId = Id, Data = data });
        }

        public Task<Packets.GetDiffResponse> GetDiffAsync(string id)
        {
            return Sender.PostAsync<GetDiffResponse, GetDiffRequest>(Conf.GetResultPath(id), new GetDiffRequest() { WorkerId = Id });
        }

        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
